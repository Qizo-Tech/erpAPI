using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MProductTypeStatic
    {
        public MProductTypeStatic()
        {
            MItemMaster = new HashSet<MItemMaster>();
        }

        public int Id { get; set; }
        public string ProductType { get; set; }

        public virtual ICollection<MItemMaster> MItemMaster { get; set; }
    }
}
