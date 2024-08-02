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
    public class InsuranceProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InsuranceProductsController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceProduct>>> GetInsuranceProducts()
        {
            if (_context.InsuranceProducts == null)
            {
                return NoContent();
            }

            return await _context.InsuranceProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceProduct>> GetInsuranceProductsById(int id)
        {
            if (_context.InsuranceProducts == null)
            {
                return NoContent();
            }

            var insuranceProduct = await _context.InsuranceProducts
                .Include(ip => ip.Category)
                .Include(ip => ip.Type)
                .Include(ip => ip.Package)
                .Include(ip => ip.AuthorizedUser)
                .Include(ip => ip.Users) // Include if you want to retrieve related users
                .FirstOrDefaultAsync(ip => ip.Id == id);

            if (insuranceProduct == null)
            {
                return NotFound();
            }

            // Convert int values to string representations
            var insuranceProductDto = new InsuranceProductsDto()
            {
                InsuranceName = insuranceProduct.InsuranceName,
                CategoryName = insuranceProduct.Category.CategoryName,
                TypeName = insuranceProduct.Type.TypeName,
                PackageName = insuranceProduct.Package.Name,
                AuthorizedName = insuranceProduct.AuthorizedUser.AuthorizedName,
                Description = insuranceProduct.Description,
            };

            return Ok(insuranceProductDto);
        }

        [HttpPost]
        public async Task<ActionResult<InsuranceProduct>> PostInsuranceProduct(InsuranceProductsDto insuranceProductDto)
        {
            if (_context.InsuranceProducts == null)
            {
                return NoContent();
            }

            var insuranceProduct = new InsuranceProduct()
            {
                InsuranceName = insuranceProductDto.InsuranceName,
                Description = insuranceProductDto.Description
            };

            if (!string.IsNullOrEmpty(insuranceProductDto.CategoryName))
            {
                var category = _context.Categories.FirstOrDefault(c => c.CategoryName == insuranceProductDto.CategoryName);
                if (category == null)
                {
                    return BadRequest($"Category with name '{insuranceProductDto.CategoryName}' not found.");
                }

                insuranceProduct.CategoryId = category.CategoryId;
            }

            if (!string.IsNullOrEmpty(insuranceProductDto.TypeName))
            {
                var type = _context.Types.FirstOrDefault(t => t.TypeName == insuranceProductDto.TypeName);

                if (type == null)
                {
                    return BadRequest($"Type with name '{insuranceProductDto.TypeName}' not found.");
                }

                insuranceProduct.TypeId = type.TypeId;
            }

            if (!string.IsNullOrEmpty(insuranceProductDto.PackageName))
            {
                var packageName = _context.Packages.FirstOrDefault(p => p.Name == insuranceProductDto.PackageName);

                if (packageName == null)
                {
                    return BadRequest($"Package with name '{insuranceProductDto.PackageName}' not found.");
                }

                insuranceProduct.PackageId = packageName.PackageId;
            }

            if (!string.IsNullOrEmpty(insuranceProductDto.AuthorizedName))
            {
                var authorizedUser = _context.AuthorizedUsers.FirstOrDefault(a => a.AuthorizedName == insuranceProductDto.AuthorizedName);

                if (authorizedUser == null)
                {
                    return BadRequest($"Authorized user with name '{insuranceProductDto.AuthorizedName}' not found.");
                }

                insuranceProduct.AuthorizedUserId = authorizedUser.AuthorizedId;
            }

            _context.InsuranceProducts.Add(insuranceProduct);
            await _context.SaveChangesAsync();

            return Ok(insuranceProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InsuranceProduct>> UpdateInsuranceProduct(int id, InsuranceProductsDto insuranceProductDto)
        {
            var product = _context.InsuranceProducts.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            product.InsuranceName = insuranceProductDto.InsuranceName;
            product.Description = insuranceProductDto.Description;

            if (!string.IsNullOrEmpty(insuranceProductDto.CategoryName))
            {
                var category = _context.Categories.FirstOrDefault(c => c.CategoryName == insuranceProductDto.CategoryName);
                if (category == null)
                {
                    return BadRequest($"Category with name '{insuranceProductDto.CategoryName}' not found.");
                }

                product.CategoryId = category.CategoryId;
            }

            if (!string.IsNullOrEmpty(insuranceProductDto.TypeName))
            {
                var type = _context.Types.FirstOrDefault(t => t.TypeName == insuranceProductDto.TypeName);

                if (type == null)
                {
                    return BadRequest($"Type with name '{insuranceProductDto.TypeName}' not found.");
                }

                product.TypeId = type.TypeId;
            }

            if (!string.IsNullOrEmpty(insuranceProductDto.PackageName))
            {
                var packageName = _context.Packages.FirstOrDefault(p => p.Name == insuranceProductDto.PackageName);

                if (packageName == null)
                {
                    return BadRequest($"Package with name '{insuranceProductDto.PackageName}' not found.");
                }

                product.PackageId = packageName.PackageId;
            }

            if (!string.IsNullOrEmpty(insuranceProductDto.AuthorizedName))
            {
                var authorizedUser = _context.AuthorizedUsers.FirstOrDefault(a => a.AuthorizedName == insuranceProductDto.AuthorizedName);

                if (authorizedUser == null)
                {
                    return BadRequest($"Authorized user with name '{insuranceProductDto.AuthorizedName}' not found.");
                }

                product.AuthorizedUserId = authorizedUser.AuthorizedId;
            }

            _context.Entry(product).State = EntityState.Modified;

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.InsuranceProducts == null)
            {
                return NotFound();
            }

            var product = await _context.InsuranceProducts.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.InsuranceProducts.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
