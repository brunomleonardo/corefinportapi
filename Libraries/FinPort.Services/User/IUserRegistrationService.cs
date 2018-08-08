using FinPort.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinPort.Services.User
{
    public partial interface IUserRegistrationService
    {
        bool UserExists(string username);
        Users RegisterUser(Users entity);
        bool IsPasswordValid(Users user, string input);
    }
}
