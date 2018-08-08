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
    public class WalletDepositsDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
        public DateTime WalletCreatedOn { get; set; }
        public string WalletCreatedBy { get; set; }
        public DateTime WalletModifiedOn { get; set; }
        public string WalletModifiedBy { get; set; }
        public bool WalletDeleted { get; set; }
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
                    WalletCreatedOn = p.Wallet != null ? p.Wallet.CreatedOn : default(DateTime),
                    WalletCreatedBy = p.Wallet != null ? p.Wallet.CreatedBy : default(string),
                    WalletModifiedOn = p.Wallet != null ? p.Wallet.ModifiedOn : default(DateTime),
                    WalletModifiedBy = p.Wallet != null ? p.Wallet.ModifiedBy : default(string),
                    WalletDeleted = p.Wallet != null ? p.Wallet.Deleted : default(bool),
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
