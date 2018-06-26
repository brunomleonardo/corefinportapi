using dal.apifinport.Context;
using dal.apifinport.DataAccess;
using entities.apifinport.Entities;
using entities.apifinport.Models;
using utils.apifinport;

namespace bll.apifinport
{
    public class UserOperationsBLL
    {
        private UserOperationsDAL _UserOperationsDAL;
        public UserOperationsBLL(FinPortContext _context)
        {
            this._UserOperationsDAL = new UserOperationsDAL(_context);
        }

        public JResponseEntity<UserOperationHistoryEntity> AddOperation(UserOperationHistory Entity)
        {
            JResponseEntity<UserOperationHistoryEntity> RObj = new JResponseEntity<UserOperationHistoryEntity>();
            if (Entity.Amount != 0 && Entity.BuyPrice != 0 && Entity.Total != 0 && Entity.TotalConverted != 0)
            {
                RObj = _UserOperationsDAL.Create(Entity);
                RObj.Message = "Added with success.";
            }
            else
            {
                RObj.Message = "Fields are missing.";
            }
            return RObj;
        }
    }
}