using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class ProductToSpare
    {
        public int Id { get; set; }
        public int? PtsProductId { get; set; }
        public int? PtsSpareId { get; set; }
        public decimal? PtsQty { get; set; }
        public int? PtsUserId { get; set; }
        public int? PtsBranchId { get; set; }

        public virtual MItemMaster PtsProduct { get; set; }
        public virtual MItemMaster PtsSpare { get; set; }
    }
}
