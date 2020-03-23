using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpApi.Models
{
    public class ItemTypeDTO //Data Transfer Object
    {
        public int Id { get; set; }
        public string  Description { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
    }
}
