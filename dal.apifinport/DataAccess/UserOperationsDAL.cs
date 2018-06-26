using System;
using System.Linq;
using dal.apifinport.Context;
using dal.apifinport.Interfaces;
using entities.apifinport.Entities;
using entities.apifinport.Models;
using Microsoft.EntityFrameworkCore;

namespace dal.apifinport.DataAccess
{
    public class UserOperationsDAL : ICrud<JResponseEntity<UserOperationHistoryEntity>, UserOperationHistory>
    {
        private readonly FinPortContext _context;
        public UserOperationsDAL(FinPortContext context)
        {
            _context = context;
        }

        public JResponseEntity<UserOperationHistoryEntity> Create(UserOperationHistory Entity)
        {
            JResponseEntity<UserOperationHistoryEntity> ResponseObj = new JResponseEntity<UserOperationHistoryEntity>();
            try
            {
                _context.UserOperationHistories.Add(Entity);
                _context.SaveChanges();
                ResponseObj.Status = true;
                ResponseObj.Data = new UserOperationHistoryEntity()
                {
                    id = Entity.Id,
                    buyPrice = Entity.BuyPrice,
                    conversionUSD = Entity.ConversionValue,
                    amount = Entity.Amount,
                    totalConverted = Entity.TotalConverted,
                    total = Entity.Total,
                    userId = Entity.User.Id,
                    tickerId = Entity.Ticker.Id
                };
            }
            catch (Exception e)
            {
                ResponseObj.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return ResponseObj;
        }

        public JResponseEntity<UserOperationHistoryEntity> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<UserOperationHistoryEntity> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<UserOperationHistoryEntity> GetByText(string input)
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<UserOperationHistoryEntity> ReadAll()
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<UserOperationHistoryEntity> Recover(int Id)
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<UserOperationHistoryEntity> Update(UserOperationHistory Entity)
        {
            throw new NotImplementedException();
        }
    }
}