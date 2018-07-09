using dal.apifinport.Context;
using dal.apifinport.DataAccess;
using dal.apifinport.Interfaces;
using entities.apifinport.DtoModels;
using entities.apifinport.Models;
using System;
using System.Threading.Tasks;
using utils.apifinport;

namespace bll.apifinport
{
    public class WalletBLL
    {
        private readonly IWalletService _WalletService;

        public WalletBLL(IWalletService WalletService)
        {
            _WalletService = WalletService ?? throw new ArgumentException(nameof(WalletService));
        }

        public async Task<JResponseEntity<WalletEntity>> GetWalletData(int userId)
        {
            if (userId != 0)
            {
                return await _WalletService.ReadOneAsync(userId, null);
            }
            return new JResponseEntity<WalletEntity>();
        }
    }
}