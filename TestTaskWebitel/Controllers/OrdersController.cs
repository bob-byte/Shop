using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TestTaskWebitel.Models;
using TestTaskWebitel.Models.Domain;
using TestTaskWebitel.Validators;

namespace TestTaskWebitel.Controllers
{
    public class OrdersController : ApiController
    {
        private ShopDbContext context = new ShopDbContext();

        // GET: api/Orders
        public IQueryable<Order> GetOrders()
        {
            return context.Orders.Include(c => c.ProductOrders);
        }

        // GET: api/Orders/4f40b1ae-da74-eb11-aa76-34de1a4796b2
        public async Task<IHttpActionResult> GetOrder(Guid id)
        {
            Order order = await context.Orders.Include(c => c.ProductOrders).SingleAsync(c => c.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/Orders
        public async Task<IHttpActionResult> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrderValidator validations = new OrderValidator();
            Boolean isValidProductOrder = validations.IsValidEnteredOrderId(order);

            if (!isValidProductOrder)
            {
                return BadRequest("Entered OrderId of ProductOrders property have to be equal to Id column");
            }

            context.Orders.Add(order);
            await context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", order.Id, order);
        }

        // DELETE: api/Orders/4f40b1ae-da74-eb11-aa76-34de1a4796b2
        public async Task<IHttpActionResult> DeleteOrder(Guid id)
        {
            Order order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            context.Orders.Remove(order);
            await context.SaveChangesAsync();

            return Ok(order);
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