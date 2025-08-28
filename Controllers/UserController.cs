using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLoginRegisterApi.Data;
using WebLoginRegisterApi.Model;

namespace WebLoginRegisterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UsersContext _context;

        public UserController(UsersContext context)
        {
            _context = context;
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
                return BadRequest(new { error = "Username and Password are required" });

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == model.Username);

            if (existingUser != null)
            {
                return Ok(new { message = "Already registered", username = existingUser.Username });
            }

            _context.Users.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User Login successfully", username = model.Username });
        }
    }
}
