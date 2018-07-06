using entities.apifinport.Entities;
using System;
using System.Collections.Generic;

namespace entities.apifinport.Models
{
    public partial class ExchangeTaxes : BaseEntity
    {
        public ExchangeTaxes()
        {
            UserExchangeTaxes = new HashSet<UserExchangeTaxes>();
        }

        public decimal TaxValue { get; set; }
        public int MajorIndiceId { get; set; }

        public MajorIndices MajorIndice { get; set; }
        public ICollection<UserExchangeTaxes> UserExchangeTaxes { get; set; }
    }
}
