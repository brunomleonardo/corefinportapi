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
    public class MarketsDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int MarketId { get; set; }
        public string Designation { get; set; }
        public IEnumerable<MarketProductsDTO> MarketProducts { get; set; }
    }

    public class MarketsMapper : MapperBase<Markets, MarketsDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private MarketProductsMapper _marketProductsMapper = new MarketProductsMapper();
        public override Expression<Func<Markets, MarketsDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Markets, MarketsDTO>>)(p => new MarketsDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    MarketId = p.MarketId,
                    Designation = p.Designation,
                    MarketProducts = p.MarketProducts.AsQueryable().Select(this._marketProductsMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(MarketsDTO dto, Markets model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.MarketId = dto.MarketId;
            model.Designation = dto.Designation;
        }
    }
}
