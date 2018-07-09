using entities.apifinport.DtoModels;
using entities.apifinport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.apifinport.Interfaces
{
    public interface IWalletService : IBaseService<JResponseEntity<WalletEntity>, Wallets>
    {
    }
}
