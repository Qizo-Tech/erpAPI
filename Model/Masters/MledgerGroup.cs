using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MledgerGroup
    {
        public MledgerGroup()
        {
            MLedgerHeads = new HashSet<MLedgerHeads>();
        }

        public int Id { get; set; }
        public string LgName { get; set; }
        public string LgAliasName { get; set; }
        public int? LgUnderGruupId { get; set; }
        public int? LgPrimaryId { get; set; }
        public string LgPrimaryName { get; set; }
        public string LgType { get; set; }
        public bool? LgGrpBehaveSubLedger { get; set; }
        public int? LgUserId { get; set; }
        public int? LgBranchId { get; set; }

        public virtual ICollection<MLedgerHeads> MLedgerHeads { get; set; }
    }
}
