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
    public class MItemGroupsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MItemGroupsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MItemGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MItemGroup>>> GetMItemGroup()
        {
            return await _context.MItemGroup.ToListAsync();
        }

        // GET: api/MItemGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MItemGroup>> GetMItemGroup(int id)
        {
            var mItemGroup = await _context.MItemGroup.FindAsync(id);

            if (mItemGroup == null)
            {
                return NotFound();
            }

            return mItemGroup;
        }

        // PUT: api/MItemGroups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMItemGroup(int id, MItemGroup mItemGroup)
        {
            if (id != mItemGroup.IgId)
            {
                return BadRequest();
            }

            _context.Entry(mItemGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MItemGroupExists(id))
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

        // POST: api/MItemGroups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MItemGroup>> PostMItemGroup(MItemGroup mItemGroup)
        {
            _context.MItemGroup.Add(mItemGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMItemGroup", new { id = mItemGroup.IgId }, mItemGroup);
        }

        // DELETE: api/MItemGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MItemGroup>> DeleteMItemGroup(int id)
        {
            var mItemGroup = await _context.MItemGroup.FindAsync(id);
            if (mItemGroup == null)
            {
                return NotFound();
            }

            _context.MItemGroup.Remove(mItemGroup);
            await _context.SaveChangesAsync();

            return mItemGroup;
        }

        private bool MItemGroupExists(int id)
        {
            return _context.MItemGroup.Any(e => e.IgId == id);
        }
    }
}
