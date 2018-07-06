using entities.apifinport.Entities;
using System;
using System.Collections.Generic;

namespace entities.apifinport.Models
{
    public partial class MajorIndices : BaseEntity
    {
        public MajorIndices()
        {
            ExchangeTaxes = new HashSet<ExchangeTaxes>();
            TechnicalValues = new HashSet<TechnicalValues>();
        }

        public string Designation { get; set; }

        public ICollection<ExchangeTaxes> ExchangeTaxes { get; set; }
        public ICollection<TechnicalValues> TechnicalValues { get; set; }
    }
}
