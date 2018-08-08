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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;

namespace api.coreapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserOperationsController : ControllerBase
    {
        //private UserOperationsBLL _UserOperationBLL;
        //private readonly IUserOperationsService _UserOperationsService;

        //public UserOperationsController(IUserOperationsService UserOperationsService)
        //{
        //    _UserOperationsService = UserOperationsService ?? throw new ArgumentException(nameof(UserOperationsService));
        //    _UserOperationBLL = new UserOperationsBLL(_UserOperationsService);
        //}

        //[HttpPost]
        //[Authorize(JwtBearerDefaults.AuthenticationScheme)]
        //[EnableCors("CorsPolicy")]
        //[ProducesResponseType(typeof(JResponseEntity<UserOperationHistoryEntity>), 200)]
        //public async Task<IActionResult> AddOperation([FromBody]UserOperationHistoryEntity UsrOEntity)
        //{
        //    JResponseEntity<UserOperationHistoryEntity> RObj = await _UserOperationBLL.AddOperation(UsrOEntity);
        //    return Ok(RObj);
        //}

        //[HttpGet]
        ////[Authorize()]
        //[AllowAnonymous]
        //[EnableCors("CorsPolicy")]
        //[ProducesResponseType(typeof(JResponseEntity<UserOperationHistoryEntity>), 200)]
        //public async Task<IActionResult> GetOperations(string userId)
        //{
        //    JResponseEntity<IEnumerable<UserOperationHistoryEntity>> RObj = await _UserOperationBLL.GetUserOperations(Int32.Parse(userId));
        //    return Ok(RObj);
        //}

    }
}