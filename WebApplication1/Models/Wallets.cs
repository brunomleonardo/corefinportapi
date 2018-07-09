using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Wallets
    {
        public Wallets()
        {
            WalletDeposits = new HashSet<WalletDeposits>();
        }

        public int WalletId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public decimal Amount { get; set; }

        public Currencies Wallet { get; set; }
        public Users Users { get; set; }
        public ICollection<WalletDeposits> WalletDeposits { get; set; }
    }
}
