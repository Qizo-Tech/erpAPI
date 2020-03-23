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
    public class MstatesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MstatesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Mstates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mstate>>> GetMstate()
        {
            return await _context.Mstate.ToListAsync();
        }

        // GET: api/Mstates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mstate>> GetMstate(int id)
        {
            var mstate = await _context.Mstate.FindAsync(id);

            if (mstate == null)
            {
                return NotFound();
            }

            return mstate;
        }

        // PUT: api/Mstates/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMstate(int id, Mstate mstate)
        {
            if (id != mstate.Id)
            {
                return BadRequest();
            }

            _context.Entry(mstate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MstateExists(id))
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

        // POST: api/Mstates
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Mstate>> PostMstate(Mstate mstate)
        {
            _context.Mstate.Add(mstate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMstate", new { id = mstate.Id }, mstate);
        }

        // DELETE: api/Mstates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mstate>> DeleteMstate(int id)
        {
            var mstate = await _context.Mstate.FindAsync(id);
            if (mstate == null)
            {
                return NotFound();
            }

            _context.Mstate.Remove(mstate);
            await _context.SaveChangesAsync();

            return mstate;
        }

        private bool MstateExists(int id)
        {
            return _context.Mstate.Any(e => e.Id == id);
        }
    }
}
