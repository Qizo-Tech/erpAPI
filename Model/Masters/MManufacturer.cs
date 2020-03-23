using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MManufacturer
    {
        public MManufacturer()
        {
            MItemMaster = new HashSet<MItemMaster>();
        }

        public int MfrId { get; set; }
        public string MfrDescription { get; set; }
        public int? MfrUserId { get; set; }
        public int? MfrBranchId { get; set; }

        public virtual ICollection<MItemMaster> MItemMaster { get; set; }
    }
}
