using dal.apifinport.Context;
using dal.apifinport.DataAccess;
using entities.apifinport.Entities;
using entities.apifinport.Models;
using utils.apifinport;

namespace bll.apifinport
{
    public class WalletBLL
    {
        private WalletDAL _WalletDAL;
        public WalletBLL(FinPortContext _context)
        {
            this._WalletDAL = new WalletDAL(_context);
        }

        public JResponseEntity<WalletEntity> GetWalletData(int userId)
        {
            if (userId != 0)
            {
                return _WalletDAL.GetByUserId(userId);
            }
            return new JResponseEntity<WalletEntity>();
        }
    }
}