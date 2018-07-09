using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using entities.apifinport.DtoModels.Infrastructure;
using entities.apifinport.Models;

namespace entities.apifinport.DtoModels
{
    public class UsersDTO : BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public IEnumerable<UserExchangeTaxesDTO> UserExchangeTaxes { get; set; }
        public IEnumerable<UserOperationHistoriesDTO> UserOperationHistories { get; set; }
        public IEnumerable<WalletsDTO> Wallets { get; set; }
    }

    public class UsersMapper : MapperBase<Users, UsersDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private UserExchangeTaxesMapper _userExchangeTaxesMapper = new UserExchangeTaxesMapper();
        private UserOperationHistoriesMapper _userOperationHistoriesMapper = new UserOperationHistoriesMapper();
        private WalletsMapper _walletsMapper = new WalletsMapper();
        private BaseEntityMapper _baseEntityMapper = new BaseEntityMapper();
        public override Expression<Func<Users, UsersDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Users, UsersDTO>>)(p => new UsersDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Username = p.Username,
                    Email = p.Email,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Password = p.Password,
                    UserExchangeTaxes = p.UserExchangeTaxes.AsQueryable().Select(this._userExchangeTaxesMapper.SelectorExpression),
                    UserOperationHistories = p.UserOperationHistories.AsQueryable().Select(this._userOperationHistoriesMapper.SelectorExpression),
                    Wallets = p.Wallets.AsQueryable().Select(this._walletsMapper.SelectorExpression)
                })).MergeWith(this._baseEntityMapper.SelectorExpression);
            }
        }

        public override void MapToModel(UsersDTO dto, Users model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Username = dto.Username;
            model.Email = dto.Email;
            model.FirstName = dto.FirstName;
            model.LastName = dto.LastName;
            model.Password = dto.Password;
            this._baseEntityMapper.MapToModel(dto, model);
        }
    }
}
