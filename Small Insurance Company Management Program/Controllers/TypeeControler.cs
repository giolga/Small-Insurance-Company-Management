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
    public class TypeeControler : ControllerBase
    {
        private readonly AppDbContext _context;

        public TypeeControler(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Typee>>> GetAllType()
        {
            if (_context.Types == null)
            {
                return NoContent();
            }

            var types = await _context.Types.ToListAsync();

            return types;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Typee>> GetTypeById(int id)
        {
            if (_context.Types == null)
            {
                return NoContent();
            }

            var type = _context.Types.FirstOrDefault(t => t.TypeId == id);

            if (type == null)
            {
                return NoContent();
            }

            return Ok(type);
        }

        [HttpPost]
        public async Task<ActionResult<TypeeDto>> PostType(TypeeDto type)
        {
            if (type == null)
            {
                return Problem("Entity set 'AppDbContext.Types'  is null.");
            }

            var typeAdd = new Typee()
            {
                TypeName = type.TypeName
            };

            _context.Types.Add(typeAdd);
            await _context.SaveChangesAsync();

            return Ok(typeAdd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Typee>> UpdateType(int id, Typee type)
        {
            if (id != type.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Typee>> DeleteType(int id)
        {
            if(_context.Types == null)
            {
                return NoContent();
            }

            var type = _context.Types.FirstOrDefault(t => t.TypeId == id);

            if (type == null)
            {
                return NotFound();
            }

            _context.Types.Remove(type);
            await _context.SaveChangesAsync();

            return Ok($"Type with the id {type.TypeId} deleted successfully");
        }

        private bool TypeExists(int id)
        {
            return (_context.Types?.Any(t => t.TypeId == id)).GetValueOrDefault();
        }
    }
}
