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
    public class UserOperationHistoriesDTO : BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public decimal BuyPrice { get; set; }
        public decimal ConversionValue { get; set; }
        public int Amount { get; set; }
        public decimal TotalConverted { get; set; }
        public decimal? FeeValue { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }

    public class UserOperationHistoriesMapper : MapperBase<UserOperationHistories, UserOperationHistoriesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private BaseEntityMapper _baseEntityMapper = new BaseEntityMapper();
        public override Expression<Func<UserOperationHistories, UserOperationHistoriesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<UserOperationHistories, UserOperationHistoriesDTO>>)(p => new UserOperationHistoriesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    BuyPrice = p.BuyPrice,
                    ConversionValue = p.ConversionValue,
                    Amount = p.Amount,
                    TotalConverted = p.TotalConverted,
                    FeeValue = p.FeeValue,
                    Total = p.Total,
                    UserId = p.UserId,
                    ProductId = p.ProductId,
                })).MergeWith(this._baseEntityMapper.SelectorExpression);
            }
        }

        public override void MapToModel(UserOperationHistoriesDTO dto, UserOperationHistories model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.BuyPrice = dto.BuyPrice;
            model.ConversionValue = dto.ConversionValue;
            model.Amount = dto.Amount;
            model.TotalConverted = dto.TotalConverted;
            model.FeeValue = dto.FeeValue;
            model.Total = dto.Total;
            model.UserId = dto.UserId;
            model.ProductId = dto.ProductId;
            this._baseEntityMapper.MapToModel(dto, model);
        }
    }
}
