using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using System.IO;
using FinPort.Core.Models;
using FinPort.Core.DtoModels;
using FinPort.Services.User;
using FinPort.Data;

namespace FinPort.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public partial class UsersController : ControllerBase
    {
        private readonly IOptions<JwtAuthentication> _jwtAuthentication;
        private readonly IUserService _userService;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly UserExtensions userExtensions = new UserExtensions();

        public UsersController(
            FinPortContext context,
            IOptions<JwtAuthentication> jwtAuthentication,
            IUserService userService,
            IUserRegistrationService userRegistrationService)
        {
            _jwtAuthentication = jwtAuthentication ?? throw new ArgumentNullException(nameof(jwtAuthentication));
            _userService = userService ?? throw new ArgumentException(nameof(userService));
            _userRegistrationService = userRegistrationService ?? throw new ArgumentNullException(nameof(userRegistrationService));
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(JResponseEntity<UsersDTO>), 200)]
        public virtual IActionResult SignUp([FromBody]UsersDTO entity)
        {
            JResponseEntity<UsersDTO> JResponseEntity = new JResponseEntity<UsersDTO>();
            if (entity != null
                && !string.IsNullOrWhiteSpace(entity.Username)
                && !string.IsNullOrWhiteSpace(entity.Email)
                && !string.IsNullOrWhiteSpace(entity.Password))
            {
                bool userExists = _userRegistrationService.UserExists(entity.Username);
                if (!userExists)
                {
                    Users mappedEntity = userExtensions.MapToEntity(entity);
                    mappedEntity.Password = userExtensions.Hash(entity.Password);
                    Users userEntity = _userRegistrationService.RegisterUser(mappedEntity);
                    if (userEntity != null)
                    {
                        JResponseEntity.AccessToken = userExtensions.LoginToken(new GenerateTokenModel() { Username = userEntity.Username, Password = userEntity.Password }, _jwtAuthentication);
                        JResponseEntity.Status = true;
                        JResponseEntity.Data = userExtensions.MapToModel(userEntity);
                        JResponseEntity.Message = "Success.";
                        return Ok(JResponseEntity);
                    }
                }
                JResponseEntity.Message = "User already exists or invalid data.";
            }
            return Ok(JResponseEntity);
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(JResponseEntity<UsersDTO>), 200)]
        public async Task<IActionResult> SignIn([FromBody]UsersDTO entity)
        {
            JResponseEntity<UsersDTO> JResponseEntity = new JResponseEntity<UsersDTO>();
            Users userEntity = _userService.GetUserByUserName(entity.Username);
            if (userEntity != null)
            {
                bool isValid = _userRegistrationService.IsPasswordValid(userEntity, entity.Password);
                if (isValid)
                {
                    JResponseEntity.AccessToken = userExtensions.LoginToken(new GenerateTokenModel() { Username = userEntity.Username, Password = userEntity.Password }, _jwtAuthentication);
                    JResponseEntity.Status = true;
                    JResponseEntity.Message = "Success.";
                    return Ok(JResponseEntity);
                }
                JResponseEntity.Message = "User doesn't exists or invalid login data.";
            }
            return Ok(JResponseEntity);
        }
    }
}