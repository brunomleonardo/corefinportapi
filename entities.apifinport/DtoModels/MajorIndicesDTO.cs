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
    public class MajorIndicesDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int MajorIndiceId { get; set; }
        public string Designation { get; set; }
        public decimal? TechnicalValueLast { get; set; }
    }

    public class MajorIndicesMapper : MapperBase<MajorIndices, MajorIndicesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<MajorIndices, MajorIndicesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<MajorIndices, MajorIndicesDTO>>)(p => new MajorIndicesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    MajorIndiceId = p.MajorIndiceId,
                    Designation = p.Designation,
                    TechnicalValueLast = p.TechnicalValue != null ? p.TechnicalValue.Last : default(decimal?)
                }));
            }
        }

        public override void MapToModel(MajorIndicesDTO dto, MajorIndices model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.MajorIndiceId = dto.MajorIndiceId;
            model.Designation = dto.Designation;
        }
    }
}
