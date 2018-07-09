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
    public class WalletsDTO : BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public int UserId { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyDesignation { get; set; }
        public string CurrencyName { get; set; }
        public IEnumerable<ExchangesDTO> CurrencyExchanges { get; set; }
        public IEnumerable<WalletsDTO> CurrencyWallets { get; set; }
        public int CurrencyId { get; set; }
        public bool CurrencyDeleted { get; set; }
        public DateTime CurrencyCreatedOn { get; set; }
        public string CurrencyCreatedBy { get; set; }
        public DateTime CurrencyModifiedOn { get; set; }
        public string CurrencyModifiedBy { get; set; }
        public string UserUsername { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPassword { get; set; }
        public IEnumerable<UserExchangeTaxesDTO> UserUserExchangeTaxes { get; set; }
        public IEnumerable<UserOperationHistoriesDTO> UserUserOperationHistories { get; set; }
        public IEnumerable<WalletsDTO> UserWallets { get; set; }
        public int UserId { get; set; }
        public bool UserDeleted { get; set; }
        public DateTime UserCreatedOn { get; set; }
        public string UserCreatedBy { get; set; }
        public DateTime UserModifiedOn { get; set; }
        public string UserModifiedBy { get; set; }
        public IEnumerable<WalletDepositsDTO> WalletDeposits { get; set; }
    }

    public class WalletsMapper : MapperBase<Wallets, WalletsDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private WalletDepositsMapper _walletDepositsMapper = new WalletDepositsMapper();
        private BaseEntityMapper _baseEntityMapper = new BaseEntityMapper();
        public override Expression<Func<Wallets, WalletsDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Wallets, WalletsDTO>>)(p => new WalletsDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Amount = p.Amount,
                    CurrencyId = p.CurrencyId,
                    UserId = p.UserId,
                    CurrencySymbol = p.Currency != null ? p.Currency.Symbol : default(string),
                    CurrencyDesignation = p.Currency != null ? p.Currency.Designation : default(string),
                    CurrencyName = p.Currency != null ? p.Currency.Name : default(string),
                    Exchanges = p.Currency.Exchanges.AsQueryable().Select(this._exchangesMapper.SelectorExpression),
                    Wallets = p.Currency.Wallets.AsQueryable().Select(this._walletsMapper.SelectorExpression),
                    CurrencyId = p.Currency != null ? p.Currency.Id : default(int),
                    CurrencyDeleted = p.Currency != null ? p.Currency.Deleted : default(bool),
                    CurrencyCreatedOn = p.Currency != null ? p.Currency.CreatedOn : default(DateTime),
                    CurrencyCreatedBy = p.Currency != null ? p.Currency.CreatedBy : default(string),
                    CurrencyModifiedOn = p.Currency != null ? p.Currency.ModifiedOn : default(DateTime),
                    CurrencyModifiedBy = p.Currency != null ? p.Currency.ModifiedBy : default(string),
                    UserUsername = p.User != null ? p.User.Username : default(string),
                    UserEmail = p.User != null ? p.User.Email : default(string),
                    UserFirstName = p.User != null ? p.User.FirstName : default(string),
                    UserLastName = p.User != null ? p.User.LastName : default(string),
                    UserPassword = p.User != null ? p.User.Password : default(string),
                    UserExchangeTaxes = p.User.UserExchangeTaxes.AsQueryable().Select(this._userExchangeTaxesMapper.SelectorExpression),
                    UserOperationHistories = p.User.UserOperationHistories.AsQueryable().Select(this._userOperationHistoriesMapper.SelectorExpression),
                    Wallets = p.User.Wallets.AsQueryable().Select(this._walletsMapper.SelectorExpression),
                    UserId = p.User != null ? p.User.Id : default(int),
                    UserDeleted = p.User != null ? p.User.Deleted : default(bool),
                    UserCreatedOn = p.User != null ? p.User.CreatedOn : default(DateTime),
                    UserCreatedBy = p.User != null ? p.User.CreatedBy : default(string),
                    UserModifiedOn = p.User != null ? p.User.ModifiedOn : default(DateTime),
                    UserModifiedBy = p.User != null ? p.User.ModifiedBy : default(string),
                    WalletDeposits = p.WalletDeposits.AsQueryable().Select(this._walletDepositsMapper.SelectorExpression)
                })).MergeWith(this._baseEntityMapper.SelectorExpression);
            }
        }

        public override void MapToModel(WalletsDTO dto, Wallets model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Amount = dto.Amount;
            model.CurrencyId = dto.CurrencyId;
            model.UserId = dto.UserId;
            this._baseEntityMapper.MapToModel(dto, model);
        }
    }
}
