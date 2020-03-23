using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using qizoErpApi.Models;
using qizoErpWebApiApp.Model.Masters;
using Microsoft.EntityFrameworkCore;

namespace qizoErpWebApiApp.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductToSparesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ProductToSparesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductToSpares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToSpare>>> GetProductToSpare()
        {
            return await _context.ProductToSpare.Include(b => b.PtsProduct)
                .Include(s => s.PtsSpare)
                            .ToListAsync();

            //return await _context.ProductToSpare.ToListAsync();
            //return await _context.ProductToSpare.Include()

        }

        // GET: api/ProductToSpares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToSpare>> GetProductToSpare(int id)
        {
            //var result = (from pts in _context.ProductToSpare
            //              join itm in _context.MItemMaster on pts.PtsProductId equals itm.Id
            //              join itmspare in _context.MItemMaster on pts.PtsSpareId equals itmspare.Id
            //              where pts.PtsProductId == id
            //              select new
            //              {
            //                  pts.Id,
            //                  pts.PtsProductId,
            //                  pts.PtsProduct.ItmName,
            //                  pts.PtsSpareId,
            //                  pts.PtsSpare.ItmDescription,
            //                  pts.PtsProduct.ItmCode,
            //                  pts.PtsUserId,
            //                  pts.PtsBranchId

            //              }).ToList();
            //return (Ok(result));

            var result = (from pts in _context.ProductToSpare
                          join itm in _context.MItemMaster on pts.PtsProductId equals itm.Id
                          join itmspare in _context.MItemMaster on pts.PtsSpareId equals itmspare.Id
                          let productName = pts.PtsProduct.ItmName
                          let sapareNameNew = pts.PtsSpare.ItmName
                          where pts.PtsProductId == id
                          orderby pts.Id
                          select new
                          {
                              pts.Id,
                              pts.PtsProductId,
                              productName,
                              pts.PtsSpareId,
                              sapareNameNew,
                              pts.PtsUserId,
                              pts.PtsBranchId
                          }).ToList();
            return (Ok(result));

            //var productToSpare = await _context.ProductToSpare.FindAsync(id);

            //if (productToSpare == null)
            //{
            //    return NotFound();
            //}

            //return productToSpare;
        }

        // PUT: api/ProductToSpares/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductToSpare(int id, ProductToSpare productToSpare)
        {
            if (id != productToSpare.Id)
            {
                return BadRequest();
            }

            _context.Entry(productToSpare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductToSpareExists(id))
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

        // POST: api/ProductToSpares
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProductToSpare>> PostProductToSpare(ProductToSpare productToSpare)
        {
            _context.ProductToSpare.Add(productToSpare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductToSpare", new { id = productToSpare.Id }, productToSpare);
        }

        // DELETE: api/ProductToSpares/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductToSpare>> DeleteProductToSpare(int id)
        {
            var productToSpare = await _context.ProductToSpare.FindAsync(id);
            if (productToSpare == null)
            {
                return NotFound();
            }

            _context.ProductToSpare.Remove(productToSpare);
            await _context.SaveChangesAsync();

            return productToSpare;
        }

        private bool ProductToSpareExists(int id)
        {
            return _context.ProductToSpare.Any(e => e.Id == id);
        }
    }
}
