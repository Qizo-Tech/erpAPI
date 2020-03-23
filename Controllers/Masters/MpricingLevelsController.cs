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
    public class MpricingLevelsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MpricingLevelsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MpricingLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MpricingLevel>>> GetMpricingLevel()
        {
            return await _context.MpricingLevel.ToListAsync();
        }

        // GET: api/MpricingLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MpricingLevel>> GetMpricingLevel(int id)
        {
            var mpricingLevel = await _context.MpricingLevel.FindAsync(id);

            if (mpricingLevel == null)
            {
                return NotFound();
            }

            return mpricingLevel;
        }

        // PUT: api/MpricingLevels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMpricingLevel(int id, MpricingLevel mpricingLevel)
        {
            if (id != mpricingLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(mpricingLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MpricingLevelExists(id))
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

        // POST: api/MpricingLevels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MpricingLevel>> PostMpricingLevel(MpricingLevel mpricingLevel)
        {
            _context.MpricingLevel.Add(mpricingLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMpricingLevel", new { id = mpricingLevel.Id }, mpricingLevel);
        }

        // DELETE: api/MpricingLevels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MpricingLevel>> DeleteMpricingLevel(int id)
        {
            var mpricingLevel = await _context.MpricingLevel.FindAsync(id);
            if (mpricingLevel == null)
            {
                return NotFound();
            }

            _context.MpricingLevel.Remove(mpricingLevel);
            await _context.SaveChangesAsync();

            return mpricingLevel;
        }

        private bool MpricingLevelExists(int id)
        {
            return _context.MpricingLevel.Any(e => e.Id == id);
        }
    }
}
