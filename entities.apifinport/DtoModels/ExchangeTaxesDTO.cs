using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using entities.apifinport.DtoModels.Infrastructure;
using FinPort.Entities;

namespace entities.apifinport.DtoModels
{
    public class ExchangeTaxesDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public decimal TaxValue { get; set; }
        public string ExchangeTaxDesignation { get; set; }
        public string ExchangeTaxSymbol { get; set; }
        public string ExchangeTaxCurrencySymbol { get; set; }
        public string ExchangeTaxCurrencyDesignation { get; set; }
        public string ExchangeTaxCurrencyName { get; set; }
        public decimal ExchangeTaxExchangeTaxesTaxValue { get; set; }
    }

    public class ExchangeTaxesMapper : MapperBase<ExchangeTaxes, ExchangeTaxesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<ExchangeTaxes, ExchangeTaxesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<ExchangeTaxes, ExchangeTaxesDTO>>)(p => new ExchangeTaxesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    TaxValue = p.TaxValue,
                    ExchangeTaxDesignation = p.ExchangeTax != null ? p.ExchangeTax.Designation : default(string),
                    ExchangeTaxSymbol = p.ExchangeTax != null ? p.ExchangeTax.Symbol : default(string),
                    ExchangeTaxCurrencySymbol = p.ExchangeTax != null && p.ExchangeTax.Currency != null ? p.ExchangeTax.Currency.Symbol : default(string),
                    ExchangeTaxCurrencyDesignation = p.ExchangeTax != null && p.ExchangeTax.Currency != null ? p.ExchangeTax.Currency.Designation : default(string),
                    ExchangeTaxCurrencyName = p.ExchangeTax != null && p.ExchangeTax.Currency != null ? p.ExchangeTax.Currency.Name : default(string),
                    ExchangeTaxExchangeTaxesTaxValue = p.ExchangeTax != null && p.ExchangeTax.ExchangeTaxes != null ? p.ExchangeTax.ExchangeTaxes.TaxValue : default(decimal)
                }));
            }
        }

        public override void MapToModel(ExchangeTaxesDTO dto, ExchangeTaxes model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.TaxValue = dto.TaxValue;
        }
    }
}
