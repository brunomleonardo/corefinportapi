using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal.apifinport.Context;
using dal.apifinport.Interfaces;
using entities.apifinport.Entities;
using entities.apifinport.Models;
using Microsoft.EntityFrameworkCore;

namespace dal.apifinport.DataAccess
{
    public class UserOperationsDAL : IUserOperationsService
    {
        private readonly FinPortContext _context;

        public UserOperationsDAL(FinPortContext context)
        {
            _context = context;
        }

        public Task<JResponseEntity<UserOperationHistoryEntity>> CreateAsync(UserOperationHistories Entity)
        {
            JResponseEntity<UserOperationHistoryEntity> ResponseObj = new JResponseEntity<UserOperationHistoryEntity>();
            try
            {
                //_context.UserOperationHistories.Add(Entity);
                //_context.SaveChanges();
                //ResponseObj.Status = true;
                //ResponseObj.Data = new UserOperationHistoryEntity()
                //{
                //    id = Entity.Id,
                //    buyPrice = Entity.BuyPrice,
                //    conversionUSD = Entity.ConversionValue,
                //    amount = Entity.Amount,
                //    totalConverted = Entity.TotalConverted,
                //    total = Entity.Total,
                //    userId = Entity.User.Id,
                //    ProductId = Entity.Product.Id
                //};
            }
            catch (Exception e)
            {
                ResponseObj.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return Task.FromResult(ResponseObj);
        }

        public Task<JResponseEntity<UserOperationHistoryEntity>> ReadOneAsync(int Id, string Name)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<UserOperationHistoryEntity>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<UserOperationHistoryEntity>> CreateMultipleAsync(List<UserOperationHistories> Data)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<UserOperationHistoryEntity>> UpdateAsync(UserOperationHistories Entity)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<UserOperationHistoryEntity>> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<UserOperationHistoryEntity>> ReadMultipleByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<IEnumerable<UserOperationHistoryEntity>>> GetMultipleByIdAsync(int Id)
        {
            JResponseEntity<IEnumerable<UserOperationHistoryEntity>> RObj = new JResponseEntity<IEnumerable<UserOperationHistoryEntity>>();
            try
            {
                //List<UserOperationHistories> Data
                //    = _context.UserOperationHistories
                //    .Where(x => x.UserId == Id).ToList();
                //if (Data != null && Data.Count > 0)
                //{
                //    RObj.Data = Data.Select(x => new UserOperationHistoryEntity()
                //    {
                //        amount = x.Amount,
                //        Products = new ProductsEntity()
                //        {
                //            abbv = x.Products.Abbv,
                //            company = x.Products.Company,
                //            current_price = x.Products.CurrentPrice
                //        },
                //        buyPrice = x.BuyPrice,
                //        conversionUSD = x.ConversionValue,
                //        total = x.Total,
                //        totalConverted = x.TotalConverted,
                //        feeValue = x.FeeValue
                //    }).ToList();
                //}
                //RObj.Status = true;
            }
            catch (Exception e)
            {
                RObj.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return Task.FromResult(RObj);
        }
   }
}