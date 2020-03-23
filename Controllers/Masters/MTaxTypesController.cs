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
    public class MTaxTypesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MTaxTypesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MTaxTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MTaxType>>> GetMTaxType()
        {
            return await _context.MTaxType.ToListAsync();
        }

        // GET: api/MTaxTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MTaxType>> GetMTaxType(int id)
        {
            var mTaxType = await _context.MTaxType.FindAsync(id);

            if (mTaxType == null)
            {
                return NotFound();
            }

            return mTaxType;
        }

        // PUT: api/MTaxTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMTaxType(int id, MTaxType mTaxType)
        {
            if (id != mTaxType.TxTypId)
            {
                return BadRequest();
            }

            _context.Entry(mTaxType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MTaxTypeExists(id))
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

        // POST: api/MTaxTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MTaxType>> PostMTaxType(MTaxType mTaxType)
        {
            _context.MTaxType.Add(mTaxType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMTaxType", new { id = mTaxType.TxTypId }, mTaxType);
        }

        // DELETE: api/MTaxTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MTaxType>> DeleteMTaxType(int id)
        {
            var mTaxType = await _context.MTaxType.FindAsync(id);
            if (mTaxType == null)
            {
                return NotFound();
            }

            _context.MTaxType.Remove(mTaxType);
            await _context.SaveChangesAsync();

            return mTaxType;
        }

        private bool MTaxTypeExists(int id)
        {
            return _context.MTaxType.Any(e => e.TxTypId == id);
        }
    }
}
