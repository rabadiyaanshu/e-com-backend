using Microsoft.AspNetCore.Mvc;
using WebLoginRegisterApi.Model;

namespace WebLoginRegisterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        [HttpGet]
        public IActionResult GetNotifications()
        {
            var notifications = new List<Notification>
            {
                new Notification { Id = 1 , Title = "Welcome" , Message = "Welcome to the Dashboard" , CreatedAt = DateTime.Now },
                new Notification { Id = 2 , Title = "Update" , Message = "New Featuress Added!" , CreatedAt = DateTime.Now.AddMinutes(-30) },
                new Notification { Id = 3 , Title = "Reminder" , Message = "Don't forget to check updates." , CreatedAt = DateTime.Now.AddHours(-2)}
            };
            return Ok(notifications);
        }
    }
}
