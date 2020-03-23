using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class Mconditions
    {
        public int Id { get; set; }
        public string ConDescription { get; set; }
        public int? ConUserId { get; set; }
        public int? ConBaranchId { get; set; }
    }
}
