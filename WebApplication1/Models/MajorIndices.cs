using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class MajorIndices
    {
        public int MajorIndiceId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string Designation { get; set; }
        public int? TechnicalValueId { get; set; }

        public TechnicalValues TechnicalValue { get; set; }
    }
}
