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
    public class ExchangesDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int ExchangeId { get; set; }
        public string Designation { get; set; }
        public string Symbol { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyDesignation { get; set; }
        public string CurrencyName { get; set; }
        public decimal ExchangeTaxesTaxValue { get; set; }
        public IEnumerable<ExchangeProductsDTO> ExchangeProducts { get; set; }
    }

    public class ExchangesMapper : MapperBase<Exchanges, ExchangesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private ExchangeProductsMapper _exchangeProductsMapper = new ExchangeProductsMapper();
        public override Expression<Func<Exchanges, ExchangesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Exchanges, ExchangesDTO>>)(p => new ExchangesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ExchangeId = p.ExchangeId,
                    Designation = p.Designation,
                    Symbol = p.Symbol,
                    CurrencyId = p.CurrencyId,
                    CurrencySymbol = p.Currency != null ? p.Currency.Symbol : default(string),
                    CurrencyDesignation = p.Currency != null ? p.Currency.Designation : default(string),
                    CurrencyName = p.Currency != null ? p.Currency.Name : default(string),
                    ExchangeTaxesTaxValue = p.ExchangeTaxes != null ? p.ExchangeTaxes.TaxValue : default(decimal),
                    ExchangeProducts = p.ExchangeProducts.AsQueryable().Select(this._exchangeProductsMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(ExchangesDTO dto, Exchanges model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ExchangeId = dto.ExchangeId;
            model.Designation = dto.Designation;
            model.Symbol = dto.Symbol;
            model.CurrencyId = dto.CurrencyId;
        }
    }
}
