using dal.apifinport.Context;
using dal.apifinport.DataAccess;
using dal.apifinport.Interfaces;
using entities.apifinport.Entities;
using entities.apifinport.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using utils.apifinport;

namespace bll.apifinport
{
    public class UserOperationsBLL
    {
        private readonly IUserOperationsService _UserOperationsService;
        public UserOperationsBLL(IUserOperationsService UserOperationsService)
        {
            _UserOperationsService = UserOperationsService ?? throw new ArgumentException(nameof(UserOperationsService));
        }

        public async Task<JResponseEntity<UserOperationHistoryEntity>> AddOperation(UserOperationHistoryEntity Entity)
        {
            JResponseEntity<UserOperationHistoryEntity> RObj = new JResponseEntity<UserOperationHistoryEntity>();
            if (Entity.amount != 0 && Entity.buyPrice != 0 && Entity.total != 0 && Entity.totalConverted != 0)
            {
                UserOperationHistories UserOpEntity = null; // (UserOperationHistories)Entity;
                UserOpEntity.UserId = Entity.userId;
                //UserOpEntity.ProductsId = Entity.ProductsId;

                RObj = await _UserOperationsService.CreateAsync(UserOpEntity);
                RObj.Message = "Added with success.";
            }
            else
            {
                RObj.Message = "Fields are missing.";
            }
            return RObj;
        }

        public async Task<JResponseEntity<IEnumerable<UserOperationHistoryEntity>>> GetUserOperations(int UserId)
        {
            JResponseEntity<IEnumerable<UserOperationHistoryEntity>> RObj = new JResponseEntity<IEnumerable<UserOperationHistoryEntity>>();
            if (UserId != 0)
            {
                RObj = await _UserOperationsService.GetMultipleByIdAsync(UserId);
                RObj.Message = "Data returned with success.";
            }
            else
            {
                RObj.Message = "Invalid User Id.";
            }
            return RObj;
        }
    }
}