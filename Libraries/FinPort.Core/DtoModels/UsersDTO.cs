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
    public class UsersDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public WalletsDTO Wallet { get; set; }
        public IEnumerable<WalletDepositsDTO> WalletWalletDeposits { get; set; }
        public IEnumerable<UserOperationHistoriesDTO> UserOperationHistories { get; set; }
    }

    //public class UsersMapper : MapperBase<Users, UsersDTO>
    //{
    //    ////BCC/ BEGIN CUSTOM CODE SECTION 
    //    ////ECC/ END CUSTOM CODE SECTION 
    //    private UserOperationHistoriesMapper _userOperationHistoriesMapper = new UserOperationHistoriesMapper();
    //    public override Expression<Func<Users, UsersDTO>> SelectorExpression
    //    {
    //        get
    //        {
    //            return ((Expression<Func<Users, UsersDTO>>)(p => new UsersDTO()
    //            {
    //                ////BCC/ BEGIN CUSTOM CODE SECTION 
    //                ////ECC/ END CUSTOM CODE SECTION 
    //                UserId = p.UserId,
    //                Username = p.Username,
    //                Email = p.Email,
    //                FirstName = p.FirstName,
    //                LastName = p.LastName,
    //                Password = p.Password,
    //                WalletWalletId = p.Wallet != null ? p.Wallet.WalletId : default(int),
    //                WalletAmount = p.Wallet != null ? p.Wallet.Amount : default(decimal),
    //                WalletCurrencyCurrencyId = p.Wallet != null && p.Wallet.Currency != null ? p.Wallet.Currency.CurrencyId : default(int),
    //                Exchanges = p.Wallet.Currency.Exchanges.AsQueryable().Select(this._exchangesMapper.SelectorExpression),
    //                Wallets = p.Wallet.Currency.Wallets.AsQueryable().Select(this._walletsMapper.SelectorExpression),
    //                WalletUsersUserId = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.UserId : default(int),
    //                WalletUsersUsername = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.Username : default(string),
    //                WalletUsersEmail = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.Email : default(string),
    //                WalletUsersFirstName = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.FirstName : default(string),
    //                WalletUsersLastName = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.LastName : default(string),
    //                WalletUsersPassword = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.Password : default(string),
    //                WalletUsersWalletWalletId = p.Wallet != null && p.Wallet.Users != null && p.Wallet.Users.Wallet != null ? p.Wallet.Users.Wallet.WalletId : default(int),
    //                WalletUsersWalletAmount = p.Wallet != null && p.Wallet.Users != null && p.Wallet.Users.Wallet != null ? p.Wallet.Users.Wallet.Amount : default(decimal),
    //                WalletUsersWalletCurrencyId = p.Wallet != null && p.Wallet.Users != null && p.Wallet.Users.Wallet != null ? p.Wallet.Users.Wallet.CurrencyId : default(int),
    //                WalletUsersWalletCurrency = p.Wallet != null && p.Wallet.Users != null && p.Wallet.Users.Wallet != null ? p.Wallet.Users.Wallet.Currency : default(Currencies),
    //                WalletUsersWalletUsers = p.Wallet != null && p.Wallet.Users != null && p.Wallet.Users.Wallet != null ? p.Wallet.Users.Wallet.Users : default(Users),
    //                WalletDeposits = p.Wallet.Users.Wallet.WalletDeposits.AsQueryable().Select(this._walletDepositsMapper.SelectorExpression),
    //                WalletUsersWalletDeleted = p.Wallet != null && p.Wallet.Users != null && p.Wallet.Users.Wallet != null ? p.Wallet.Users.Wallet.Deleted : default(bool),
    //                WalletUsersWalletCreatedOn = p.Wallet != null && p.Wallet.Users != null && p.Wallet.Users.Wallet != null ? p.Wallet.Users.Wallet.CreatedOn : default(DateTime),
    //                WalletUsersWalletCreatedBy = p.Wallet != null && p.Wallet.Users != null && p.Wallet.Users.Wallet != null ? p.Wallet.Users.Wallet.CreatedBy : default(string),
    //                WalletUsersWalletModifiedOn = p.Wallet != null && p.Wallet.Users != null && p.Wallet.Users.Wallet != null ? p.Wallet.Users.Wallet.ModifiedOn : default(DateTime),
    //                WalletUsersWalletModifiedBy = p.Wallet != null && p.Wallet.Users != null && p.Wallet.Users.Wallet != null ? p.Wallet.Users.Wallet.ModifiedBy : default(string),
    //                UserExchangeTaxes = p.Wallet.Users.UserExchangeTaxes.AsQueryable().Select(this._userExchangeTaxesMapper.SelectorExpression),
    //                UserOperationHistories = p.Wallet.Users.UserOperationHistories.AsQueryable().Select(this._userOperationHistoriesMapper.SelectorExpression),
    //                WalletUsersDeleted = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.Deleted : default(bool),
    //                WalletUsersCreatedOn = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.CreatedOn : default(DateTime),
    //                WalletUsersCreatedBy = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.CreatedBy : default(string),
    //                WalletUsersModifiedOn = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.ModifiedOn : default(DateTime),
    //                WalletUsersModifiedBy = p.Wallet != null && p.Wallet.Users != null ? p.Wallet.Users.ModifiedBy : default(string),
    //                WalletDeposits = p.Wallet.WalletDeposits.AsQueryable().Select(this._walletDepositsMapper.SelectorExpression),
    //                UserOperationHistories = p.UserOperationHistories.AsQueryable().Select(this._userOperationHistoriesMapper.SelectorExpression)
    //            }));
    //        }
    //    }

    //    public override void MapToModel(UsersDTO dto, Users model)
    //    {
    //        ////BCC/ BEGIN CUSTOM CODE SECTION 
    //        ////ECC/ END CUSTOM CODE SECTION 
    //        model.UserId = dto.UserId;
    //        model.Username = dto.Username;
    //        model.Email = dto.Email;
    //        model.FirstName = dto.FirstName;
    //        model.LastName = dto.LastName;
    //        model.Password = dto.Password;
    //    }
    //}
}
