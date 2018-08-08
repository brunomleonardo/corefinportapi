
using FinPort.Core.Models;

namespace FinPort.Services.User
{
    public partial interface IUserService
    {
        Users InsertUser(Users user);
        Users GetUserById(int Id);
        Users GetUserByUserName(string username);
        int GenerateId();
    }
}
