using qizoErpWebApiApp.Model.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Transactions
{
    
        public partial class TPurchaseIndentDetails
        {
            public int Id { get; set; }
            public int? PIndDetIndHeaderId { get; set; }
            public int? PIndDetItemId { get; set; }
            public decimal? PIndDetQty { get; set; }
            public decimal? PIndDetRate { get; set; }
            public string PIndDetRemarks { get; set; }

            public virtual TPurchaseIndentHeader PIndDetIndHeader { get; set; }
            public virtual MItemMaster PIndDetItem { get; set; }
        }
     
}
