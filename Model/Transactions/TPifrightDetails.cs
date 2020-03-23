using qizoErpWebApiApp.Model.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Transactions
{
    public class TPifrightDetails
    {
        public long Id { get; set; }
        public long PifPiid { get; set; }
        public decimal? PifFrightParyId { get; set; }
        public int? PifShippingLineParyId { get; set; }
        public DateTime? PifClosingDate { get; set; }
        public DateTime? PifEtd { get; set; }
        public int? PifTransitTime { get; set; }
        public string PifRoute { get; set; }
        public string PifRouteDescription { get; set; }
        public DateTime? PifEta { get; set; }
        public decimal? PifFrigthAmount { get; set; }

        public virtual MLedgerHeads PifFrightPary { get; set; }
        public virtual MShippingLine PifShippingLinePary { get; set; }
    }
}
