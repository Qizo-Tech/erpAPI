using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Transactions
{
    public class TPurchaseOrderHeader
    {
        public TPurchaseOrderHeader()
        {
            TPurchaseOrderDetails = new HashSet<TPurchaseOrderDetails>();
        }

        public int Id { get; set; }
        public int? PoIndHeaderId { get; set; }
        public string PoOrdrNo { get; set; }
        public DateTime? PoOrderDate { get; set; }
        public string PoRemarks { get; set; }

        public virtual TPurchaseIndentHeader PoIndHeader { get; set; }
        public virtual ICollection<TPurchaseOrderDetails> TPurchaseOrderDetails { get; set; }
    }
}
