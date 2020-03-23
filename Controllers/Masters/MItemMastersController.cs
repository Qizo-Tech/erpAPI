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
    public class MItemMastersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MItemMastersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/MItemMasters
        [HttpGet]

        //public async Task<IActionResult> myControllerAction()
        public async Task<ActionResult<IEnumerable<MItemMaster>>> GetMItemMaster()
        {
           
            var result = (from itm in _context.MItemMaster
                          join brnd in _context.MBrand on itm.ItmBrandId equals brnd.BrndId
                          join ptype in _context.MProductTypeStatic on itm.ItmProductTypeId equals ptype.Id
                          join sgrp in _context.MItemSubGroup on itm.ItmSubGrpId equals sgrp.IsgId

                          select new
                          {
                              itm.Id,
                              itm.ItmName,
                              itm.ItmProductType.ProductType,
                              itm.ItmSubGrp.IsgDescription,
                              itm.ItmBrand.BrndDescription,
                              itm.ItmCode,
                              itm.ItmOpeningStock,
                              itm.ItmRoq,
                              itm.ItmRol,
                              itm.ItmMinQty,
                              itm.ItmMaxQty,
                              itm.ItmWarrantyInMonths,
                              itm.ItmModel,
                              itm.ItmPurchaseUnitId,
                              itm.ItmPurchaseUnit.Description,
                              itm.ItmGdnId,
                              itm.ItmGdn.gdn_Description,
                              itm.ItmMfrId,
                              itm.ItmMfr.MfrDescription,
                              itm.ItmStkTypeId,
                              itm.ItmStkType.StockType
                          }).ToList() ;
            return Ok(result);

        }

        [HttpGet("{id}/{typ}")]
        public async Task<ActionResult<IEnumerable<MItemMaster>>> GetByType(int id,int typ)
        {
            if(id>0)
            {
                var result = (from itm in _context.MItemMaster
                              join ptype in _context.MProductTypeStatic on itm.ItmProductTypeId equals ptype.Id
                              where itm.Id == id 
                              where itm.ItmProductTypeId == typ
                              select new
                              {
                                  itm.Id,
                                  itm.ItmName,
                                  itm.ItmUserId,
                                  itm.ItmBranchId
                              }).ToList();
                return Ok(result);
            }
            else
            {

                var result = (from itm in _context.MItemMaster
                              join ptype in _context.MProductTypeStatic on itm.ItmProductTypeId equals ptype.Id
                              where itm.ItmProductTypeId == typ
                              select new
                              {
                                  itm.Id,
                                  itm.ItmName,
                                  itm.ItmUserId,
                                  itm.ItmBranchId
                              }).ToList();
                return Ok(result);

            }
        }
        // GET: api/MItemMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MItemMaster>> GetMItemMaster(int id)
        {
            var result = (from itm in _context.MItemMaster
                          join brnd in _context.MBrand on itm.ItmBrandId equals brnd.BrndId
                          join ptype in _context.MProductTypeStatic on itm.ItmProductTypeId equals ptype.Id
                          join sgrp in _context.MItemSubGroup on itm.ItmSubGrpId equals sgrp.IsgId
                          where itm.Id==id
                          select new
                          {
                              itm.Id,
                              itm.ItmName,
                              itm.ItmProductType.ProductType,
                              itm.ItmSubGrp.IsgDescription,
                              itm.ItmBrand.BrndDescription,
                              itm.ItmCode,
                              itm.ItmOpeningStock,
                              itm.ItmRoq,
                              itm.ItmRol,
                              itm.ItmMinQty,
                              itm.ItmMaxQty,
                              itm.ItmWarrantyInMonths,
                              itm.ItmModel,
                              itm.ItmPurchaseUnitId,
                              itm.ItmPurchaseUnit.Description,
                              itm.ItmGdnId,
                              itm.ItmGdn.gdn_Description,
                              itm.ItmMfrId,
                              itm.ItmMfr.MfrDescription,
                              itm.ItmStkTypeId,
                              itm.ItmStkType.StockType,
                              itm.ItmBarCode,
                              itm.ItmDescription,
                              itm.ItmSpecification,
                              itm.ItmHsn,
                              itm.ItmMonthlyTarget,
                              itm.ItmIsTaxAplicable,
                              itm.ItmPrintCaption,
                              itm.ItmUserId,
                              itm.ItmBranchId 
                          }).ToList();
            return Ok(result);
        
        }

        // PUT: api/MItemMasters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMItemMaster(int id, MItemMaster mItemMaster)
        {
            if (id != mItemMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(mItemMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MItemMasterExists(id))
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

        // POST: api/MItemMasters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MItemMaster>> PostMItemMaster(MItemMaster mItemMaster)
        {
            _context.MItemMaster.Add(mItemMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMItemMaster", new { id = mItemMaster.Id }, mItemMaster);
        }

        // DELETE: api/MItemMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MItemMaster>> DeleteMItemMaster(int id)
        {
            var mItemMaster = await _context.MItemMaster.FindAsync(id);
            if (mItemMaster == null)
            {
                return NotFound();
            }

            _context.MItemMaster.Remove(mItemMaster);
            await _context.SaveChangesAsync();

            return mItemMaster;
        }

        private bool MItemMasterExists(int id)
        {
            return _context.MItemMaster.Any(e => e.Id == id);
        }
    }
}
