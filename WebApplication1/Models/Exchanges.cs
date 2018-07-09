using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Exchanges
    {
        public Exchanges()
        {
            ExchangeProducts = new HashSet<ExchangeProducts>();
        }

        public int ExchangeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string Designation { get; set; }
        public string Symbol { get; set; }
        public int CurrencyId { get; set; }

        public Currencies Currency { get; set; }
        public ExchangeTaxes ExchangeTaxes { get; set; }
        public ICollection<ExchangeProducts> ExchangeProducts { get; set; }
    }
}
