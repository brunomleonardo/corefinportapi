using System;
using System.Collections.Generic;

namespace FinPort.Entities.Models
{
    public partial class UserOperationHistories
    {
        public int UserOperationId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool Deleted { get; set; }
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
