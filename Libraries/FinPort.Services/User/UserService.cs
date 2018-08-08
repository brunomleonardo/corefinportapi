using FinPort.Core.Models;
using FinPort.Data;
using FinPort.Services.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinPort.Services.User
{
    public partial class UserService : IUserService
    {
        private readonly IRepository<Users> _userRepository;
        private readonly IWalletService _walletService;
        private readonly IDbContext _dbContext;

        #region Ctor

        public UserService(IRepository<Users> _repository, IDbContext _context, IWalletService _walletServ)
        {
            this._userRepository = _repository;
            this._dbContext = _context;
            this._walletService = _walletServ;
        }

        #endregion

        public virtual Users InsertUser(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.UserId = GenerateId();

            if (user.Wallet != null) {
                user.Wallet.WalletId = user.UserId;
            }

            return _userRepository.Insert(user);
        }

        public virtual Users GetUserById(int Id)
        {
            if (Id == 0)
                return null;

            return this._userRepository.GetById(Id);
        }

        public virtual Users GetUserByUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            var query = _userRepository.Table;
            return query.Where(x => x.Username == username).FirstOrDefault();
        }

        public int GenerateId()
        {
            Users LastOne = _userRepository.Table.LastOrDefault();
            return LastOne == null ? 1 : LastOne.UserId + 1;
        }
    }
}
