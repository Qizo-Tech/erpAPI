using qizoErpApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Transactions
{
    public class TPurchaseIndentHeader
    {
        public TPurchaseIndentHeader()
        {
            TPurchaseIndentDetails = new HashSet<TPurchaseIndentDetails>();
            TPurchaseOrderHeader = new HashSet<TPurchaseOrderHeader>();
        }

        public int Id { get; set; }
        public int? PIndGdnId { get; set; }
        public string PIndNumber { get; set; }
        public DateTime? PIndDate { get; set; }
        public DateTime? PIndStkAtGdnDate { get; set; }
        public string PIndRemarks { get; set; }
        public int? PIndUserId { get; set; }
        public int? PIndBranchId { get; set; }

        public virtual MGodown PIndGdn { get; set; }
        public virtual ICollection<TPurchaseIndentDetails> TPurchaseIndentDetails { get; set; }
        public virtual ICollection<TPurchaseOrderHeader> TPurchaseOrderHeader { get; set; }
    }
}
