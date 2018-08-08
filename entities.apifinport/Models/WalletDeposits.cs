using System;
using System.Collections.Generic;

namespace FinPort.Entities.Models
{
    public partial class WalletDeposits
    {
        public int WalletDepositId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public decimal Amount { get; set; }
        public int WalletId { get; set; }

        public Wallets Wallet { get; set; }
    }
}
