using System;
using System.Collections.Generic;
using System.Linq;
using dal.apifinport.Context;
using dal.apifinport.Interfaces;
using entities.apifinport.Entities;
using entities.apifinport.Models;
using Microsoft.EntityFrameworkCore;

namespace dal.apifinport.DataAccess
{
    public class WalletDAL : ICrud<JResponseEntity<WalletEntity>, Wallet>
    {
        private readonly FinPortContext _context;
        public WalletDAL(FinPortContext context)
        {
            _context = context;
        }

        public JResponseEntity<WalletEntity> GetByUserId(int UserId)
        {
            JResponseEntity<WalletEntity> ResponseObj = new JResponseEntity<WalletEntity>();
            try
            {
                Wallet Wallet = _context.Wallets.Where(x => x.UserId == UserId).FirstOrDefault();
                if (Wallet != null)
                {
                    ResponseObj.Status = true;
                    ResponseObj.Data = new WalletEntity()
                    {
                        id = Wallet.Id,
                        amount = Wallet.Amount,
                        deposits = Wallet.WalletDeposits.Select(y => new WalletDepositsEntity()
                        {
                            amount = y.Amount
                        }).ToList(),
                        currency = new CurrencyEntity()
                        {
                            designation = Wallet.Currency.Designation,
                            symbol = Wallet.Currency.Symbol
                        }
                    };
                }
            }
            catch (Exception e)
            {
                ResponseObj.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return ResponseObj;
        }


        public JResponseEntity<WalletEntity> Create(Wallet Entity)
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<WalletEntity> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<WalletEntity> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<WalletEntity> GetByText(string input)
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<WalletEntity> ReadAll()
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<WalletEntity> Recover(int Id)
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<WalletEntity> Update(Wallet Entity)
        {
            throw new NotImplementedException();
        }
    }
}