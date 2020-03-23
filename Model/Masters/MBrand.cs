using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MBrand
    {
        public MBrand()
        {
            MItemMaster = new HashSet<MItemMaster>();
        }

        public int BrndId { get; set; }
        public string BrndDescription { get; set; }
        public int? BrndUserId { get; set; }
        public int? BrndBranchId { get; set; }

        public virtual ICollection<MItemMaster> MItemMaster { get; set; }
    }
}
