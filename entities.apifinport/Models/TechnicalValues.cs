using System;
using System.Collections.Generic;

namespace FinPort.Entities.Models
{
    public partial class TechnicalValues
    {
        public TechnicalValues()
        {
            MajorIndices = new HashSet<MajorIndices>();
            Products = new HashSet<Products>();
        }

        public int TechnicalValueId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
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

        public ICollection<MajorIndices> MajorIndices { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
