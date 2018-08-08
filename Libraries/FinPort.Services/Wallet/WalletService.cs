using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinPort.Core.Models;
using FinPort.Data;

namespace FinPort.Services.Wallet
{
    public partial class WalletService : IWalletService
    {
        private readonly IRepository<Wallets> _wallerRepository;
        private readonly IDbContext _dbContext;

        public WalletService(IRepository<Wallets> _walletRep, IDbContext _context)
        {
            this._wallerRepository = _walletRep;
            this._dbContext = _context;
        }

        public int GenerateId()
        {
            Wallets LastOne = _wallerRepository.Table.LastOrDefault();
            return LastOne == null ? 1 : LastOne.WalletId + 1;
        }

        public Wallets InsertWallet(Wallets Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException(nameof(Entity));

            return this._wallerRepository.Insert(Entity);
        }
    }
}
