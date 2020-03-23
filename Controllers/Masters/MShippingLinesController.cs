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
    public class MShippingLinesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MShippingLinesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MShippingLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MShippingLine>>> GetMShippingLine()
        {
            var result = (from shippLine in _context.MShippingLine 
                          
                          select new
                          {
                              shippLine.Id,
                              shippLine.SlShippingName,
                              shippLine.SlAddress,
                              shippLine.SlUserId,
                              shippLine.SlBranchId          
                          }).ToList();
            return Ok(result);

           
        }

        // GET: api/MShippingLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MShippingLine>> GetMShippingLine(int id)
        {
            var result = (from shippLine in _context.MShippingLine
                          where shippLine.Id==id

                          select new
                          {
                              shippLine.Id,
                              shippLine.SlShippingName,
                              shippLine.SlAddress,
                              shippLine.SlUserId,
                              shippLine.SlBranchId
                          }).ToList();
            return Ok(result);

        }

        // PUT: api/MShippingLines/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMShippingLine(int id, MShippingLine mShippingLine)
        {
            if (id != mShippingLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(mShippingLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MShippingLineExists(id))
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

        // POST: api/MShippingLines
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MShippingLine>> PostMShippingLine(MShippingLine mShippingLine)
        {
            _context.MShippingLine.Add(mShippingLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMShippingLine", new { id = mShippingLine.Id }, mShippingLine);
        }

        // DELETE: api/MShippingLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MShippingLine>> DeleteMShippingLine(int id)
        {
            var mShippingLine = await _context.MShippingLine.FindAsync(id);
            if (mShippingLine == null)
            {
                return NotFound();
            }

            _context.MShippingLine.Remove(mShippingLine);
            await _context.SaveChangesAsync();

            return mShippingLine;
        }

        private bool MShippingLineExists(int id)
        {
            return _context.MShippingLine.Any(e => e.Id == id);
        }
    }
}
