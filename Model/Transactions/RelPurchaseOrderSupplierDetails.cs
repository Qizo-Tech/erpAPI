using qizoErpWebApiApp.Model.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Transactions
{
    public class RelPurchaseOrderSupplierDetails
    {
        public int Id { get; set; }
        public int? PoHeaderId { get; set; }
        public decimal? PoSupplierId { get; set; }
        public bool? PoIsApproved { get; set; }
        public string PoRemarks { get; set; }

        public virtual TPurchaseOrderHeader PoHeader { get; set; }
        public virtual MLedgerHeads PoSupplier { get; set; }
    }
}
