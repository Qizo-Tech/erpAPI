using qizoErpWebApiApp.Model.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpApi.Models
{
    public class ItemType
    {
        public ItemType()
        {
            MItemGroup = new HashSet<MItemGroup>();
        }
        [Key]
        public int it_Id { get; set; }
        public string It_Description { get; set; }
        public int it_UserId { get; set; }
        public int it_BranchId { get; set; }
        public virtual ICollection<MItemGroup> MItemGroup { get; set; }
    }
}
