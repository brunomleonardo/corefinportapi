using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FinPort.Core.DtoModels.Infrastructure;
using FinPort.Core.Models;

namespace FinPort.Core.DtoModels
{
    public class ExchangeProductsDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int ExchangeProductId { get; set; }
        public int ExchangeId { get; set; }
        public int ProductId { get; set; }
        public string ExchangeSymbol { get; set; }
        public int ExchangeCurrencyCurrencyId { get; set; }
        public string ExchangeCurrencySymbol { get; set; }
        public string ExchangeCurrencyDesignation { get; set; }
        public string ExchangeCurrencyName { get; set; }
        public IEnumerable<ExchangesDTO> ExchangeCurrencyExchanges { get; set; }
        public int ExchangeExchangeTaxesExchangeTaxId { get; set; }
        public decimal ExchangeExchangeTaxesTaxValue { get; set; }
        public int ProductProductId { get; set; }
        public string ProductAbbv { get; set; }
        public string ProductCompany { get; set; }
        public decimal? ProductCurrentPrice { get; set; }
        public decimal? ProductTechnicalValueLast { get; set; }
    }

    public class ExchangeProductsMapper : MapperBase<ExchangeProducts, ExchangeProductsDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<ExchangeProducts, ExchangeProductsDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<ExchangeProducts, ExchangeProductsDTO>>)(p => new ExchangeProductsDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ExchangeProductId = p.ExchangeProductId,
                    ExchangeId = p.ExchangeId,
                    ProductId = p.ProductId,
                    ExchangeSymbol = p.Exchange != null ? p.Exchange.Symbol : default(string),
                    ExchangeCurrencyCurrencyId = p.Exchange != null && p.Exchange.Currency != null ? p.Exchange.Currency.CurrencyId : default(int),
                    ExchangeCurrencySymbol = p.Exchange != null && p.Exchange.Currency != null ? p.Exchange.Currency.Symbol : default(string),
                    ExchangeCurrencyDesignation = p.Exchange != null && p.Exchange.Currency != null ? p.Exchange.Currency.Designation : default(string),
                    ExchangeCurrencyName = p.Exchange != null && p.Exchange.Currency != null ? p.Exchange.Currency.Name : default(string),
                    ExchangeExchangeTaxesExchangeTaxId = p.Exchange != null && p.Exchange.ExchangeTaxes != null ? p.Exchange.ExchangeTaxes.ExchangeTaxId : default(int),
                    ExchangeExchangeTaxesTaxValue = p.Exchange != null && p.Exchange.ExchangeTaxes != null ? p.Exchange.ExchangeTaxes.TaxValue : default(decimal),
                    ProductProductId = p.Product != null ? p.Product.ProductId : default(int),
                    ProductAbbv = p.Product != null ? p.Product.Abbv : default(string),
                    ProductCompany = p.Product != null ? p.Product.Company : default(string),
                    ProductCurrentPrice = p.Product != null ? p.Product.CurrentPrice : default(decimal?),
                    ProductTechnicalValueLast = p.Product != null && p.Product.TechnicalValue != null ? p.Product.TechnicalValue.Last : default(decimal?)
                }));
            }
        }

        public override void MapToModel(ExchangeProductsDTO dto, ExchangeProducts model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ExchangeProductId = dto.ExchangeProductId;
            model.ExchangeId = dto.ExchangeId;
            model.ProductId = dto.ProductId;

        }
    }
}
