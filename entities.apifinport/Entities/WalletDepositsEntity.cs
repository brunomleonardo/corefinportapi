namespace entities.apifinport.Entities
{
    public class WalletDepositsEntity 
    {
        public int id { get; set; }
        public decimal amount { get; set; }
        public WalletDepositsEntity()
        {
            amount = 0;
        }
    }
}