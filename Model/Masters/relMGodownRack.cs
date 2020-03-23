using qizoErpWebApiApp.Model.Masters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qizoErpApi.Models
{
    public class RelMGodownRack
    {
       [Key]
        
        public int gdnRk_Id { get; set; }
        public string gdnRk_Description { get; set; }

        [ForeignKey("mGodown")]
        public int gdnRk_GodownId { get; set; } //project that task is included
        public virtual MGodown mGodown { get; set; }
        public virtual ICollection<MItemMaster> MItemMaster { get; set; }
      
    }

    public class relMGodownRackModelDTO
    {
        public int Rack_Id { get; set; }
        public string Rack_Description { get; set; }
        [ForeignKey("mGodown")]
        public int gdnRk_GodownId { get; set; } //project that task is included
        public virtual MGodown GdnRkGodownDetails { get; set; }

    }

}