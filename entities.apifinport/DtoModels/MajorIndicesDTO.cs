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
    public class MajorIndicesDTO : BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public string Designation { get; set; }
    }

    public class MajorIndicesMapper : MapperBase<MajorIndices, MajorIndicesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private BaseEntityMapper _baseEntityMapper = new BaseEntityMapper();
        public override Expression<Func<MajorIndices, MajorIndicesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<MajorIndices, MajorIndicesDTO>>)(p => new MajorIndicesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Designation = p.Designation,
                })).MergeWith(this._baseEntityMapper.SelectorExpression);
            }
        }

        public override void MapToModel(MajorIndicesDTO dto, MajorIndices model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Designation = dto.Designation;
            this._baseEntityMapper.MapToModel(dto, model);
        }
    }
}
