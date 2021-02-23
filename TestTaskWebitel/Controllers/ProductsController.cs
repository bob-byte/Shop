using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TestTaskWebitel.Models;
using TestTaskWebitel.Models.Domain;
using TestTaskWebitel.Validators;

namespace TestTaskWebitel.Controllers
{
    public class ProductsController : ApiController
    {
        private ShopDbContext context = new ShopDbContext();

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return context.Products;
        }

        // GET: api/Products/4f40b1ae-da74-eb11-aa76-34de1a4796b2
        public async Task<IHttpActionResult> GetProduct(Guid id)
        {
            Product product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        // POST: api/Products
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductValidator validations = new ProductValidator();
            Boolean isValidProductOrder = validations.IsValidEnteredProductId(product);

            if(!isValidProductOrder)
            {
                return BadRequest("Entered ProductId of ProductOrders property have to be equal to Id column");
            }

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", product.Id, product);
        }

        // DELETE: api/Products/4f40b1ae-da74-eb11-aa76-34de1a4796b2
        public async Task<IHttpActionResult> DeleteProduct(Guid id)
        {
            Product product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}