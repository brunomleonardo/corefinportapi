using System;
using System.Collections.Generic;
using System.Text;

namespace entities.apifinport.Entities
{
    public class ExchangeEntity
    {
        public int? id { get; set; }
        public string symbol { get; set; }
        public string designation { get; set; }
        public CurrencyEntity currency { get; set; }
    }
}
