﻿using entities.apifinport.DtoModels;
using entities.apifinport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dal.apifinport.Interfaces
{
    public interface IUserOperationsService : IBaseService<JResponseEntity<UserOperationHistoryEntity>, UserOperationHistories>
    {
        Task<JResponseEntity<IEnumerable<UserOperationHistoryEntity>>> GetMultipleByIdAsync(int Id);
    }
}
