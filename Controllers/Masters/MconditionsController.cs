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
    public class MconditionsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MconditionsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Mconditions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mconditions>>> GetMconditions()
        {
            return await _context.Mconditions.ToListAsync();
        }

        // GET: api/Mconditions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mconditions>> GetMconditions(int id)
        {
            var mconditions = await _context.Mconditions.FindAsync(id);

            if (mconditions == null)
            {
                return NotFound();
            }

            return mconditions;
        }

        // PUT: api/Mconditions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMconditions(int id, Mconditions mconditions)
        {
            if (id != mconditions.Id)
            {
                return BadRequest();
            }

            _context.Entry(mconditions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MconditionsExists(id))
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

        // POST: api/Mconditions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Mconditions>> PostMconditions(Mconditions mconditions)
        {
            _context.Mconditions.Add(mconditions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMconditions", new { id = mconditions.Id }, mconditions);
        }

        // DELETE: api/Mconditions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mconditions>> DeleteMconditions(int id)
        {
            var mconditions = await _context.Mconditions.FindAsync(id);
            if (mconditions == null)
            {
                return NotFound();
            }

            _context.Mconditions.Remove(mconditions);
            await _context.SaveChangesAsync();

            return mconditions;
        }

        private bool MconditionsExists(int id)
        {
            return _context.Mconditions.Any(e => e.Id == id);
        }
    }
}
