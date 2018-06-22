
using System;

namespace cmodels.apifinport.Interfaces
{
    public interface IStatus {
        DateTime CreatedOn {get; set;}
        string CreatedBy {get; set;}
        DateTime ModifiedOn {get; set;}
        string ModifiedBy {get; set;}
    }
    
}