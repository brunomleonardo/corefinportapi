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
    public class MarketsDTO : BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public string Designation { get; set; }
    }

    public class MarketsMapper : MapperBase<Markets, MarketsDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private BaseEntityMapper _baseEntityMapper = new BaseEntityMapper();
        public override Expression<Func<Markets, MarketsDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Markets, MarketsDTO>>)(p => new MarketsDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Designation = p.Designation
                })).MergeWith(this._baseEntityMapper.SelectorExpression);
            }
        }

        public override void MapToModel(MarketsDTO dto, Markets model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Designation = dto.Designation;
            this._baseEntityMapper.MapToModel(dto, model);
        }
    }
}
