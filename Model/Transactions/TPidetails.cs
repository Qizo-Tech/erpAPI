using qizoErpWebApiApp.Model.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Transactions
{
    public class TPidetails
    {
        public int Id { get; set; }
        public int? PidHeaderId { get; set; }
        public int? PidItemId { get; set; }
        public decimal? PidRate { get; set; }
        public decimal? PidQty { get; set; }
        public string PidRemarks { get; set; }
        public int? PidUserId { get; set; }
        public int? PidBranchId { get; set; }

        public virtual TPurchaseOrderHeader PidHeader { get; set; }
        public virtual MItemMaster PidItem { get; set; }
    }
}
