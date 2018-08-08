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
    public class TechnicalValuesDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int TechnicalValueId { get; set; }
        public decimal? Last { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public decimal? Change { get; set; }
        public decimal? ChangePerc { get; set; }
        public decimal? PrfDaily { get; set; }
        public decimal? Prf1Week { get; set; }
        public decimal? Prf1Month { get; set; }
        public decimal? PrfYtd { get; set; }
        public decimal? Prf1Years { get; set; }
        public decimal? Prf3Years { get; set; }
        public IEnumerable<MajorIndicesDTO> MajorIndices { get; set; }
        public IEnumerable<ProductsDTO> Products { get; set; }
    }

    public class TechnicalValuesMapper : MapperBase<TechnicalValues, TechnicalValuesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private MajorIndicesMapper _majorIndicesMapper = new MajorIndicesMapper();
        private ProductsMapper _productsMapper = new ProductsMapper();
        public override Expression<Func<TechnicalValues, TechnicalValuesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<TechnicalValues, TechnicalValuesDTO>>)(p => new TechnicalValuesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    TechnicalValueId = p.TechnicalValueId,
                    Last = p.Last,
                    High = p.High,
                    Low = p.Low,
                    Change = p.Change,
                    ChangePerc = p.ChangePerc,
                    PrfDaily = p.PrfDaily,
                    Prf1Week = p.Prf1Week,
                    Prf1Month = p.Prf1Month,
                    PrfYtd = p.PrfYtd,
                    Prf1Years = p.Prf1Years,
                    Prf3Years = p.Prf3Years,
                    MajorIndices = p.MajorIndices.AsQueryable().Select(this._majorIndicesMapper.SelectorExpression),
                    Products = p.Products.AsQueryable().Select(this._productsMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(TechnicalValuesDTO dto, TechnicalValues model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.TechnicalValueId = dto.TechnicalValueId;
            model.Last = dto.Last;
            model.High = dto.High;
            model.Low = dto.Low;
            model.Change = dto.Change;
            model.ChangePerc = dto.ChangePerc;
            model.PrfDaily = dto.PrfDaily;
            model.Prf1Week = dto.Prf1Week;
            model.Prf1Month = dto.Prf1Month;
            model.PrfYtd = dto.PrfYtd;
            model.Prf1Years = dto.Prf1Years;
            model.Prf3Years = dto.Prf3Years;
        }
    }
}
