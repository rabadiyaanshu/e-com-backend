using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebLoginRegisterApi.Models;

namespace WebLoginRegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessages()
        {
            var messages = new List<object>
            {
                new {
                    sender = "Admin",
                    messageText = "Welcome to the dashboard!",
                    createdAt = DateTime.Now
                },
                new {
                    sender = "Support",
                    messageText = "Don't forget to check your updates.",
                    createdAt = DateTime.Now.AddMinutes(-30)
                }
            };

            return Ok(messages);
        }
    }
}
