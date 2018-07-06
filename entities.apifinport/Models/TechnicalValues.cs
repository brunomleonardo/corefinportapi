using entities.apifinport.Entities;
using System;
using System.Collections.Generic;

namespace entities.apifinport.Models
{
    public partial class TechnicalValues : BaseEntity
    {
        public decimal? Last { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public decimal? Change { get; set; }
        public decimal? ChangePerc { get; set; }
        public decimal? PrfDaily { get; set; }
        public decimal? Prf1Week { get; set; }
        public decimal? Prf1Month { get; set; }
        public decimal? PrfYtd { get; set; }
        public decimal? Prf1Years { get; set; }
        public decimal? Prf3Years { get; set; }
        public int? MajorIndiceId { get; set; }
        public int? ProductId { get; set; }

        public MajorIndices MajorIndice { get; set; }
    }
}
