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
    public class WalletDepositsDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
        public decimal WalletAmount { get; set; }
    }

    public class WalletDepositsMapper : MapperBase<WalletDeposits, WalletDepositsDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 

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
                    WalletAmount = p.Wallet != null ? p.Wallet.Amount : default(decimal)
                }));
            }
        }

        public override void MapToModel(WalletDepositsDTO dto, WalletDeposits model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Amount = dto.Amount;
            model.WalletId = dto.WalletId;
        }
    }
}
