using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TestTaskWebitel.Models;
using TestTaskWebitel.Models.Domain;
using TestTaskWebitel.Validators;

namespace TestTaskWebitel.Controllers
{
    public class ProductOrdersController : ApiController
    {
        private ShopDbContext context = new ShopDbContext();

        // GET: api/ProductOrders
        public IQueryable<ProductOrder> GetProductOrders()
        {
            return context.ProductOrders;
        }

        // GET: api/ProductOrders/4f40b1ae-da74-eb11-aa76-34de1a4796b2
        public async Task<IHttpActionResult> GetProductOrder(Guid id)
        {
            ProductOrder productOrder = await context.ProductOrders.FindAsync(id);
            if (productOrder == null)
            {
                return NotFound();
            }

            return Ok(productOrder);
        }

        // POST: api/ProductOrders
        public async Task<IHttpActionResult> PostProductOrder(ProductOrder productOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductOrdersValidator validations = new ProductOrdersValidator();
            
            if(!validations.IsValid(productOrder))
            {
                return BadRequest("Don\'t set properties Product and Order. Use ProductId and OrderId");
            }

            context.ProductOrders.Add(productOrder);
            await context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", productOrder.Id, productOrder);
        }

        // DELETE: api/ProductOrders/4f40b1ae-da74-eb11-aa76-34de1a4796b2
        public async Task<IHttpActionResult> DeleteProductOrder(Guid id)
        {
            ProductOrder productOrder = await context.ProductOrders.FindAsync(id);
            if (productOrder == null)
            {
                return NotFound();
            }

            context.ProductOrders.Remove(productOrder);
            await context.SaveChangesAsync();

            return Ok(productOrder);
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