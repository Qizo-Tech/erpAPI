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
    public class MCompanyProfilesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MCompanyProfilesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MCompanyProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MCompanyProfile>>> GetMCompanyProfile()
        {
            return await _context.MCompanyProfile.ToListAsync();
        }

        // GET: api/MCompanyProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCompanyProfile>> GetMCompanyProfile(int id)
        {
            var mCompanyProfile = await _context.MCompanyProfile.FindAsync(id);

            if (mCompanyProfile == null)
            {
                return NotFound();
            }

            return mCompanyProfile;
        }

        // PUT: api/MCompanyProfiles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMCompanyProfile(int id, MCompanyProfile mCompanyProfile)
        {
            if (id != mCompanyProfile.CompanyProfileId)
            {
                return BadRequest();
            }

            _context.Entry(mCompanyProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCompanyProfileExists(id))
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

        // POST: api/MCompanyProfiles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MCompanyProfile>> PostMCompanyProfile(MCompanyProfile mCompanyProfile)
        {
            _context.MCompanyProfile.Add(mCompanyProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMCompanyProfile", new { id = mCompanyProfile.CompanyProfileId }, mCompanyProfile);
        }

        // DELETE: api/MCompanyProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MCompanyProfile>> DeleteMCompanyProfile(int id)
        {
            var mCompanyProfile = await _context.MCompanyProfile.FindAsync(id);
            if (mCompanyProfile == null)
            {
                return NotFound();
            }

            _context.MCompanyProfile.Remove(mCompanyProfile);
            await _context.SaveChangesAsync();

            return mCompanyProfile;
        }

        private bool MCompanyProfileExists(int id)
        {
            return _context.MCompanyProfile.Any(e => e.CompanyProfileId == id);
        }
    }
}
