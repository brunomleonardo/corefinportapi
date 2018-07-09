using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using entities.apifinport.DtoModels;
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
using dal.apifinport.Interfaces;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using System.IO;

namespace api.coreapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IOptions<JwtAuthentication> _jwtAuthentication;
        private readonly UserBLL _UserBLL;
        private readonly IUserService _UserService;

        public UsersController(FinPortContext context, IOptions<JwtAuthentication> jwtAuthentication, IUserService UserService)
        {
            _jwtAuthentication = jwtAuthentication ?? throw new ArgumentNullException(nameof(jwtAuthentication));
            _UserService = UserService ?? throw new ArgumentException(nameof(UserService));
            _UserBLL = new UserBLL(_UserService);
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(JResponseEntity<UserEntity>), 200)]
        public async Task<IActionResult> SignUp([FromBody]UserEntity entity)
        {
            JResponseEntity<UserEntity> JResponseEntity = await _UserBLL.SignUpUserAsync(entity);
            if (JResponseEntity.Status)
            {
                JResponseEntity.AccessToken = LoginToken(new GenerateTokenModel() { Username = JResponseEntity.Data.username, Password = JResponseEntity.Data.password });
            }
            return Ok(JResponseEntity);
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(JResponseEntity<UserEntity>), 200)]
        public async Task<IActionResult> SignIn([FromBody]UserEntity entity)
        {
            JResponseEntity<UserEntity> JResponseEntity = await _UserBLL.SignInUserAsync(entity.username, entity.password);
            if (JResponseEntity.Status)
                JResponseEntity.AccessToken = this.LoginToken(new GenerateTokenModel() { Username = JResponseEntity.Data.username, Password = JResponseEntity.Data.password });
            return Ok(JResponseEntity);
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