using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using entities.apifinport.DtoModels.Infrastructure;
using entities.apifinport.Models;

namespace entities.apifinport.DtoModels
{
    public class ProductsDTO : BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public string Abbv { get; set; }
        public string Company { get; set; }
        public string Currency { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? Change { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string MarketCap { get; set; }
        public string Href { get; set; }
        public int ExchangeId { get; set; }
        public string ExchangeDesignation { get; set; }
        public string ExchangeSymbol { get; set; }
        public int ExchangeCurrencyId { get; set; }
        public string ExchangeCurrencySymbol { get; set; }
        public string ExchangeCurrencyDesignation { get; set; }
        public string ExchangeCurrencyName { get; set; }
    }

    public class ProductsMapper : MapperBase<Products, ProductsDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private BaseEntityMapper _baseEntityMapper = new BaseEntityMapper();
        public override Expression<Func<Products, ProductsDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Products, ProductsDTO>>)(p => new ProductsDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Abbv = p.Abbv,
                    Company = p.Company,
                    Currency = p.Currency,
                    CurrentPrice = p.CurrentPrice,
                    Change = p.Change,
                    Sector = p.Sector,
                    Industry = p.Industry,
                    MarketCap = p.MarketCap,
                    Href = p.Href,
                    ExchangeDesignation = p.Exchange != null ? p.Exchange.Designation : default(string),
                    ExchangeSymbol = p.Exchange != null ? p.Exchange.Symbol : default(string),
                    ExchangeCurrencySymbol = p.Exchange != null && p.Exchange.Currency != null ? p.Exchange.Currency.Symbol : default(string),
                    ExchangeCurrencyDesignation = p.Exchange != null && p.Exchange.Currency != null ? p.Exchange.Currency.Designation : default(string),
                    ExchangeCurrencyName = p.Exchange != null && p.Exchange.Currency != null ? p.Exchange.Currency.Name : default(string),
                    ExchangeCurrencyId = p.Exchange != null && p.Exchange.Currency != null ? p.Exchange.Currency.Id : default(int),
                    ExchangeId = p.Exchange != null ? p.Exchange.Id : default(int),
                })).MergeWith(this._baseEntityMapper.SelectorExpression);
            }
        }

        public override void MapToModel(ProductsDTO dto, Products model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Abbv = dto.Abbv;
            model.Company = dto.Company;
            model.Currency = dto.Currency;
            model.CurrentPrice = dto.CurrentPrice;
            model.Change = dto.Change;
            model.Sector = dto.Sector;
            model.Industry = dto.Industry;
            model.MarketCap = dto.MarketCap;
            model.Href = dto.Href;
            model.ExchangeId = dto.ExchangeId;
            this._baseEntityMapper.MapToModel(dto, model);
        }
    }
}
