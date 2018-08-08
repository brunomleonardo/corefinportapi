using FinPort.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinPort.Services.Currency
{
    public partial interface ICurrencyService
    {
        IEnumerable<Currencies> GetAll();
    }
}
