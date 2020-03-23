using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class RelPricingLevelItems
    {
       // [Key]
        public int Id { get; set; }
        public int? PlItmPricingLevelId { get; set; }
        public int? PlItmItemId { get; set; }
        public decimal? PlItmRate { get; set; }

        public virtual MItemMaster PlItmItem { get; set; }
        public virtual MpricingLevel PlItmPricingLevel { get; set; }
    }
}
