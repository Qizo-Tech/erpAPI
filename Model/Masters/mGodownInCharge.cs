using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qizoErpApi.Models
{
    public class mGodownInCharge
    {
        //public mGodownInChargeModel()
        //{
        //    //inchargeGdn = new HashSet<mGodownModel>();
        //    inchargeGdn = new List<mGodownModel>();
        //}
        [Key]
        //[ForeignKey("mGodown")]
        public int GdnInch_Id { get; set; }
        public string GdnInch_Name { get; set; }
        public string GdnInch_Address { get; set; }
        public string GdnInch_PhoneNo { get; set; }
        public int GdnInch_UserId { get; set; }
        public int GdnInch_BranchId { get; set; }
        //public mGodownModel GdnIncharge { get; set; }

        //public virtual ICollection<mGodownModel> inchargeGdn { get; set; }
        //public virtual List<mGodownModel> inchargeGdn { get; set; }

    }
    public class mGodownInChargeModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }

      
    }
}