using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Currencies
    {
        public Currencies()
        {
            Exchanges = new HashSet<Exchanges>();
            Wallets = new HashSet<Wallets>();
        }

        public int CurrencyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string Symbol { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }

        public ICollection<Exchanges> Exchanges { get; set; }
        public ICollection<Wallets> Wallets { get; set; }
    }
}
