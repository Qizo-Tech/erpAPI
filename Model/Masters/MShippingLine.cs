using qizoErpWebApiApp.Model.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MShippingLine
    {
        public MShippingLine()
        {
            TPifrightDetails = new HashSet<TPifrightDetails>();
        }

        public int Id { get; set; }
        public string SlShippingName { get; set; }
        public string SlAddress { get; set; }
        public int? SlUserId { get; set; }
        public int? SlBranchId { get; set; }

        public virtual ICollection<TPifrightDetails> TPifrightDetails { get; set; }
    }
}
