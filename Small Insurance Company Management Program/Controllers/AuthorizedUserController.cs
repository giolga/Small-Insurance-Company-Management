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
    public class AuthorizedUserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorizedUserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorizedUser>>> GetAuthorizedUser()
        {
            if (_context.AuthorizedUsers == null)
            {
                return NotFound();
            }

            return await _context.AuthorizedUsers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorizedUser>> GetById(int id)
        {
            if (_context.AuthorizedUsers == null)
            {
                return NotFound();
            }

            var authorizedUser = _context.AuthorizedUsers.FirstOrDefault(u => u.AuthorizedId == id);

            if (authorizedUser == null)
            {
                return NotFound();
            }

            return authorizedUser;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorizedUser>> PostAuthorizedUser(AuthorizedUserDTO user)
        {
            if (_context.AuthorizedUsers == null)
            {
                return Problem("Entity set 'AppDbContext.AuthorizedUsers'  is null.");
            }

            var authorized = new AuthorizedUser()
            {
                AuthorizedName = user.AuthorizedUserName
            };

            _context.AuthorizedUsers.Add(authorized);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthorizedUser", new { id = authorized.AuthorizedId }, authorized);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorizedUser>> UpdateAuthorizedUser(int id, AuthorizedUser user)
        {
            if (id != user.AuthorizedId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorizedUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }


        [HttpDelete]
        public async Task<ActionResult<AuthorizedUser>> DeleteAuthorizedUser(int id)
        {
            if(_context.AuthorizedUsers == null)
            {
                return NoContent();
            }

            var user = await _context.AuthorizedUsers.FirstOrDefaultAsync(u => u.AuthorizedId == id);

            if(user == null)
            {
                return BadRequest();
            }

            _context.AuthorizedUsers.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("User successfully deleted");
        }

        private bool AuthorizedUserExists(int id)
        {
            return (_context.AuthorizedUsers?.Any(e => e.AuthorizedId == id)).GetValueOrDefault();
        }
    }
}
