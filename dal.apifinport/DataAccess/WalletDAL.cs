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
    public class WalletDAL : IWalletService
    {
        private readonly FinPortContext _context;

        public WalletDAL(FinPortContext context)
        {
            _context = context;
        }

        public Task<JResponseEntity<WalletEntity>> ReadOneAsync(int Id, string Name)
        {
            JResponseEntity<WalletEntity> ResponseObj = new JResponseEntity<WalletEntity>();
            try
            {
                //Wallet Wallet = _context.Wallets
                //.Include(o => o.Currency)
                //.Include(o => o.WalletDeposits)
                //.Where(x => x.UserId == Id).FirstOrDefault();
                //if (Wallet != null)
                //{
                //    ResponseObj.Status = true;
                //    ResponseObj.Data = new WalletEntity()
                //    {
                //        id = Wallet.Id,
                //        amount = Wallet.Amount,
                //        deposits = Wallet.WalletDeposits != null ? Wallet.WalletDeposits.Select(y => new WalletDepositsEntity()
                //        {
                //            amount = y.Amount
                //        }).ToList() : null,
                //        currency = Wallet.Currency != null ? new CurrencyEntity()
                //        {
                //            designation = Wallet.Currency.Designation,
                //            symbol = Wallet.Currency.Symbol
                //        } : null
                //    };
                //}else
                //{
                //    ResponseObj.Data = new WalletEntity();
                //}
            }
            catch (Exception e)
            {
                ResponseObj.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return Task.FromResult(ResponseObj);
        }

        public Task<JResponseEntity<WalletEntity>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<WalletEntity>> CreateAsync(Wallets Entity)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<WalletEntity>> CreateMultipleAsync(List<Wallets> Data)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<WalletEntity>> UpdateAsync(Wallets Entity)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<WalletEntity>> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<WalletEntity>> ReadMultipleByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}