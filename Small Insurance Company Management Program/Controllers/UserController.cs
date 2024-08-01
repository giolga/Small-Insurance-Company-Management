using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Small_Insurance_Company_Management_Program.Data;
using Small_Insurance_Company_Management_Program.DTOs;
using Small_Insurance_Company_Management_Program.Models;

namespace Small_Insurance_Company_Management_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NoContent();
            }

            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            if (_context.Users == null)
            {
                return NoContent();
            }

            var user = _context.Users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDto userDto)
        {
            if (_context.Users == null)
            {
                return NoContent();
            }

            var user = new User()
            {
                UserName = userDto.UserName,
                UserLastName = userDto.UserLastName,
            };

            if (!string.IsNullOrWhiteSpace(userDto.InsuranceProductName))
            {
                var product = _context.InsuranceProducts.FirstOrDefault(i => i.InsuranceName == userDto.InsuranceProductName);

                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    user.InsuranceId = product.Id;
                }
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(int id, UserDto userDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = userDto.UserName;
            user.UserLastName = userDto.UserLastName;

            if (!string.IsNullOrWhiteSpace(userDto.InsuranceProductName))
            {
                var insurance = _context.InsuranceProducts.FirstOrDefault(i => i.InsuranceName == userDto.InsuranceProductName);

                if (insurance == null)
                {
                    return BadRequest();
                }

                user.InsuranceId = insurance.Id;
            }

            _context.Entry(user).State = EntityState.Modified;
            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NoContent();
            }

            var user = _context.Users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
