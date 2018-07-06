using entities.apifinport.Entities;
using System;
using System.Collections.Generic;

namespace entities.apifinport.Models
{
    public partial class WalletDeposits : BaseEntity
    {
        public decimal Amount { get; set; }
        public int WalletId { get; set; }

        public Wallets Wallet { get; set; }
    }
}
