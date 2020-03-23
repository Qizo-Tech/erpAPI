using qizoErpWebApiApp.Model.Masters;
using qizoErpWebApiApp.Model.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qizoErpApi.Models
{
    public class MGodown
    {
        [Key]
        public int Gdn_Id { get; set; }
        public string gdn_Description { get; set; }
        public int gdn_InCharge { get; set; }
        //public string GdnInch_Name { get; set; }
        public string gdn_ContactNumber { get; set; }
        public string gdn_Address { get; set; }
        public int gdn_UserId { get; set; }
        public int gdn_BranchId { get; set; }
        public string gdn_Prefix { get; set; }
        //public virtual mGodownInChargeModel incharge { get; set; }

        public virtual List<RelMGodownRack> Racks { get; set; }

        public virtual ICollection<MItemMaster> MItemMaster { get; set; }
        ///public virtual ICollection<RelMgodownRack> RelMgodownRack { get; set; }
        public virtual ICollection<TPurchaseIndentHeader> TPurchaseIndentHeader { get; set; }



        //[ForeignKey("mGodownInCharge")]

        ///public virtual Publisher Publisher { get; set; }


    }
    public class mGodownModelDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int InChargeID { get; set; }
        public string InChargeName { get; set; }
        public string ContactNumber { get; set; }
        public string gdnAddress { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public virtual List<RelMGodownRack> Racks { get; set; }
        
       

    }
}