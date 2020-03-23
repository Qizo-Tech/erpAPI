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
    public class MProductTypeStaticsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MProductTypeStaticsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MProductTypeStatics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MProductTypeStatic>>> GetMProductTypeStatic()
        {
            return await _context.MProductTypeStatic.ToListAsync();
        }

        // GET: api/MProductTypeStatics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MProductTypeStatic>> GetMProductTypeStatic(int id)
        {
            var mProductTypeStatic = await _context.MProductTypeStatic.FindAsync(id);

            if (mProductTypeStatic == null)
            {
                return NotFound();
            }

            return mProductTypeStatic;
        }

        // PUT: api/MProductTypeStatics/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMProductTypeStatic(int id, MProductTypeStatic mProductTypeStatic)
        {
            if (id != mProductTypeStatic.Id)
            {
                return BadRequest();
            }

            _context.Entry(mProductTypeStatic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MProductTypeStaticExists(id))
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

        // POST: api/MProductTypeStatics
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MProductTypeStatic>> PostMProductTypeStatic(MProductTypeStatic mProductTypeStatic)
        {
            _context.MProductTypeStatic.Add(mProductTypeStatic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMProductTypeStatic", new { id = mProductTypeStatic.Id }, mProductTypeStatic);
        }

        // DELETE: api/MProductTypeStatics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MProductTypeStatic>> DeleteMProductTypeStatic(int id)
        {
            var mProductTypeStatic = await _context.MProductTypeStatic.FindAsync(id);
            if (mProductTypeStatic == null)
            {
                return NotFound();
            }

            _context.MProductTypeStatic.Remove(mProductTypeStatic);
            await _context.SaveChangesAsync();

            return mProductTypeStatic;
        }

        private bool MProductTypeStaticExists(int id)
        {
            return _context.MProductTypeStatic.Any(e => e.Id == id);
        }
    }
}
