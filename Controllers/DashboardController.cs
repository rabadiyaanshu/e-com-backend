using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLoginRegisterApi.Data;
using WebLoginRegisterApi.Model;

namespace WebLoginRegisterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly UsersContext _usersContext;
        private readonly ApplicationDbContext _orderContext;
            
        public DashboardController(UsersContext usersContext, ApplicationDbContext orderContext)
        {
            _usersContext = usersContext;
            _orderContext = orderContext;
        }

        
        [HttpGet("summary")]
        public IActionResult GetSummary()
        {
            var totalUsers = _usersContext.Users.Count();
            var activeUsers = _usersContext.Users.Count(u => u.IsLoggedIn == true);
            var revenue = _orderContext.Orders.Sum(o => o.TotalAmount);

            var dashboardData = new
            {
                totalUsers,
                activeUsers,
                revenue,
                growth = "15%" 
            };

            return Ok(dashboardData);
        }

       
        [HttpGet("user-orders")]
        public async Task<IActionResult> GetUserOrderSummary()
        {
            var summary = await _orderContext.Orders
                .GroupBy(o => o.CustomerName)
                .Select(g => new
                {
                    CustomerName = g.Key,
                    TotalOrders = g.Count(),
                    TotalAmount = g.Sum(o => o.TotalAmount)
                })
                .ToListAsync();
                
            return Ok(summary);
        }

       
        [HttpGet("product-orders")]
        public async Task<IActionResult> GetProductOrderSummary()
        {
            var summary = await _orderContext.Orders
                .GroupBy(o => o.ProductName)
                .Select(g => new
                {
                    ProductName = g.Key,
                    TotalQuantity = g.Sum(o => o.Quantity),
                    TotalRevenue = g.Sum(o => o.TotalAmount),
                    ProductImage = _orderContext.Products
                        .Where(p => p.Name == g.Key)
                        .Select(p => p.ImageUrl)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return Ok(summary);
        }

        [HttpGet("monthly-sales")]
        public IActionResult GetMonthlySales()
        {
            
            var orders = _orderContext.Orders
                .Select(o => new { o.OrderDate, o.TotalAmount })
                .ToList();  

            
            var sales = orders
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    Month = $"{g.Key.Month}/{g.Key.Year}",
                    Total = g.Sum(o => o.TotalAmount)   
                })
                .OrderBy(g => g.Month)
                .ToList();

            var labels = sales.Select(s => s.Month).ToArray();
            var values = sales.Select(s => s.Total).ToArray();

            return Ok(new { labels, values });
        }

        public IEnumerable<UserModel> GetUserModels()
        {
            return _usersContext.Users
                        .Where(u => u.IsLoggedIn && u.LastLoginDate.HasValue)
                        .ToList();
        }

        [HttpGet("active-users")]
        public IActionResult GetActiveUsers(IEnumerable<UserModel> userModels)
        {
            var users = userModels.GroupBy(u => u.LastLoginDate.Value.Date)
                .Select(g => new
                {
                    Date = g.Key.ToString("yyyy-MM-dd"),
                    Count = g.Count()
                })
                .OrderBy(g => g.Date)
                .ToList();

            var labels = users.Select(x => x.Date).ToArray();
            var values = users.Select(x => x.Count).ToArray();

            return Ok(new { labels, values });
        }                                                                        
       
    }
}
