using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using entities.apifinport.DtoModels.Infrastructure;
using entities.apifinport.Models;

namespace entities.apifinport.DtoModels
{
    public class WalletDepositsDTO : BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
        public decimal WalletAmount { get; set; }
        public int WalletCurrencyId { get; set; }
        public int WalletUserId { get; set; }
        public string WalletCurrencySymbol { get; set; }
        public string WalletCurrencyDesignation { get; set; }
        public string WalletCurrencyName { get; set; }
        public IEnumerable<ExchangesDTO> WalletCurrencyExchanges { get; set; }
        public IEnumerable<WalletsDTO> WalletCurrencyWallets { get; set; }
        public int WalletCurrencyId { get; set; }
        public bool WalletCurrencyDeleted { get; set; }
        public DateTime WalletCurrencyCreatedOn { get; set; }
        public string WalletCurrencyCreatedBy { get; set; }
        public DateTime WalletCurrencyModifiedOn { get; set; }
        public string WalletCurrencyModifiedBy { get; set; }
        public string WalletUserUsername { get; set; }
        public string WalletUserEmail { get; set; }
        public string WalletUserFirstName { get; set; }
        public string WalletUserLastName { get; set; }
        public string WalletUserPassword { get; set; }
        public IEnumerable<UserExchangeTaxesDTO> WalletUserUserExchangeTaxes { get; set; }
        public IEnumerable<UserOperationHistoriesDTO> WalletUserUserOperationHistories { get; set; }
        public IEnumerable<WalletsDTO> WalletUserWallets { get; set; }
        public int WalletUserId { get; set; }
        public bool WalletUserDeleted { get; set; }
        public DateTime WalletUserCreatedOn { get; set; }
        public string WalletUserCreatedBy { get; set; }
        public DateTime WalletUserModifiedOn { get; set; }
        public string WalletUserModifiedBy { get; set; }
        public IEnumerable<WalletDepositsDTO> WalletWalletDeposits { get; set; }
        public int WalletId { get; set; }
        public bool WalletDeleted { get; set; }
        public DateTime WalletCreatedOn { get; set; }
        public string WalletCreatedBy { get; set; }
        public DateTime WalletModifiedOn { get; set; }
        public string WalletModifiedBy { get; set; }
    }

    public class WalletDepositsMapper : MapperBase<WalletDeposits, WalletDepositsDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private BaseEntityMapper _baseEntityMapper = new BaseEntityMapper();
        public override Expression<Func<WalletDeposits, WalletDepositsDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<WalletDeposits, WalletDepositsDTO>>)(p => new WalletDepositsDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Amount = p.Amount,
                    WalletId = p.WalletId,
                    WalletAmount = p.Wallet != null ? p.Wallet.Amount : default(decimal),
                    WalletCurrencyId = p.Wallet != null ? p.Wallet.CurrencyId : default(int),
                    WalletUserId = p.Wallet != null ? p.Wallet.UserId : default(int),
                    WalletCurrencySymbol = p.Wallet != null && p.Wallet.Currency != null ? p.Wallet.Currency.Symbol : default(string),
                    WalletCurrencyDesignation = p.Wallet != null && p.Wallet.Currency != null ? p.Wallet.Currency.Designation : default(string),
                    WalletCurrencyName = p.Wallet != null && p.Wallet.Currency != null ? p.Wallet.Currency.Name : default(string),
                    Exchanges = p.Wallet.Currency.Exchanges.AsQueryable().Select(this._exchangesMapper.SelectorExpression),
                    Wallets = p.Wallet.Currency.Wallets.AsQueryable().Select(this._walletsMapper.SelectorExpression),
                    WalletCurrencyId = p.Wallet != null && p.Wallet.Currency != null ? p.Wallet.Currency.Id : default(int),
                    WalletCurrencyDeleted = p.Wallet != null && p.Wallet.Currency != null ? p.Wallet.Currency.Deleted : default(bool),
                    WalletCurrencyCreatedOn = p.Wallet != null && p.Wallet.Currency != null ? p.Wallet.Currency.CreatedOn : default(DateTime),
                    WalletCurrencyCreatedBy = p.Wallet != null && p.Wallet.Currency != null ? p.Wallet.Currency.CreatedBy : default(string),
                    WalletCurrencyModifiedOn = p.Wallet != null && p.Wallet.Currency != null ? p.Wallet.Currency.ModifiedOn : default(DateTime),
                    WalletCurrencyModifiedBy = p.Wallet != null && p.Wallet.Currency != null ? p.Wallet.Currency.ModifiedBy : default(string),
                    WalletUserUsername = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.Username : default(string),
                    WalletUserEmail = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.Email : default(string),
                    WalletUserFirstName = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.FirstName : default(string),
                    WalletUserLastName = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.LastName : default(string),
                    WalletUserPassword = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.Password : default(string),
                    UserExchangeTaxes = p.Wallet.User.UserExchangeTaxes.AsQueryable().Select(this._userExchangeTaxesMapper.SelectorExpression),
                    UserOperationHistories = p.Wallet.User.UserOperationHistories.AsQueryable().Select(this._userOperationHistoriesMapper.SelectorExpression),
                    Wallets = p.Wallet.User.Wallets.AsQueryable().Select(this._walletsMapper.SelectorExpression),
                    WalletUserId = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.Id : default(int),
                    WalletUserDeleted = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.Deleted : default(bool),
                    WalletUserCreatedOn = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.CreatedOn : default(DateTime),
                    WalletUserCreatedBy = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.CreatedBy : default(string),
                    WalletUserModifiedOn = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.ModifiedOn : default(DateTime),
                    WalletUserModifiedBy = p.Wallet != null && p.Wallet.User != null ? p.Wallet.User.ModifiedBy : default(string),
                    WalletDeposits = p.Wallet.WalletDeposits.AsQueryable().Select(this._walletDepositsMapper.SelectorExpression),
                    WalletId = p.Wallet != null ? p.Wallet.Id : default(int),
                    WalletDeleted = p.Wallet != null ? p.Wallet.Deleted : default(bool),
                    WalletCreatedOn = p.Wallet != null ? p.Wallet.CreatedOn : default(DateTime),
                    WalletCreatedBy = p.Wallet != null ? p.Wallet.CreatedBy : default(string),
                    WalletModifiedOn = p.Wallet != null ? p.Wallet.ModifiedOn : default(DateTime),
                    WalletModifiedBy = p.Wallet != null ? p.Wallet.ModifiedBy : default(string)
                })).MergeWith(this._baseEntityMapper.SelectorExpression);
            }
        }

        public override void MapToModel(WalletDepositsDTO dto, WalletDeposits model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Amount = dto.Amount;
            model.WalletId = dto.WalletId;
            this._baseEntityMapper.MapToModel(dto, model);
        }
    }
}
