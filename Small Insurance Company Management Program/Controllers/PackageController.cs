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
    public class PackageController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PackageController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackages()
        {
            if (_context.Packages == null)
            {
                return NoContent();
            }

            return await _context.Packages.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackageById(int id)
        {
            if (_context.Packages == null)
            {
                return NoContent();
            }

            var package = _context.Packages.FirstOrDefault(p => p.PackageId == id);

            if (package == null)
            {
                return NotFound();
            }

            return Ok(package);
        }

        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(PackageDto packageDto)
        {
            if (_context.Packages == null)
            {
                return Problem("Entity set 'AppDbContext.Package' is null.");
            }

            var package = new Package()
            {
                Name = packageDto.Name,
            };

            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
            return Ok(package);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Package>> UpdatePackage(int id, Package package)
        {
            if (id != package.PackageId)
            {
                return Problem("id and package id doesn't match!");
            }

            _context.Entry(package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!packageExists(id))
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
        public async Task<ActionResult<Package>> DeletePackage(int id)
        {
            if(_context.Packages == null)
            {
                return NoContent();
            }

            var package = _context.Packages.FirstOrDefault(p => p.PackageId == id);

            if(package == null)
            {
                return NoContent();
            }

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();

            return Ok(package);
        }

        private bool packageExists(int id)
        {
            return (_context.Packages?.Any(p => p.PackageId == id)).GetValueOrDefault();
        }
    }
}
