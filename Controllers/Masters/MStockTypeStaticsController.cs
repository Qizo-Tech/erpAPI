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
    public class MStockTypeStaticsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MStockTypeStaticsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MStockTypeStatics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MStockTypeStatic>>> GetMStockTypeStatic()
        {
            return await _context.MStockTypeStatic.ToListAsync();
        }

        // GET: api/MStockTypeStatics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MStockTypeStatic>> GetMStockTypeStatic(int id)
        {
            var mStockTypeStatic = await _context.MStockTypeStatic.FindAsync(id);

            if (mStockTypeStatic == null)
            {
                return NotFound();
            }

            return mStockTypeStatic;
        }

        // PUT: api/MStockTypeStatics/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMStockTypeStatic(int id, MStockTypeStatic mStockTypeStatic)
        {
            if (id != mStockTypeStatic.Id)
            {
                return BadRequest();
            }

            _context.Entry(mStockTypeStatic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MStockTypeStaticExists(id))
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

        // POST: api/MStockTypeStatics
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MStockTypeStatic>> PostMStockTypeStatic(MStockTypeStatic mStockTypeStatic)
        {
            _context.MStockTypeStatic.Add(mStockTypeStatic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMStockTypeStatic", new { id = mStockTypeStatic.Id }, mStockTypeStatic);
        }

        // DELETE: api/MStockTypeStatics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MStockTypeStatic>> DeleteMStockTypeStatic(int id)
        {
            var mStockTypeStatic = await _context.MStockTypeStatic.FindAsync(id);
            if (mStockTypeStatic == null)
            {
                return NotFound();
            }

            _context.MStockTypeStatic.Remove(mStockTypeStatic);
            await _context.SaveChangesAsync();

            return mStockTypeStatic;
        }

        private bool MStockTypeStaticExists(int id)
        {
            return _context.MStockTypeStatic.Any(e => e.Id == id);
        }
    }
}
