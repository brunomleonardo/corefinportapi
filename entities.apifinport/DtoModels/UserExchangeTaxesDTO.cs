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
    public class UserExchangeTaxesDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExchangeTaxeId { get; set; }
        public decimal ExchangeTaxeTaxValue { get; set; }
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
                    Id = p.Id,
                    UserId = p.UserId,
                    ExchangeTaxeId = p.ExchangeTaxeId,
                    ExchangeTaxeTaxValue = p.ExchangeTaxe != null ? p.ExchangeTaxe.TaxValue : default(decimal),
                }));
            }
        }

        public override void MapToModel(UserExchangeTaxesDTO dto, UserExchangeTaxes model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Id = dto.Id;
            model.UserId = dto.UserId;
            model.ExchangeTaxeId = dto.ExchangeTaxeId;

        }
    }
}
