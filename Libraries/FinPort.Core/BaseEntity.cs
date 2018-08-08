using System;

namespace FinPort.Core
{
    public abstract partial class BaseEntity : IEntity
    {
        //public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public BaseEntity()
        {
            CreatedBy = string.Empty;
            CreatedOn = DateTime.Now;
            ModifiedBy = string.Empty;
            ModifiedOn = DateTime.Now;
        }
    }
}