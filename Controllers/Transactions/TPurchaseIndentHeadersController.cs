using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qizoErpApi.Models;
using qizoErpWebApiApp.Model.Transactions;

namespace qizoErpWebApiApp.Controllers.Transactions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TPurchaseIndentHeadersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TPurchaseIndentHeadersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/TPurchaseIndentHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TPurchaseIndentHeader>>> GetTPurchaseIndentHeader()
        {
            return await _context.TPurchaseIndentHeader.ToListAsync();
        }

        // GET: api/TPurchaseIndentHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TPurchaseIndentHeader>> GetTPurchaseIndentHeader(int id)
        {
            var tPurchaseIndentHeader = await _context.TPurchaseIndentHeader.FindAsync(id);

            if (tPurchaseIndentHeader == null)
            {
                return NotFound();
            }

            return tPurchaseIndentHeader;
        }

        // PUT: api/TPurchaseIndentHeaders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTPurchaseIndentHeader(int id, TPurchaseIndentHeader tPurchaseIndentHeader)
        {
            if (id != tPurchaseIndentHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(tPurchaseIndentHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TPurchaseIndentHeaderExists(id))
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

        // POST: api/TPurchaseIndentHeaders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TPurchaseIndentHeader>> PostTPurchaseIndentHeader(TPurchaseIndentHeader tPurchaseIndentHeader)
        {
            _context.TPurchaseIndentHeader.Add(tPurchaseIndentHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTPurchaseIndentHeader", new { id = tPurchaseIndentHeader.Id }, tPurchaseIndentHeader);
        }

        // DELETE: api/TPurchaseIndentHeaders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TPurchaseIndentHeader>> DeleteTPurchaseIndentHeader(int id)
        {
            var tPurchaseIndentHeader = await _context.TPurchaseIndentHeader.FindAsync(id);
            if (tPurchaseIndentHeader == null)
            {
                return NotFound();
            }

            _context.TPurchaseIndentHeader.Remove(tPurchaseIndentHeader);
            await _context.SaveChangesAsync();

            return tPurchaseIndentHeader;
        }

        private bool TPurchaseIndentHeaderExists(int id)
        {
            return _context.TPurchaseIndentHeader.Any(e => e.Id == id);
        }
    }
}
