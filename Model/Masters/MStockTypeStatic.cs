using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MStockTypeStatic
    {
        public MStockTypeStatic()
        {
            MItemMaster = new HashSet<MItemMaster>();
        }

        public int Id { get; set; }
        public string StockType { get; set; }

        public virtual ICollection<MItemMaster> MItemMaster { get; set; }
    }
}
