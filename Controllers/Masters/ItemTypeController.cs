using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qizoErpApi.Models;

namespace qizoErpApi.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    //[EnableCors("AnotherPolicy")]
    public class ItemTypeController : ControllerBase
    {
        //********************
        private readonly AppDBContext _context;

        public ItemTypeController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemTypeDTO>>> GetItemTypes()
        {

            //var query = await (from itmType in _context.MItemType
            //                   orderby itmType.It_Description
            //                   select itmType).ToListAsync();

            var query = await (from itmType in _context.MItemType
                               orderby itmType.It_Description
                               select new ItemTypeDTO
                               {
                                   Id = itmType.it_Id,
                                   Description = itmType.It_Description,
                                   UserId = itmType.it_UserId,
                                   BranchId = itmType.it_BranchId
                               }).ToListAsync();
            return query;


            //return await _context.MItemType
            //    .Select(x => itemTypeAssignDTO(x) )
            //    .ToListAsync();
        }
        //checking item already exist
        private bool ItemExists(int id) =>
            _context.MItemType.Any(e => e.it_Id == id);
        //to map keys with DTO class
        private static ItemTypeDTO ItemTypeAssignDTO(ItemType obj) =>
           new ItemTypeDTO 
           {
              
               Id = obj.it_Id,
               Description = obj.It_Description,
               UserId=obj.it_UserId,
               BranchId=obj.it_BranchId

           };
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemTypeDTO>> GetItemType(int id)
        {
            var objItemType = await _context.MItemType.FindAsync(id);

            if (objItemType == null)
            {
                return NotFound();
            }

            return ItemTypeAssignDTO(objItemType);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemType(int id, ItemTypeDTO  objItemTypeDTO)
        {
            if (id != objItemTypeDTO.Id)
            {
                return BadRequest();
            }

            var objItemType = await _context.MItemType.FindAsync(id);
            if (objItemType == null)
            {
                return NotFound();
            }

            objItemType.It_Description = objItemTypeDTO.Description;
            objItemType.it_UserId = objItemTypeDTO.UserId;
            objItemType.it_BranchId = objItemTypeDTO.BranchId;
   
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ItemExists(id))
            {
                return NotFound();
            }
            return CreatedAtAction(
                nameof(GetItemType),
                new { id = objItemType.it_Id },
                ItemTypeAssignDTO(objItemType));
            //return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<ItemType>> CreateItemType(ItemTypeDTO objItemTypeDTO)
        {
            var objItemType = new ItemType
            {
                It_Description = objItemTypeDTO.Description, 
                it_UserId=objItemTypeDTO.UserId,
                it_BranchId=objItemTypeDTO.BranchId 
            };

            _context.MItemType.Add(objItemType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetItemType),
                new { id = objItemType.it_Id},
                ItemTypeAssignDTO(objItemType));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemType(int id)
        {
            var objItemType = await _context.MItemType.FindAsync(id);

            if (objItemType == null)
            {
                return NotFound();
            }

            _context.MItemType.Remove(objItemType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //********************
    }
}