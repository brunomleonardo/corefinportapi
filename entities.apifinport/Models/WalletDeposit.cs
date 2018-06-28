using entities.apifinport.Entities;

namespace entities.apifinport.Models
{
    public class WalletDeposit : BaseEntity
    {
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}