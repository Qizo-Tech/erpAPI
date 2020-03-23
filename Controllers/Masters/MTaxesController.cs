using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qizoErpApi.Models;
using qizoErpWebApiApp.Model.Masters;

namespace qizoErpWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MTaxesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MTaxesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MTaxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MTax>>> GetMTax()
        {
            return await _context.MTax.ToListAsync();
        }

        // GET: api/MTaxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MTax>> GetMTax(int id)
        {
            var mTax = await _context.MTax.FindAsync(id);

            if (mTax == null)
            {
                return NotFound();
            }

            return mTax;
        }

        // PUT: api/MTaxes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMTax(int id, MTax mTax)
        {
            if (id != mTax.TxId)
            {
                return BadRequest();
            }

            _context.Entry(mTax).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MTaxExists(id))
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

        // POST: api/MTaxes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MTax>> PostMTax(MTax mTax)
        {
            _context.MTax.Add(mTax);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMTax", new { id = mTax.TxId }, mTax);
        }

        // DELETE: api/MTaxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MTax>> DeleteMTax(int id)
        {
            var mTax = await _context.MTax.FindAsync(id);
            if (mTax == null)
            {
                return NotFound();
            }

            _context.MTax.Remove(mTax);
            await _context.SaveChangesAsync();

            return mTax;
        }

        private bool MTaxExists(int id)
        {
            return _context.MTax.Any(e => e.TxId == id);
        }
    }
}
