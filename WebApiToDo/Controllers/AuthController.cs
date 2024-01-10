
using LMSData.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LMSDBContext _context;
        public AuthController(LMSDBContext context)
        {
            _context = context;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromBody] User userCredentials)
        {
            if (userCredentials == null || string.IsNullOrWhiteSpace(userCredentials.Email) || string.IsNullOrWhiteSpace(userCredentials.Password))
            {
                return BadRequest("Invalid input");
            }
            var user = await _context.Users
            .Where(u => u.Email == userCredentials.Email && u.Password == userCredentials.Password)
            .FirstOrDefaultAsync();

            if (user != null)
            {
                return Ok(true); // Kullanıcı mevcut
            }

            else
            {
                return Ok(false); // Kullanıcı mevcut değil
            }

        }

        [HttpPost("GetUserId")]
        public async Task<IActionResult> GetUserId([FromBody] User userCredentials)
        {
            if (userCredentials == null || string.IsNullOrWhiteSpace(userCredentials.Email))
            {
                return BadRequest("Invalid input");
            }

            var user = await _context.Users
                .Where(u => u.Email == userCredentials.Email)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                return Ok(user.Id);
            }
            else { return BadRequest("Invalid input"); }
        }

        [HttpPost("GetName")]
        public async Task<IActionResult> GetName([FromBody] User userCredentials)
        {
            if (userCredentials == null || string.IsNullOrWhiteSpace(userCredentials.Email))
            {
                return BadRequest("Invalid input");
            }

            var user = await _context.Users
                .Where(u => u.Email == userCredentials.Email)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                return Ok(user.Name);
            }
            else { return BadRequest("Invalid input"); }
        }

    }
}
