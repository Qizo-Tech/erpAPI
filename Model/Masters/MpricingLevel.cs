using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MpricingLevel
    {
        public MpricingLevel()
        {
            MLedgerHeads = new HashSet<MLedgerHeads>();
            RelPricingLevelItems = new HashSet<RelPricingLevelItems>();
        }

        public int Id { get; set; }
        public string PlDescription { get; set; }
        public decimal? PlDiscountPercentage { get; set; }
        public decimal? PlDiscountAmount { get; set; }
        public string PlNarration { get; set; }
        public int? PlUserId { get; set; }
        public int? PlBranchId { get; set; }

        public virtual ICollection<MLedgerHeads> MLedgerHeads { get; set; }
        public virtual ICollection<RelPricingLevelItems> RelPricingLevelItems { get; set; }
    }
}