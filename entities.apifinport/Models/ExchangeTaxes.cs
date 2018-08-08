using System;
using System.Collections.Generic;

namespace FinPort.Entities.Models
{
    public partial class ExchangeTaxes
    {
        public ExchangeTaxes()
        {
            UserExchangeTaxes = new HashSet<UserExchangeTaxes>();
        }

        public int ExchangeTaxId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public decimal TaxValue { get; set; }

        public Exchanges ExchangeTax { get; set; }
        public ICollection<UserExchangeTaxes> UserExchangeTaxes { get; set; }
    }
}
