using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using entities.apifinport.DtoModels.Infrastructure;
using FinPort.Entities;
using System.ComponentModel.DataAnnotations;

namespace entities.apifinport.DtoModels
{
    public class CurrenciesDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public string Symbol { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public int WalletsWalletId { get; set; }
        public decimal WalletsAmount { get; set; }
        public int WalletsUsersUserId { get; set; }
        public IEnumerable<ExchangesDTO> Exchanges { get; set; }
    }

    public class CurrenciesMapper : MapperBase<Currencies, CurrenciesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private ExchangesMapper _exchangesMapper = new ExchangesMapper();
        public override Expression<Func<Currencies, CurrenciesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Currencies, CurrenciesDTO>>)(p => new CurrenciesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Symbol = p.Symbol,
                    Designation = p.Designation,
                    Name = p.Name,
                    WalletsWalletId = p.Wallets != null ? p.Wallets.WalletId : default(int),
                    WalletsAmount = p.Wallets != null ? p.Wallets.Amount : default(decimal),
                    WalletsUsersUserId = p.Wallets != null && p.Wallets.Users != null ? p.Wallets.Users.UserId : default(int),
                    Exchanges = p.Exchanges.AsQueryable().Select(this._exchangesMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(CurrenciesDTO dto, Currencies model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Symbol = dto.Symbol;
            model.Designation = dto.Designation;
            model.Name = dto.Name;
        }
    }
}
