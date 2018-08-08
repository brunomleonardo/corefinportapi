using System;
using System.Collections.Generic;

namespace FinPort.Core.Models
{
    public partial class Wallets : BaseEntity
    {
        public Wallets()
        {
            WalletDeposits = new HashSet<WalletDeposits>();
        }

        public int WalletId { get; set; }
        public decimal Amount { get; set; }

        public int CurrencyId { get; set; }
        public Currencies Currency { get; set; }
        public Users Users { get; set; }
        public ICollection<WalletDeposits> WalletDeposits { get; set; }
    }
}
