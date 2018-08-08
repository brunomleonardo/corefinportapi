using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FinPort.Core.DtoModels.Infrastructure;
using FinPort.Core.DtoModels;

namespace FinPort.Core.DtoModels
{
    public class BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class BaseEntityMapper : MapperBase<BaseEntity, BaseEntityDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<BaseEntity, BaseEntityDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<BaseEntity, BaseEntityDTO>>)(p => new BaseEntityDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    //Id = p.Id,
                    Deleted = p.Deleted,
                    CreatedOn = p.CreatedOn,
                    CreatedBy = p.CreatedBy,
                    ModifiedOn = p.ModifiedOn,
                    ModifiedBy = p.ModifiedBy
                }));
            }
        }

        public override void MapToModel(BaseEntityDTO dto, BaseEntity model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            //model.Id = dto.Id;
            model.Deleted = dto.Deleted;
            model.CreatedOn = dto.CreatedOn;
            model.CreatedBy = dto.CreatedBy;
            model.ModifiedOn = dto.ModifiedOn;
            model.ModifiedBy = dto.ModifiedBy;

        }
    }
}
