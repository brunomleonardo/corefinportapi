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
    public class ExchangeTaxesDTO : BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public decimal TaxValue { get; set; }
        public int MajorIndiceId { get; set; }
        public string MajorIndiceDesignation { get; set; }
    }

    public class ExchangeTaxesMapper : MapperBase<ExchangeTaxes, ExchangeTaxesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private BaseEntityMapper _baseEntityMapper = new BaseEntityMapper();
        public override Expression<Func<ExchangeTaxes, ExchangeTaxesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<ExchangeTaxes, ExchangeTaxesDTO>>)(p => new ExchangeTaxesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    TaxValue = p.TaxValue,
                    MajorIndiceDesignation = p.MajorIndice != null ? p.MajorIndice.Designation : default(string),
                    MajorIndiceId = p.MajorIndice != null ? p.MajorIndice.Id : default(int),
                })).MergeWith(this._baseEntityMapper.SelectorExpression);
            }
        }

        public override void MapToModel(ExchangeTaxesDTO dto, ExchangeTaxes model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.TaxValue = dto.TaxValue;
            model.MajorIndiceId = dto.MajorIndiceId;
            this._baseEntityMapper.MapToModel(dto, model);
        }
    }
}
