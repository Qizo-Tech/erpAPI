using qizoErpWebApiApp.Model.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Transactions
{
    public class RelPurchaseOrderIndendHeader
    {
        public int Id { get; set; }
        public int? RelPoindHeaderPoHeaderId { get; set; }
        public int? RelPoindHeaderIndentHeaderId { get; set; }
        public decimal? PoSupplierId { get; set; }

        public virtual MLedgerHeads PoSupplier { get; set; }
        public virtual TPurchaseIndentHeader RelPoindHeaderIndentHeader { get; set; }
        public virtual TPurchaseOrderHeader RelPoindHeaderPoHeader { get; set; }
    }
}
