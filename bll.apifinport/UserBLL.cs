using dal.apifinport.Context;
using dal.apifinport.DataAccess;
using entities.apifinport.Entities;
using entities.apifinport.Models;
using utils.apifinport;

namespace bll.apifinport
{
    public class UserBLL
    {
        private UserDAL _UserDAL;
        public UserBLL(FinPortContext _context)
        {
            this._UserDAL = new UserDAL(_context);
        }

        public JResponseEntity<UserEntity> SignUpUser(User Entity)
        {
            JResponseEntity<UserEntity> RObj = new JResponseEntity<UserEntity>();
            if (Entity != null
                && !string.IsNullOrWhiteSpace(Entity.Username)
                && !string.IsNullOrWhiteSpace(Entity.Email)
                && !string.IsNullOrWhiteSpace(Entity.Password))
            {
                JResponseEntity<UserEntity> UsrByName = new JResponseEntity<UserEntity>();
                UsrByName = this._UserDAL.GetByText(Entity.Username);
                if (UsrByName.Status)
                {
                    RObj.Message = "Username already exists.";
                }
                else
                {
                    RObj = this._UserDAL.Create(Entity);
                    RObj.Message = "User Created Successfully!";
                }
            }
            return RObj;
        }

        public JResponseEntity<UserEntity> SignInUser(UserEntity Entity)
        {
            JResponseEntity<UserEntity> RObj = new JResponseEntity<UserEntity>();
            if (Entity != null
                && !string.IsNullOrWhiteSpace(Entity.username)
                && !string.IsNullOrWhiteSpace(Entity.password))
            {
                JResponseEntity<UserEntity> UsrByName = new JResponseEntity<UserEntity>();
                UsrByName = this._UserDAL.GetByText(Entity.username);
                if (UsrByName.Status)
                {
                    bool isPwdValid = PasswordHash.IsPasswordValid(UsrByName.Data.password, Entity.password);
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