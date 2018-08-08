using System;
using System.Collections.Generic;

namespace FinPort.Core.Models
{
    public partial class MarketProducts
    {
        public int MarketProductsId { get; set; }
        public int MarketId { get; set; }
        public int ProductId { get; set; }

        public Markets Market { get; set; }
        public Products Product { get; set; }
    }
}
