using System;
using System.Collections.Generic;

namespace FinPort.Core.Models
{
    public partial class Currencies : BaseEntity
    {
        public Currencies()
        {
            Exchanges = new HashSet<Exchanges>();
            Wallets = new HashSet<Wallets>();
        }

        public int CurrencyId { get; set; }
        public string Symbol { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }

        public ICollection<Exchanges> Exchanges { get; set; }
        public ICollection<Wallets> Wallets { get; set; }
    }
}
