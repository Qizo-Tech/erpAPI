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
    public class MIadditionalTaxesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MIadditionalTaxesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MIadditionalTaxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MIadditionalTax>>> GetMIadditionalTax()
        {
            return await _context.MIadditionalTax.ToListAsync();
        }

        // GET: api/MIadditionalTaxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MIadditionalTax>> GetMIadditionalTax(int id)
        {
            var mIadditionalTax = await _context.MIadditionalTax.FindAsync(id);

            if (mIadditionalTax == null)
            {
                return NotFound();
            }

            return mIadditionalTax;
        }

        // PUT: api/MIadditionalTaxes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMIadditionalTax(int id, MIadditionalTax mIadditionalTax)
        {
            if (id != mIadditionalTax.AtId)
            {
                return BadRequest();
            }

            _context.Entry(mIadditionalTax).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MIadditionalTaxExists(id))
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

        // POST: api/MIadditionalTaxes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MIadditionalTax>> PostMIadditionalTax(MIadditionalTax mIadditionalTax)
        {
            _context.MIadditionalTax.Add(mIadditionalTax);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMIadditionalTax", new { id = mIadditionalTax.AtId }, mIadditionalTax);
        }

        // DELETE: api/MIadditionalTaxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MIadditionalTax>> DeleteMIadditionalTax(int id)
        {
            var mIadditionalTax = await _context.MIadditionalTax.FindAsync(id);
            if (mIadditionalTax == null)
            {
                return NotFound();
            }

            _context.MIadditionalTax.Remove(mIadditionalTax);
            await _context.SaveChangesAsync();

            return mIadditionalTax;
        }

        private bool MIadditionalTaxExists(int id)
        {
            return _context.MIadditionalTax.Any(e => e.AtId == id);
        }
    }
}
