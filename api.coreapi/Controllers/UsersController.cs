using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using entities.apifinport.Entities;
using apicore.Controllers;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using utils.apifinport;
using entities.apifinport.Models;
using dal.apifinport.Context;
using bll.apifinport;

namespace api.coreapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User>
    {
        private readonly IOptions<JwtAuthentication> _jwtAuthentication;
        private UserBLL _UserBLL;
        public UsersController(FinPortContext context, IOptions<JwtAuthentication> jwtAuthentication) : base(context)
        {
            _jwtAuthentication = jwtAuthentication ?? throw new ArgumentNullException(nameof(jwtAuthentication));
            this._UserBLL = new UserBLL(context);
        }

        [Route("signup"), HttpPost]
        [EnableCors("CorsPolicy")]
        [AllowAnonymous]
        public ActionResult<JResponseEntity<UserEntity>> SignUp([FromBody]UserEntity entity)
        {
            JResponseEntity<UserEntity> JResponseEntity = new JResponseEntity<UserEntity>();
            if (ModelState.IsValid)
            {
                User _entity = new User()
                {
                    Email = entity.email,
                    Username = entity.username,
                    FirstName = entity.first_name,
                    LastName = entity.last_name,
                    Password = PasswordHash.Hash(entity.password)
                };
                JResponseEntity = this._UserBLL.SignUpUser(_entity);
                if (JResponseEntity.Status)
                {
                    JResponseEntity.AccessToken = LoginToken(new GenerateTokenModel() { Username = _entity.Username, Password = _entity.Password });
                }
            }
            return JResponseEntity;
        }

        [Route("signin"), HttpPost]
        [EnableCors("CorsPolicy")]
        [AllowAnonymous]
        public ActionResult<JResponseEntity<UserEntity>> SignIn([FromBody]UserEntity entity)
        {
            JResponseEntity<UserEntity> JResponseEntity = new JResponseEntity<UserEntity>();
            JResponseEntity = this._UserBLL.SignInUser(entity);
            if (JResponseEntity.Status)
                JResponseEntity.AccessToken = this.LoginToken(new GenerateTokenModel() { Username = JResponseEntity.Data.username, Password = JResponseEntity.Data.password });
            return JResponseEntity;
        }

        public string LoginToken(GenerateTokenModel model)
        {
            var token = new JwtSecurityToken(
                    issuer: _jwtAuthentication.Value.ValidIssuer,
                    audience: _jwtAuthentication.Value.ValidAudience,
                    claims: new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    },
                    expires: DateTime.UtcNow.AddDays(30),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: _jwtAuthentication.Value.SigningCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}