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
    public class UserExchangeTaxesDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int UserId { get; set; }
        public int ExchangeTaxeId { get; set; }
        public decimal ExchangeTaxeTaxValue { get; set; }
        public string ExchangeTaxeExchangeTaxDesignation { get; set; }
        public string ExchangeTaxeExchangeTaxSymbol { get; set; }
    }

    public class UserExchangeTaxesMapper : MapperBase<UserExchangeTaxes, UserExchangeTaxesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 

        public override Expression<Func<UserExchangeTaxes, UserExchangeTaxesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<UserExchangeTaxes, UserExchangeTaxesDTO>>)(p => new UserExchangeTaxesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    UserId = p.UserId,
                    ExchangeTaxeId = p.ExchangeTaxeId,
                    ExchangeTaxeTaxValue = p.ExchangeTaxe != null ? p.ExchangeTaxe.TaxValue : default(decimal),
                    ExchangeTaxeExchangeTaxDesignation = p.ExchangeTaxe != null && p.ExchangeTaxe.ExchangeTax != null ? p.ExchangeTaxe.ExchangeTax.Designation : default(string),
                    ExchangeTaxeExchangeTaxSymbol = p.ExchangeTaxe != null && p.ExchangeTaxe.ExchangeTax != null ? p.ExchangeTaxe.ExchangeTax.Symbol : default(string)
                }));
            }
        }

        public override void MapToModel(UserExchangeTaxesDTO dto, UserExchangeTaxes model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.UserId = dto.UserId;
            model.ExchangeTaxeId = dto.ExchangeTaxeId;

        }
    }
}
