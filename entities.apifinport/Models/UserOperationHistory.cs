using entities.apifinport.Models;
using entities.apifinport.Entities;
using System.ComponentModel.DataAnnotations;

namespace entities.apifinport.Models
{
    public class UserOperationHistory : BaseEntity
    {
        [Key]
        public override int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TickerId { get; set; }
        public Ticker Ticker { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal ConversionValue { get; set; }
        public int Amount { get; set; }
        public decimal TotalConverted { get; set; }
        public decimal Total { get; set; }

        public static explicit operator UserOperationHistory(UserOperationHistoryEntity Entity)
        {
            return new UserOperationHistory()
            {
                BuyPrice = Entity.buyPrice,
                ConversionValue = Entity.conversionUSD,
                Amount = Entity.amount,
                TotalConverted = Entity.totalConverted,
                Total = Entity.total
            };
        }
    }
}