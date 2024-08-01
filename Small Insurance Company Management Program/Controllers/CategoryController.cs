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
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }

            return await _context.Categories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return Problem("Entity set 'AppDbContext.Category'  is null.");
            }

            var category = new Category()
            {
                CategoryName = categoryDto.CategoryName
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(Category myCategory, int id)
        {
            if (id != myCategory.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(myCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            if(_context.Categories ==  null)
            {
                return NoContent();
            }

            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if(category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok($"Category with the id {category.CategoryId} deleted successfully");
        }

        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(c => c.CategoryId == id)).GetValueOrDefault();
        }

    }
}
