using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qizoErpApi.Models;
using qizoErpWebApiApp.Model.Masters;

namespace qizoErpWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MItemSubGroupsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MItemSubGroupsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MItemSubGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MItemSubGroup>>> GetMItemSubGroup()
        {
            return await _context.MItemSubGroup.ToListAsync();
        }

        // GET: api/MItemSubGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MItemSubGroup>> GetMItemSubGroup(int id)
        {
            var mItemSubGroup = await _context.MItemSubGroup.FindAsync(id);

            if (mItemSubGroup == null)
            {
                return NotFound();
            }

            return mItemSubGroup;
        }

        // PUT: api/MItemSubGroups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMItemSubGroup(int id, MItemSubGroup mItemSubGroup)
        {
            if (id != mItemSubGroup.IsgId)
            {
                return BadRequest();
            }

            _context.Entry(mItemSubGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MItemSubGroupExists(id))
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

        // POST: api/MItemSubGroups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MItemSubGroup>> PostMItemSubGroup(MItemSubGroup mItemSubGroup)
        {
            _context.MItemSubGroup.Add(mItemSubGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMItemSubGroup", new { id = mItemSubGroup.IsgId }, mItemSubGroup);
        }

        // DELETE: api/MItemSubGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MItemSubGroup>> DeleteMItemSubGroup(int id)
        {
            var mItemSubGroup = await _context.MItemSubGroup.FindAsync(id);
            if (mItemSubGroup == null)
            {
                return NotFound();
            }

            _context.MItemSubGroup.Remove(mItemSubGroup);
            await _context.SaveChangesAsync();

            return mItemSubGroup;
        }

        private bool MItemSubGroupExists(int id)
        {
            return _context.MItemSubGroup.Any(e => e.IsgId == id);
        }
    }
}
