using entities.apifinport.Entities;

namespace entities.apifinport.Models
{
    public class Currency : BaseEntity
    {
        public string Symbol { get; set; }
        public string Designation { get; set; }
    }
}