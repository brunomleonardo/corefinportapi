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
    public class MarketProductsDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int MarketProductsId { get; set; }
        public int MarketId { get; set; }
        public int ProductId { get; set; }
        public string MarketDesignation { get; set; }
        public string ProductAbbv { get; set; }
        public string ProductCompany { get; set; }
        public decimal? ProductCurrentPrice { get; set; }
        public decimal? ProductTechnicalValueLast { get; set; }
    }

    public class MarketProductsMapper : MapperBase<MarketProducts, MarketProductsDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<MarketProducts, MarketProductsDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<MarketProducts, MarketProductsDTO>>)(p => new MarketProductsDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    MarketProductsId = p.MarketProductsId,
                    MarketId = p.MarketId,
                    ProductId = p.ProductId,
                    MarketDesignation = p.Market != null ? p.Market.Designation : default(string),
                    ProductAbbv = p.Product != null ? p.Product.Abbv : default(string),
                    ProductCompany = p.Product != null ? p.Product.Company : default(string),
                    ProductCurrentPrice = p.Product != null ? p.Product.CurrentPrice : default(decimal?),
                    ProductTechnicalValueLast = p.Product != null && p.Product.TechnicalValue != null ? p.Product.TechnicalValue.Last : default(decimal?)
                }));
            }
        }

        public override void MapToModel(MarketProductsDTO dto, MarketProducts model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.MarketProductsId = dto.MarketProductsId;
            model.MarketId = dto.MarketId;
            model.ProductId = dto.ProductId;

        }
    }
}
