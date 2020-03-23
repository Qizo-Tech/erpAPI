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
    public class MuserGroupsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MuserGroupsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MuserGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuserGroups>>> GetMuserGroups()
        {
            return await _context.MuserGroups.ToListAsync();
        }

        // GET: api/MuserGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MuserGroups>> GetMuserGroups(int id)
        {
            var muserGroups = await _context.MuserGroups.FindAsync(id);

            if (muserGroups == null)
            {
                return NotFound();
            }

            return muserGroups;
        }

        // PUT: api/MuserGroups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuserGroups(int id, MuserGroups muserGroups)
        {
            if (id != muserGroups.Id)
            {
                return BadRequest();
            }

            _context.Entry(muserGroups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuserGroupsExists(id))
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

        // POST: api/MuserGroups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MuserGroups>> PostMuserGroups(MuserGroups muserGroups)
        {
            _context.MuserGroups.Add(muserGroups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMuserGroups", new { id = muserGroups.Id }, muserGroups);
        }

        // DELETE: api/MuserGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MuserGroups>> DeleteMuserGroups(int id)
        {
            var muserGroups = await _context.MuserGroups.FindAsync(id);
            if (muserGroups == null)
            {
                return NotFound();
            }

            _context.MuserGroups.Remove(muserGroups);
            await _context.SaveChangesAsync();

            return muserGroups;
        }

        private bool MuserGroupsExists(int id)
        {
            return _context.MuserGroups.Any(e => e.Id == id);
        }
    }
}
