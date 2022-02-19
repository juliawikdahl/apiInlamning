#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InlamningAPI;
using InlamningAPI.Models.Entities;
using InlamningAPI.Models;
using InlamningAPI.Filters;

namespace InlamningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[UseApiKey]
    public class Product : ControllerBase
    {
        private readonly SqlContext _context;

        public Product(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var items = new List<ProductModel>();

            foreach (var item in await _context.Products.ToListAsync())
            {
                var categoryName = await _context.Categories.Where(c => c.Id == item.CategoryId).Select(c => c.CategoryName).FirstOrDefaultAsync();
                items.Add(new ProductModel(item.Id, item.Name, item.Description, item.Price, categoryName));
            }
               

            return items;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProduct(int id)
        {
            var Product = await _context.Products.FindAsync(id);

            if (Product == null || Product.Removed)
            {
                return NotFound();
            }
            var categoryName = await _context.Categories.Where(c => c.Id == Product.CategoryId).Select(c => c.CategoryName).FirstOrDefaultAsync();
            return new ProductModel(Product.Id, Product.Name, Product.Description, Product.Price, categoryName);
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductEntity(int id, ProductUpdateModel model)
        {
           

            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
                return NotFound();

            var categoryName = await _context.Categories.FindAsync(model.CategoryId);
            if (categoryName == null)
                return NotFound();

            Product.Name = model.Name;
            Product.Description = model.Description;
            Product.Price = model.Price;
            Product.CategoryId = model.CategoryId;

            _context.Entry(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductModel>> PostProductEntity(ProductCreateModel model)
        {
            if (await _context.Products.AnyAsync(x => x.Name == model.Name))
                return Conflict("A Product with the same Name already exists.");

            var Product = new ProductEntity(model.Name, model.Description, model.Price, model.CategoryId);
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            var categoryName = await _context.Categories.Where(c => c.Id == Product.CategoryId).Select(c => c.CategoryName).FirstOrDefaultAsync();
            return CreatedAtAction("PostProductEntity", new { id = Product.Id }, new ProductModel(Product.Id, Product.Name, Product.Description, Product.Price, categoryName));
        }




        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            productEntity.Removed = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}

