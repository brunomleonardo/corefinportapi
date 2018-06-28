namespace entities.apifinport.Entities
{
    public class WalletDepositsEntity
    {
        public int id { get; set; }
        public decimal amount { get; set; }
        public int walletId { get; set; }
        public WalletEntity wallet { get; set; }
    }
}