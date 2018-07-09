using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal.apifinport.Context;
using dal.apifinport.Interfaces;
using entities.apifinport.DtoModels;
using entities.apifinport.Models;
using Microsoft.EntityFrameworkCore;

namespace dal.apifinport.DataAccess
{
    public class UserDAL : IUserService
    {
        private readonly FinPortContext _context;
        public UserDAL(FinPortContext context)
        {
            _context = context;
        }

        public Task<JResponseEntity<UserEntity>> ReadOneAsync(int Id, string Name)
        {
            JResponseEntity<UserEntity> ResponseObj = new JResponseEntity<UserEntity>();
            Users usr = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(Name) && Id != 0)
                    usr = _context.Users.Where(x => x.Username == Name && x.Id == Id).FirstOrDefault();
                else if (string.IsNullOrWhiteSpace(Name) && Id != 0)
                    usr = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
                else if (!string.IsNullOrWhiteSpace(Name) && Id == 0)
                    usr = _context.Users.Where(x => x.Username == Name).FirstOrDefault();

                if (usr != null)
                    ResponseObj.Data = new UserEntity()
                    {
                        id = usr.Id,
                        username = usr.Username,
                        email = usr.Email,
                        first_name = usr.FirstName,
                        last_name = usr.LastName,
                        password = usr.Password
                    };

                ResponseObj.Status = true;
            }
            catch (Exception e)
            {
                ResponseObj.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return Task.FromResult(ResponseObj);
        }

        public Task<JResponseEntity<UserEntity>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<UserEntity>> CreateAsync(Users Entity)
        {
            JResponseEntity<UserEntity> ResponseObj = new JResponseEntity<UserEntity>();
            try
            {
                _context.Users.Add(Entity);
                _context.SaveChanges();
                ResponseObj.Status = true;
                ResponseObj.Data = new UserEntity()
                {
                    id = Entity.Id,
                    username = Entity.Username,
                    email = Entity.Email,
                    first_name = Entity.FirstName,
                    last_name = Entity.LastName
                }; ;
            }
            catch (Exception e)
            {
                ResponseObj.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return Task.FromResult(ResponseObj);
        }

        public Task<JResponseEntity<UserEntity>> CreateMultipleAsync(List<Users> Data)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<UserEntity>> UpdateAsync(Users Entity)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<UserEntity>> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<UserEntity>> ReadMultipleByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}