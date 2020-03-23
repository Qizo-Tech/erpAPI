using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class Mstate
    {
        public Mstate()
        {
             MLedgerHeads = new HashSet<MLedgerHeads>();
        }
        [Key]
        public int Id { get; set; }
        public string MsStateCode { get; set; }
        public string MsName { get; set; }

        public virtual ICollection<MLedgerHeads> MLedgerHeads { get; set; }
    }
}
