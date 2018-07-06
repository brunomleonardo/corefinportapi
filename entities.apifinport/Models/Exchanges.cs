using entities.apifinport.Entities;
using System;
using System.Collections.Generic;

namespace entities.apifinport.Models
{
    public partial class Exchanges : BaseEntity
    {
        public Exchanges()
        {
            Products = new HashSet<Products>();
        }

        public string Designation { get; set; }
        public string Symbol { get; set; }
        public int CurrencyId { get; set; }

        public Currencies Currency { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
