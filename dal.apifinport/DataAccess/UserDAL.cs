using System;
using System.Linq;
using dal.apifinport.Context;
using dal.apifinport.Interfaces;
using entities.apifinport.Entities;
using entities.apifinport.Models;
using Microsoft.EntityFrameworkCore;

namespace dal.apifinport.DataAccess
{
    public class UserDAL : ICrud<JResponseEntity<UserEntity>, User>
    {
        private readonly FinPortContext _context;
        public UserDAL(FinPortContext context)
        {
            _context = context;
        }
        public UserDAL() { }

        public JResponseEntity<UserEntity> Create(User Entity)
        {
            JResponseEntity<UserEntity> ResponseObj = new JResponseEntity<UserEntity>();
            try
            {
                _context.Users.Add(Entity);
                _context.SaveChanges();
                ResponseObj.Status = true;
                ResponseObj.Data =  new UserEntity()
                {
                    id = Entity.Id,
                    username = Entity.Username,
                    email = Entity.Email,
                    first_name = Entity.FirstName,
                    last_name = Entity.LastName
                };;
            }
            catch (Exception e)
            {
                ResponseObj.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return ResponseObj;
        }

        public JResponseEntity<UserEntity> Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<UserEntity> Recover(int Id)
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<UserEntity> Update(User Entity)
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<UserEntity> ReadAll()
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<UserEntity> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public JResponseEntity<UserEntity> GetByText(string input)
        {
            JResponseEntity<UserEntity> ResponseObj = new JResponseEntity<UserEntity>();
            try
            {
                User usr = _context.Users.Where(x => x.Username == input).FirstOrDefault();
                ResponseObj.Data = new UserEntity()
                {
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
            return ResponseObj;
        }
    }
}