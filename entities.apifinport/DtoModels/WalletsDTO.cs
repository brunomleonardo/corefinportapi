using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using entities.apifinport.DtoModels.Infrastructure;
using FinPort.Entities;

namespace entities.apifinport.DtoModels
{
    public class WalletsDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public decimal Amount { get; set; }
        public string WalletSymbol { get; set; }
        public string WalletDesignation { get; set; }
        public string WalletName { get; set; }
        public int UsersUserId { get; set; }
        public string UsersUsername { get; set; }
        public string UsersFirstName { get; set; }
        public string UsersLastName { get; set; }
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
                    WalletSymbol = p.Wallet != null ? p.Wallet.Symbol : default(string),
                    WalletDesignation = p.Wallet != null ? p.Wallet.Designation : default(string),
                    WalletName = p.Wallet != null ? p.Wallet.Name : default(string),
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
