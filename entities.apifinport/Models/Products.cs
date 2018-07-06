using entities.apifinport.Entities;
using System;
using System.Collections.Generic;

namespace entities.apifinport.Models
{
    public partial class Products : BaseEntity
    {
        public Products()
        {
            UserOperationHistories = new HashSet<UserOperationHistories>();
        }
        public string Abbv { get; set; }
        public string Company { get; set; }
        public string Currency { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? Change { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string MarketCap { get; set; }
        public string Href { get; set; }
        public int ExchangeId { get; set; }

        public Exchanges Exchange { get; set; }
        public ICollection<UserOperationHistories> UserOperationHistories { get; set; }
    }
}
