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
    public class MledgerGroupsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MledgerGroupsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MledgerGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MledgerGroup>>> GetMledgerGroup()
        {
            return await _context.MledgerGroup.ToListAsync();
        }

        // GET: api/MledgerGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MledgerGroup>> GetMledgerGroup(int id)
        {
            var mledgerGroup = await _context.MledgerGroup.FindAsync(id);

            if (mledgerGroup == null)
            {
                return NotFound();
            }

            return mledgerGroup;
        }

        // PUT: api/MledgerGroups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMledgerGroup(int id, MledgerGroup mledgerGroup)
        {
            if (id != mledgerGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(mledgerGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MledgerGroupExists(id))
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

        // POST: api/MledgerGroups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MledgerGroup>> PostMledgerGroup(MledgerGroup mledgerGroup)
        {
            _context.MledgerGroup.Add(mledgerGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMledgerGroup", new { id = mledgerGroup.Id }, mledgerGroup);
        }

        // DELETE: api/MledgerGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MledgerGroup>> DeleteMledgerGroup(int id)
        {
            var mledgerGroup = await _context.MledgerGroup.FindAsync(id);
            if (mledgerGroup == null)
            {
                return NotFound();
            }

            _context.MledgerGroup.Remove(mledgerGroup);
            await _context.SaveChangesAsync();

            return mledgerGroup;
        }

        private bool MledgerGroupExists(int id)
        {
            return _context.MledgerGroup.Any(e => e.Id == id);
        }
    }
}
