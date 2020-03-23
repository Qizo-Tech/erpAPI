using qizoErpApi.Models;
using qizoErpWebApiApp.Model.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MItemMaster
    {
        public MItemMaster()
        {
            ProductToSparePtsProduct = new HashSet<ProductToSpare>();
            ProductToSparePtsSpare = new HashSet<ProductToSpare>();
            RelItemImage = new HashSet<RelItemImage>();
            RelPricingLevelItems = new HashSet<RelPricingLevelItems>();
            TPidetails = new HashSet<TPidetails>();
            TPurchaseIndentDetails = new HashSet<TPurchaseIndentDetails>();
        }

        public int Id { get; set; }
        public string ItmName { get; set; }
        public string ItmPrintCaption { get; set; }
        public int? ItmStkTypeId { get; set; }
        public int? ItmProductTypeId { get; set; }
        public int? ItmSubGrpId { get; set; }
        public int? ItmPurchaseUnitId { get; set; }
        public int? ItmSalesUnitId { get; set; }
        public int? ItmMfrId { get; set; }
        public int? ItmBrandId { get; set; }
        public int? ItmGdnId { get; set; }
        public int? ItmRackId { get; set; }
        public string ItmCode { get; set; }
        public string ItmBarCode { get; set; }
        public string ItmDescription { get; set; }
        public decimal? ItmPunitToSunit { get; set; }
        public decimal? ItmOpeningStock { get; set; }
        public decimal? ItmRol { get; set; }
        public decimal? ItmRoq { get; set; }
        public decimal? ItmMinQty { get; set; }
        public decimal? ItmMaxQty { get; set; }
        public int? ItmWarrantyInMonths { get; set; }
        public string ItmSpecification { get; set; }
        public string ItmHsn { get; set; }
        public string ItmModel { get; set; }
        public bool? ItmIsTaxAplicable { get; set; }
        public decimal? ItmMonthlyTarget { get; set; }
        public int? ItmUserId { get; set; }
        public int? ItmBranchId { get; set; }

        public virtual MBrand ItmBrand { get; set; }
        public virtual MGodown ItmGdn { get; set; }
        public virtual MManufacturer ItmMfr { get; set; }
        public virtual MProductTypeStatic ItmProductType { get; set; }
        public virtual MUnitMaster ItmPurchaseUnit { get; set; }
        public virtual RelMGodownRack ItmRack { get; set; }
        public virtual MUnitMaster ItmSalesUnit { get; set; }
        public virtual MStockTypeStatic ItmStkType { get; set; }
        public virtual MItemSubGroup ItmSubGrp { get; set; }
        public virtual ICollection<ProductToSpare> ProductToSparePtsProduct { get; set; }
        public virtual ICollection<ProductToSpare> ProductToSparePtsSpare { get; set; }
        public virtual ICollection<RelItemImage> RelItemImage { get; set; }
        public virtual ICollection<RelPricingLevelItems> RelPricingLevelItems { get; set; }
        public virtual ICollection<TPidetails> TPidetails { get; set; }
        public virtual ICollection<TPurchaseIndentDetails> TPurchaseIndentDetails { get; set; }
    }
}
