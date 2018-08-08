using System;
using System.Collections.Generic;

namespace FinPort.Entities.Models
{
    public partial class ExchangeProducts
    {
        public int ExchangeProductId { get; set; }
        public int ExchangeId { get; set; }
        public int ProductId { get; set; }

        public Exchanges Exchange { get; set; }
        public Products Product { get; set; }
    }
}
