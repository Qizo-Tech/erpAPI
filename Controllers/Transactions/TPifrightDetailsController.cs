using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qizoErpApi.Models;
using qizoErpWebApiApp.Model.Transactions;

namespace qizoErpWebApiApp.Controllers.Transactions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TPifrightDetailsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TPifrightDetailsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/TPifrightDetails test app
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TPifrightDetails>>> GetTPifrightDetails()
        {
            var result = (from fright in _context.TPifrightDetails 
                          join fritParty in _context.MLedgerHeads on fright.PifFrightParyId equals fritParty.Id 
                          join shipLinePrty in _context.MShippingLine  on fright.PifShippingLineParyId  equals shipLinePrty.Id
                          

                          select new
                          {
                              fright.Id,
                              fright.PifFrightParyId,
                              fright.PifFrightPary.LhName,
                              fright.PifShippingLineParyId,
                              fright.PifShippingLinePary.SlShippingName,
                              fright.PifClosingDate,
                              fright.PifEtd,
                              fright.PifTransitTime,
                              fright.PifRoute,
                              fright.PifRouteDescription,
                              fright.PifEta,
                              fright.PifFrigthAmount
                          }).ToList();
            return Ok(result);
            //return await _context.TPifrightDetails.ToListAsync();
        }

        // GET: api/TPifrightDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TPifrightDetails>> GetTPifrightDetails(long id)
        {
            var result = (from fright in _context.TPifrightDetails
                          join fritParty in _context.MLedgerHeads on fright.PifFrightParyId equals fritParty.Id
                          join shipLinePrty in _context.MShippingLine on fright.PifShippingLineParyId equals shipLinePrty.Id
                          where fright.Id==id

                          select new
                          {
                              fright.Id,
                              fright.PifFrightParyId,
                              fright.PifFrightPary.LhName,
                              fright.PifShippingLineParyId,
                              fright.PifShippingLinePary.SlShippingName,
                              fright.PifClosingDate,
                              fright.PifEtd,
                              fright.PifTransitTime,
                              fright.PifRoute,
                              fright.PifRouteDescription,
                              fright.PifEta,
                              fright.PifFrigthAmount
                          }).ToList();
            return Ok(result);

            //var tPifrightDetails = await _context.TPifrightDetails.FindAsync(id);

            //if (tPifrightDetails == null)
            //{
            //    return NotFound();
            //}

            //return tPifrightDetails;
        }

        // PUT: api/TPifrightDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTPifrightDetails(long id, TPifrightDetails tPifrightDetails)
        {
            if (id != tPifrightDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(tPifrightDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TPifrightDetailsExists(id))
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

        // POST: api/TPifrightDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TPifrightDetails>> PostTPifrightDetails(TPifrightDetails tPifrightDetails)
        {
            _context.TPifrightDetails.Add(tPifrightDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTPifrightDetails", new { id = tPifrightDetails.Id }, tPifrightDetails);
        }

        // DELETE: api/TPifrightDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TPifrightDetails>> DeleteTPifrightDetails(long id)
        {
            var tPifrightDetails = await _context.TPifrightDetails.FindAsync(id);
            if (tPifrightDetails == null)
            {
                return NotFound();
            }

            _context.TPifrightDetails.Remove(tPifrightDetails);
            await _context.SaveChangesAsync();

            return tPifrightDetails;
        }

        private bool TPifrightDetailsExists(long id)
        {
            return _context.TPifrightDetails.Any(e => e.Id == id);
        }
    }
}
