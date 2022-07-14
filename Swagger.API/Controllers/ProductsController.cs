using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swagger.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swagger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SwaggerDBContext _context;

        public ProductsController(SwaggerDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Bu endpoint tüm ürünleri geri liste olarak geri döner.
        /// </summary>
        /// <remarks>
        /// örnek: https://localhost:44317/api/products
        /// </remarks>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        /// <summary>
        /// Bu endpoint verilen id sahip ürünü döner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="404">verilen id sahip ürün bulanamadı</response>
        /// <response code="200">verilen id sahip ürün var</response>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        /// <summary>
        /// Bu endpoint ürün ekler
        /// </summary>
        /// <remarks>
        /// örnek: product json: {"name":"kalem","price":20,"date":2.3.2022,"category":"kırtasiye"}
        /// </remarks>
        /// <param name="product">json product nesnesi</param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}