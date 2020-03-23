using qizoErpWebApiApp.Model.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MLedgerHeads
    {
        public MLedgerHeads()
        {
            RelPurchaseOrderIndendHeader = new HashSet<RelPurchaseOrderIndendHeader>();
            RelPurchaseOrderSupplierDetails = new HashSet<RelPurchaseOrderSupplierDetails>();
            TPifrightDetails = new HashSet<TPifrightDetails>();
        }

        public decimal Id { get; set; }
        public string LhName { get; set; }
        public string LhAliasName { get; set; }
        public int? LhGroupId { get; set; }
        public string LhType { get; set; }
        public int? LhPricingLevelId { get; set; }
        public bool? LhMaintainBillByBill { get; set; }
        public int? LhCreditPeriod { get; set; }
        public string LhMailingName { get; set; }
        public string LhMailingAddress1 { get; set; }
        public string LhMailingAddress2 { get; set; }
        public string LhMailingAddress3 { get; set; }
        public int? LhStateId { get; set; }
        public string LhPincode { get; set; }
        public string LhPanNo { get; set; }
        public string LhGstno { get; set; }
        public decimal? LhOpeningBalance { get; set; }
        public string LhOpeningType { get; set; }
        public string LhContactPerson { get; set; }
        public string LhContactNo { get; set; }
        public string LhEmail { get; set; }
        public string LhBankName { get; set; }
        public string LhAccountNo { get; set; }
        public string LhBankBranch { get; set; }
        public string LhIfscCode { get; set; }
        public int? LhUserId { get; set; }
        public int? LhBranchId { get; set; }

        public virtual MledgerGroup LhGroup { get; set; }
        public virtual MpricingLevel LhPricingLevel { get; set; }
        public virtual Mstate LhState { get; set; }
        public virtual ICollection<RelPurchaseOrderIndendHeader> RelPurchaseOrderIndendHeader { get; set; }
        public virtual ICollection<RelPurchaseOrderSupplierDetails> RelPurchaseOrderSupplierDetails { get; set; }
        public virtual ICollection<TPifrightDetails> TPifrightDetails { get; set; }
    }
}
