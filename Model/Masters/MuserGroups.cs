using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MuserGroups
    {
        public MuserGroups()
        {
            Musers = new HashSet<Musers>();
        }

        [Key]
        public int Id { get; set; }
        public string UserGrpDescription { get; set; }
        public int? UserGrpUserId { get; set; }
        public int? UserGrpBranchId { get; set; }

        public virtual ICollection<Musers> Musers { get; set; }
    }
}
