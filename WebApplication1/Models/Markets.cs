using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Markets
    {
        public Markets()
        {
            MarketProducts = new HashSet<MarketProducts>();
        }

        public int MarketId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string Designation { get; set; }

        public ICollection<MarketProducts> MarketProducts { get; set; }
    }
}
