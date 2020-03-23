using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qizoErpApi.Models;
using qizoErpWebApiApp.Model.Masters;

namespace qizoErpWebApiApp.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class MLedgerHeadsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MLedgerHeadsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MLedgerHeads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MLedgerHeads>>> GetMLedgerHeads()
        {
            return await _context.MLedgerHeads.ToListAsync();
        }

        // GET: api/MLedgerHeads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MLedgerHeads>> GetMLedgerHeads(decimal id)
        {
            var mLedgerHeads = await _context.MLedgerHeads.FindAsync(id);

            if (mLedgerHeads == null)
            {
                return NotFound();
            }

            return mLedgerHeads;
        }

        // PUT: api/MLedgerHeads/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMLedgerHeads(decimal id, MLedgerHeads mLedgerHeads)
        {
            if (id != mLedgerHeads.Id)
            {
                return BadRequest();
            }

            _context.Entry(mLedgerHeads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MLedgerHeadsExists(id))
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

        // POST: api/MLedgerHeads
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MLedgerHeads>> PostMLedgerHeads(MLedgerHeads mLedgerHeads)
        {
            _context.MLedgerHeads.Add(mLedgerHeads);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMLedgerHeads", new { id = mLedgerHeads.Id }, mLedgerHeads);
        }

        // DELETE: api/MLedgerHeads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MLedgerHeads>> DeleteMLedgerHeads(decimal id)
        {
            var mLedgerHeads = await _context.MLedgerHeads.FindAsync(id);
            if (mLedgerHeads == null)
            {
                return NotFound();
            }

            _context.MLedgerHeads.Remove(mLedgerHeads);
            await _context.SaveChangesAsync();

            return mLedgerHeads;
        }

        private bool MLedgerHeadsExists(decimal id)
        {
            return _context.MLedgerHeads.Any(e => e.Id == id);
        }
    }
}
