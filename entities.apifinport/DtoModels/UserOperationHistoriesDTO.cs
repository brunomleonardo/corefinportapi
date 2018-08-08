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
    public class UserOperationHistoriesDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int UserOperationId { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal ConversionValue { get; set; }
        public int Amount { get; set; }
        public decimal TotalConverted { get; set; }
        public decimal? FeeValue { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductAbbv { get; set; }
        public string ProductCompany { get; set; }
        public decimal? ProductCurrentPrice { get; set; }
        public int ProductTechnicalValueTechnicalValueId { get; set; }
        public decimal? ProductTechnicalValueLast { get; set; }
        public int UserUserId { get; set; }
        public string UserUsername { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public decimal UserUserAmount { get; set; }
    }

    public class UserOperationHistoriesMapper : MapperBase<UserOperationHistories, UserOperationHistoriesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<UserOperationHistories, UserOperationHistoriesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<UserOperationHistories, UserOperationHistoriesDTO>>)(p => new UserOperationHistoriesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    UserOperationId = p.UserOperationId,
                    BuyPrice = p.BuyPrice,
                    ConversionValue = p.ConversionValue,
                    Amount = p.Amount,
                    TotalConverted = p.TotalConverted,
                    FeeValue = p.FeeValue,
                    Total = p.Total,
                    UserId = p.UserId,
                    ProductId = p.ProductId,
                    ProductAbbv = p.Product != null ? p.Product.Abbv : default(string),
                    ProductCompany = p.Product != null ? p.Product.Company : default(string),
                    ProductCurrentPrice = p.Product != null ? p.Product.CurrentPrice : default(decimal?),
                    ProductTechnicalValueTechnicalValueId = p.Product != null && p.Product.TechnicalValue != null ? p.Product.TechnicalValue.TechnicalValueId : default(int),
                    ProductTechnicalValueLast = p.Product != null && p.Product.TechnicalValue != null ? p.Product.TechnicalValue.Last : default(decimal?),
                    UserUserId = p.User != null ? p.User.UserId : default(int),
                    UserUsername = p.User != null ? p.User.Username : default(string),
                    UserFirstName = p.User != null ? p.User.FirstName : default(string),
                    UserLastName = p.User != null ? p.User.LastName : default(string),
                    UserUserAmount = p.User != null && p.User.User != null ? p.User.User.Amount : default(decimal)
                }));
            }
        }

        public override void MapToModel(UserOperationHistoriesDTO dto, UserOperationHistories model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.UserOperationId = dto.UserOperationId;
            model.BuyPrice = dto.BuyPrice;
            model.ConversionValue = dto.ConversionValue;
            model.Amount = dto.Amount;
            model.TotalConverted = dto.TotalConverted;
            model.FeeValue = dto.FeeValue;
            model.Total = dto.Total;
            model.UserId = dto.UserId;
            model.ProductId = dto.ProductId;
        }
    }
}
