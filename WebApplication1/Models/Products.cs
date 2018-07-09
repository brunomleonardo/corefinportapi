using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Products
    {
        public Products()
        {
            ExchangeProducts = new HashSet<ExchangeProducts>();
            UserOperationHistories = new HashSet<UserOperationHistories>();
        }

        public int ProductId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string Abbv { get; set; }
        public string Company { get; set; }
        public string Currency { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? Change { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string MarketCap { get; set; }
        public string Href { get; set; }
        public int? TechnicalValueId { get; set; }

        public ICollection<ExchangeProducts> ExchangeProducts { get; set; }
        public ICollection<UserOperationHistories> UserOperationHistories { get; set; }
    }
}
