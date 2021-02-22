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
    public class ProductsController : ApiController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: api/Products
        //public IQueryable<Product> GetProducts()
        //{
        //    return db.Products.Include(p => p.Orders);
        //}

        // GET: api/Products/5
        //[ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> GetProduct(Guid id)
        //{
        //    Product product = await db.Products.Include(p => p.Orders).SingleAsync(p => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}


        //var orders = db.Orders.Include(c => c.Products).ToList();
        //foreach (var item in orders)
        //{
        //    var products = item.Products.ToList();
        //    foreach (var productOfOrder in products)
        //    {
        //        if(productOfOrder.Id == id)
        //        {
        //            product.Orders.Add(item);
        //        }
        //    }
        //}

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(Guid id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(Guid id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(Guid id)
        {
            return db.Products.Count(p => p.Id == id) > 0;
        }
    }
}