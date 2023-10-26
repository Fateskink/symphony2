using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using symphony2.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using symphony2.Models;

namespace symphony2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly SymphonyContext _context;

        public UserController(SymphonyContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.User.Where(u => u.DeletedAt == null).ToListAsync();

            if (users == null || users.Count == 0)
            {
                return NotFound();
            }

            return users;
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
                var user = await _context.User
                            .Where(u => u.Id == id && u.DeletedAt == null)
                            .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/User/SignUp
        [HttpPost("SignUp")]
        public ActionResult<string> SignUp([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.User.Any(u => u.Email == user.Email))
            {
                return BadRequest("Email already in use.");
            }

            // Encrypt the password using SHA1
            user.Password = PasswordUtils.EncryptPassword(user.Password);

            // Set CreatedAt and UpdatedAt timestamps to the current time
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            // Add the user to the database
            _context.User.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = await _context.User.Where(u => u.Id == id && u.DeletedAt == null)
                                            .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Birthday = updatedUser.Birthday;

            user.UpdatedAt = DateTime.Now;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Update success!");
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            // Set the DeletedAt timestamp to the current time
            user.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok("Delete success!");
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}