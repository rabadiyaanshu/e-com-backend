using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebLoginRegisterApi.Model;

namespace WebLoginRegisterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public OrdersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] OrderModel order)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"INSERT INTO Orders 
                            (ProductName, Category, Price, Quantity, TotalAmount, CustomerName, Address, City, Pincode, Phone, PaymentMethod)
                            VALUES
                            (@ProductName, @Category, @Price, @Quantity, @TotalAmount, @CustomerName, @Address, @City, @Pincode, @Phone, @PaymentMethod)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductName", order.ProductName);
                cmd.Parameters.AddWithValue("@Category", order.Category);
                cmd.Parameters.AddWithValue("@Price", order.Price);
                cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
                cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                cmd.Parameters.AddWithValue("@Address", order.Address);
                cmd.Parameters.AddWithValue("@City", order.City);
                cmd.Parameters.AddWithValue("@Pincode", order.Pincode);
                cmd.Parameters.AddWithValue("@Phone", order.Phone);
                cmd.Parameters.AddWithValue("@PaymentMethod", order.PaymentMethod);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return Ok(new { message = "Order placed successfully" });
        }

        [HttpGet("top-women-products")]
        public IActionResult GetTopWomenProducts()
        {
            List<object> products = new List<object>();

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"
                    SELECT TOP 4 
                        p.Id,
                        p.Name, 
                        p.Category, 
                        p.Price, 
                        p.ImageUrl,
                        COUNT(*) as OrderCount
                    FROM Orders o
                    JOIN Products p ON o.ProductName = p.Name
                    WHERE LOWER(p.Category) = 'women'
                    GROUP BY p.Id, p.Name, p.Category, p.Price, p.ImageUrl
                    ORDER BY OrderCount DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Category = reader["Category"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        ImageUrl = reader["ImageUrl"].ToString(),
                        Orders = Convert.ToInt32(reader["OrderCount"])
                    });
                }
            }

            return Ok(products);
        }
        [HttpGet("sales-summary")]
        public IActionResult GetSalesSummary()
        {
            List<object> summary = new List<object>();

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"
            SELECT 
                p.Category as Title, 
                COUNT(o.Id) as Value
            FROM Orders o
            JOIN Products p ON o.ProductName = p.Name
            GROUP BY p.Category";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    summary.Add(new
                    {
                        Title = reader["Title"].ToString(),
                        Value = Convert.ToInt32(reader["Value"]),
                        Percentage = 0,             
                        Since = "Since last week"    
                    });
                }
            }

            return Ok(summary);
        }
    }
}
