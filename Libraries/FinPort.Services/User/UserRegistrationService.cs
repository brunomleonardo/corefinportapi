using FinPort.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinPort.Services.User
{
    public partial class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserService _userService;
        private readonly UserExtensions userExtensions = new UserExtensions();
        #region Ctor

        public UserRegistrationService(IUserService userService)
        {
            this._userService = userService;
        }

        #endregion

        public virtual bool UserExists(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            return this._userService.GetUserByUserName(username) != null;
        }

        public virtual Users RegisterUser(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return this._userService.InsertUser(user);
        }

        public virtual bool IsPasswordValid(Users user, string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return userExtensions.IsPasswordValid(user.Password, input);
        }

    }
}
