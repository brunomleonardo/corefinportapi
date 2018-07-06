using dal.apifinport.Context;
using dal.apifinport.DataAccess;
using dal.apifinport.Interfaces;
using entities.apifinport.Entities;
using entities.apifinport.Models;
using Newtonsoft.Json.Schema;
using System;
using System.IO;
using System.Threading.Tasks;
using utils.apifinport;

namespace bll.apifinport
{
    public class UserBLL
    {
        private readonly IUserService _UserService;
        public UserBLL(IUserService UserService)
        {
            _UserService = UserService ?? throw new ArgumentException(nameof(UserService));
        }

        public async Task<JResponseEntity<UserEntity>> SignUpUserAsync(UserEntity Entity)
        {
            JResponseEntity<UserEntity> RObj = new JResponseEntity<UserEntity>();
            if (Entity != null
                && !string.IsNullOrWhiteSpace(Entity.username)
                && !string.IsNullOrWhiteSpace(Entity.email)
                && !string.IsNullOrWhiteSpace(Entity.password))
            {
                JResponseEntity<UserEntity> UsrByName = null;
                UsrByName = await _UserService.ReadOneAsync(0, Entity.username);
                if (UsrByName.Status && UsrByName.Data != null)
                {
                    RObj.Message = "Username already exists.";
                }
                else
                {
                    Users _entity = new Users()
                    {
                        Email = Entity.email,
                        Username = Entity.username,
                        FirstName = Entity.first_name,
                        LastName = Entity.last_name,
                        Password = PasswordHash.Hash(Entity.password)
                    };

                    RObj = await _UserService.CreateAsync(_entity);
                    RObj.Message = "User Created Successfully!";
                }
            }
            return RObj;
        }

        public async Task<JResponseEntity<UserEntity>> SignInUserAsync(string username, string password)
        {
            JResponseEntity<UserEntity> RObj = new JResponseEntity<UserEntity>();
            if (!string.IsNullOrWhiteSpace(username)
                && !string.IsNullOrWhiteSpace(password))
            {
                JResponseEntity<UserEntity> UsrByName = null;
                UsrByName = await _UserService.ReadOneAsync(0, username);
                if (UsrByName.Status)
                {
                    bool isPwdValid = PasswordHash.IsPasswordValid(UsrByName.Data.password, password);
                    if (isPwdValid)
                    {
                        RObj.Message = "Login success.";
                        RObj.Status = true;
                        RObj.Data = UsrByName.Data;
                    }
                    else
                    {
                        RObj.Message = "Wrong password.";
                    }
                }
                else
                {
                    RObj.Message = "User doesn\'t exists.";
                }
            }
            else
            {
                RObj.Message = "Invalid form.";
            }
            return RObj;
        }

    }
}