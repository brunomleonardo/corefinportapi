using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entities.apifinport.Entities
{
    public class WalletEntity
    {
        public int id { get; set; }
        public decimal amount { get; set; }
        public int currencyId { get; set; }
        public CurrencyEntity currency { get; set; }
        public List<WalletDepositsEntity> deposits { get; set; }
    }
}