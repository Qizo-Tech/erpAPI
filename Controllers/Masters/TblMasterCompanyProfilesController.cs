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
    public class TblMasterCompanyProfilesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TblMasterCompanyProfilesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/TblMasterCompanyProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMasterCompanyProfile>>> GetTblMasterCompanyProfile()
        {
            return await _context.TblMasterCompanyProfile.ToListAsync();
        }

        // GET: api/TblMasterCompanyProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMasterCompanyProfile>> GetTblMasterCompanyProfile(int id)
        {
            var tblMasterCompanyProfile = await _context.TblMasterCompanyProfile.FindAsync(id);

            if (tblMasterCompanyProfile == null)
            {
                return NotFound();
            }

            return tblMasterCompanyProfile;
        }

        // PUT: api/TblMasterCompanyProfiles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMasterCompanyProfile(int id, TblMasterCompanyProfile tblMasterCompanyProfile)
        {
            if (id != tblMasterCompanyProfile.CompanyProfileId)
            {
                return BadRequest();
            }

            _context.Entry(tblMasterCompanyProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMasterCompanyProfileExists(id))
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

        // POST: api/TblMasterCompanyProfiles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TblMasterCompanyProfile>> PostTblMasterCompanyProfile(TblMasterCompanyProfile tblMasterCompanyProfile)
        {
            _context.TblMasterCompanyProfile.Add(tblMasterCompanyProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblMasterCompanyProfile", new { id = tblMasterCompanyProfile.CompanyProfileId }, tblMasterCompanyProfile);
        }

        // DELETE: api/TblMasterCompanyProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblMasterCompanyProfile>> DeleteTblMasterCompanyProfile(int id)
        {
            var tblMasterCompanyProfile = await _context.TblMasterCompanyProfile.FindAsync(id);
            if (tblMasterCompanyProfile == null)
            {
                return NotFound();
            }

            _context.TblMasterCompanyProfile.Remove(tblMasterCompanyProfile);
            await _context.SaveChangesAsync();

            return tblMasterCompanyProfile;
        }

        private bool TblMasterCompanyProfileExists(int id)
        {
            return _context.TblMasterCompanyProfile.Any(e => e.CompanyProfileId == id);
        }
    }
}
