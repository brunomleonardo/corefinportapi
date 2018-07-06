using entities.apifinport.Entities;
using System;
using System.Collections.Generic;

namespace entities.apifinport.Models
{
    public partial class UserOperationHistories : BaseEntity
    {
        public decimal BuyPrice { get; set; }
        public decimal ConversionValue { get; set; }
        public int Amount { get; set; }
        public decimal TotalConverted { get; set; }
        public decimal? FeeValue { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public Products Product { get; set; }
        public Users User { get; set; }
    }
}
