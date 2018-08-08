using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FinPort.Core.DtoModels.Infrastructure;
using FinPort.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace FinPort.Core.DtoModels
{
    public class CurrenciesDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int CurrencyId { get; set; }
        public string Symbol { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
    }

    public class CurrenciesMapper : MapperBase<Currencies, CurrenciesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<Currencies, CurrenciesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Currencies, CurrenciesDTO>>)(p => new CurrenciesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    CurrencyId = p.CurrencyId,
                    Symbol = p.Symbol,
                    Designation = p.Designation,
                    Name = p.Name
                }));
            }
        }

        public override void MapToModel(CurrenciesDTO dto, Currencies model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.CurrencyId = dto.CurrencyId;
            model.Symbol = dto.Symbol;
            model.Designation = dto.Designation;
            model.Name = dto.Name;
        }
    }
}
