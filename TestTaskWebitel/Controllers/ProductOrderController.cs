using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TestTaskWebitel.Models;
using TestTaskWebitel.Models.Domain;

namespace TestTaskWebitel.Controllers
{
    public class ProductOrderController : ApiController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: api/ProductOrder
        public IQueryable<ProductOrder> GetProductOrders()
        {
            return db.ProductOrders;
        }

        // GET: api/ProductOrder/5
        [ResponseType(typeof(ProductOrder))]
        public async Task<IHttpActionResult> GetProductOrder(Guid id)
        {
            ProductOrder productOrder = await db.ProductOrders.FindAsync(id);
            if (productOrder == null)
            {
                return NotFound();
            }

            return Ok(productOrder);
        }

        // PUT: api/ProductOrder/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductOrder(Guid id, ProductOrder productOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productOrder.Id)
            {
                return BadRequest();
            }

            db.Entry(productOrder).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductOrder
        [ResponseType(typeof(ProductOrder))]
        public async Task<IHttpActionResult> PostProductOrder(ProductOrder productOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductOrders.Add(productOrder);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductOrderExists(productOrder.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productOrder.Id }, productOrder);
        }

        // DELETE: api/ProductOrder/5
        [ResponseType(typeof(ProductOrder))]
        public async Task<IHttpActionResult> DeleteProductOrder(Guid id)
        {
            ProductOrder productOrder = await db.ProductOrders.FindAsync(id);
            if (productOrder == null)
            {
                return NotFound();
            }

            db.ProductOrders.Remove(productOrder);
            await db.SaveChangesAsync();

            return Ok(productOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductOrderExists(Guid id)
        {
            return db.ProductOrders.Count(e => e.Id == id) > 0;
        }
    }
}