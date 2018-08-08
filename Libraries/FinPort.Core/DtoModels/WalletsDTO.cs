using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FinPort.Core.DtoModels.Infrastructure;
using FinPort.Core.Models;

namespace FinPort.Core.DtoModels
{
    public class WalletsDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public decimal Amount { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyDesignation { get; set; }
        public string CurrencyName { get; set; }
        public int UsersUserId { get; set; }
        public string UsersUsername { get; set; }
        public string UsersFirstName { get; set; }
        public string UsersLastName { get; set; }
        public CurrenciesDTO Currency { get; set; }
        public IEnumerable<WalletDepositsDTO> WalletDeposits { get; set; }
    }

    public class WalletsMapper : MapperBase<Wallets, WalletsDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private WalletDepositsMapper _walletDepositsMapper = new WalletDepositsMapper();
        public override Expression<Func<Wallets, WalletsDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Wallets, WalletsDTO>>)(p => new WalletsDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Amount = p.Amount,
                    CurrencySymbol = p.Currency != null ? p.Currency.Symbol : default(string),
                    CurrencyDesignation = p.Currency != null ? p.Currency.Designation : default(string),
                    CurrencyName = p.Currency != null ? p.Currency.Name : default(string),
                    UsersUserId = p.Users != null ? p.Users.UserId : default(int),
                    UsersUsername = p.Users != null ? p.Users.Username : default(string),
                    UsersFirstName = p.Users != null ? p.Users.FirstName : default(string),
                    UsersLastName = p.Users != null ? p.Users.LastName : default(string),
                    WalletDeposits = p.WalletDeposits.AsQueryable().Select(this._walletDepositsMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(WalletsDTO dto, Wallets model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Amount = dto.Amount;
        }
    }
}
