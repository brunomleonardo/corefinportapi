using entities.apifinport.Entities;
using System;
using System.Collections.Generic;

namespace entities.apifinport.Models
{
    public partial class Wallets : BaseEntity
    {
        public Wallets()
        {
            WalletDeposits = new HashSet<WalletDeposits>();
        }

        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public int UserId { get; set; }

        public Currencies Currency { get; set; }
        public Users User { get; set; }
        public ICollection<WalletDeposits> WalletDeposits { get; set; }
    }
}
