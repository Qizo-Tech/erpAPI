using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MUnitMaster
    {
        public MUnitMaster()
        {
            MItemMasterItmPurchaseUnit = new HashSet<MItemMaster>();
            MItemMasterItmSalesUnit = new HashSet<MItemMaster>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MItemMaster> MItemMasterItmPurchaseUnit { get; set; }
        public virtual ICollection<MItemMaster> MItemMasterItmSalesUnit { get; set; }
    }
}
