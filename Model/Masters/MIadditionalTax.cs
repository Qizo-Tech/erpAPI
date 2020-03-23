using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MIadditionalTax
    {
        public MIadditionalTax()
        {
            MItemSubGroup = new HashSet<MItemSubGroup>();
        }
        [Key]
        public int AtId { get; set; }
        public string AtDescription { get; set; }
        public decimal? AtPercentage { get; set; }
        public string AtApplicableOn { get; set; }
        public int? AtUserId { get; set; }
        public int? AtBranchId { get; set; }

        public virtual ICollection<MItemSubGroup> MItemSubGroup { get; set; }
    }
}
