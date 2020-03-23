using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MTax
    {
        public MTax()
        {
            MItemSubGroup = new HashSet<MItemSubGroup>();
        }
        [Key]
        public int TxId { get; set; }
        public string TxDescription { get; set; }
        public int? TxTaxTypeId { get; set; }
        public decimal? TxPercentage { get; set; }
        public int? TxAccountHeadId { get; set; }
        public int? TxUserId { get; set; }
        public int? TxBranchId { get; set; }

        public virtual MTaxType TxTaxType { get; set; }
        public virtual ICollection<MItemSubGroup> MItemSubGroup { get; set; }
    }
}
