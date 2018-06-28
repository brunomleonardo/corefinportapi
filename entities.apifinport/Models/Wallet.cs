using System.Collections.Generic;
using entities.apifinport.Entities;

namespace entities.apifinport.Models
{
    public class Wallet : BaseEntity
    {
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<WalletDeposit> WalletDeposits { get; set; }
    }
}