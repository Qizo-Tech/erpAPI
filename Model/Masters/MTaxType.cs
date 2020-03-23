using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MTaxType
    {
        public MTaxType()
        {
            MTax = new HashSet<MTax>();
        }
        [Key]
        public int TxTypId { get; set; }
        public string TxTypDescription { get; set; }
        public int? TxTypUserId { get; set; }
        public int? TxTypBranchId { get; set; }

        public virtual ICollection<MTax> MTax { get; set; }
    }
}
