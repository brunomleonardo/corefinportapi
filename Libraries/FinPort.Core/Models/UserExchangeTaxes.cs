using System;
using System.Collections.Generic;

namespace FinPort.Core.Models
{
    public partial class UserExchangeTaxes
    {
        public int UserExchangeTaxId { get; set; }
        public int UserId { get; set; }
        public int ExchangeTaxeId { get; set; }

        public ExchangeTaxes ExchangeTaxe { get; set; }
        public Users User { get; set; }
    }
}
