using qizoErpApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MItemGroup
    {
        public MItemGroup()
        {
            MItemSubGroup = new HashSet<MItemSubGroup>();
        }
        [Key]
        public int IgId { get; set; }
        public string IgDescription { get; set; }
        public int? IgItemTypeId { get; set; }
        public int? IgUserId { get; set; }
        public int? IgBranchId { get; set; }

        public virtual ItemType IgItemType { get; set; }
        public virtual ICollection<MItemSubGroup> MItemSubGroup { get; set; }
    }
}
