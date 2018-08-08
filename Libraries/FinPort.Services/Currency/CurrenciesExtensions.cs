using FinPort.Core.DtoModels;
using FinPort.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinPort.Services.Currency
{
    public partial class CurrenciesExtensions : BaseExtensions<Currencies, CurrenciesDTO>
    {
        public string example() { return null; }

        public Currencies MapToEntity(CurrenciesDTO entity2)
        {
            throw new NotImplementedException();
        }

        public CurrenciesDTO MapToModel(Currencies entity1)
        {
            return new CurrenciesDTO()
            {
                Designation = entity1.Designation,
                Name = entity1.Name,
                Symbol = entity1.Symbol,
                CurrencyId = entity1.CurrencyId
            };
        }
    }
}
