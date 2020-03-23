using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MItemSubGroup
    {
        [Key]
        public int IsgId { get; set; }
            public string IsgDescription { get; set; }
            public int? IsgItemGroupId { get; set; }
            public bool? IsgIsDisplay { get; set; }
            public int? IsgTaxId { get; set; }
            public int? IsgAdditionalTaxId { get; set; }
            public bool? IsgIsTaxInclusive { get; set; }
            public int? IsgUserId { get; set; }
            public int? IsgBranchId { get; set; }

            public virtual MIadditionalTax IsgAdditionalTax { get; set; }
            public virtual MItemGroup IsgItemGroup { get; set; }
            public virtual MTax IsgTax { get; set; }

            public virtual ICollection<MItemMaster> MItemMaster { get; set; }
    }
}
