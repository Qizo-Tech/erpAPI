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
    public class MusersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MusersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Musers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musers>>> GetMusers()
        {
            return await _context.Musers.ToListAsync();
        }

        // GET: api/Musers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musers>> GetMusers(int id)
        {
            var musers = await _context.Musers.FindAsync(id);

            if (musers == null)
            {
                return NotFound();
            }

            return musers;
        }

        // PUT: api/Musers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusers(int id, Musers musers)
        {
            if (id != musers.Id)
            {
                return BadRequest();
            }

            _context.Entry(musers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusersExists(id))
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

        // POST: api/Musers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Musers>> PostMusers(Musers musers)
        {
            _context.Musers.Add(musers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusers", new { id = musers.Id }, musers);
        }

        // DELETE: api/Musers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Musers>> DeleteMusers(int id)
        {
            var musers = await _context.Musers.FindAsync(id);
            if (musers == null)
            {
                return NotFound();
            }

            _context.Musers.Remove(musers);
            await _context.SaveChangesAsync();

            return musers;
        }

        private bool MusersExists(int id)
        {
            return _context.Musers.Any(e => e.Id == id);
        }
    }
}
