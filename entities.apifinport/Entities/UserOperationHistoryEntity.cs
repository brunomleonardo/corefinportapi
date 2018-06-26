
using System.ComponentModel.DataAnnotations;

namespace entities.apifinport.Entities
{
    public class UserOperationHistoryEntity
    {
        public int id { get; set; }
        public int tickerId { get; set; }
        public int userId { get; set; }
        public decimal buyPrice { get; set; }
        public decimal conversionUSD { get; set; }
        public int amount { get; set; }
        public decimal totalConverted { get; set; }
        public decimal total { get; set; }
    }
}