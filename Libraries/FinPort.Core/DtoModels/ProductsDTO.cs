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
    public class ProductsDTO
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
        public int TechnicalValueTechnicalValueId { get; set; }
        public decimal? TechnicalValueLast { get; set; }
        public IEnumerable<ExchangeProductsDTO> ExchangeProducts { get; set; }
        public IEnumerable<MarketProductsDTO> MarketProducts { get; set; }
        public IEnumerable<UserOperationHistoriesDTO> UserOperationHistories { get; set; }
    }

    public class ProductsMapper : MapperBase<Products, ProductsDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private ExchangeProductsMapper _exchangeProductsMapper = new ExchangeProductsMapper();
        private MarketProductsMapper _marketProductsMapper = new MarketProductsMapper();
        private UserOperationHistoriesMapper _userOperationHistoriesMapper = new UserOperationHistoriesMapper();
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
                    TechnicalValueTechnicalValueId = p.TechnicalValue != null ? p.TechnicalValue.TechnicalValueId : default(int),
                    TechnicalValueLast = p.TechnicalValue != null ? p.TechnicalValue.Last : default(decimal?),
                    ExchangeProducts = p.ExchangeProducts.AsQueryable().Select(this._exchangeProductsMapper.SelectorExpression),
                    MarketProducts = p.MarketProducts.AsQueryable().Select(this._marketProductsMapper.SelectorExpression),
                    UserOperationHistories = p.UserOperationHistories.AsQueryable().Select(this._userOperationHistoriesMapper.SelectorExpression)
                }));
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
        }
    }
}
