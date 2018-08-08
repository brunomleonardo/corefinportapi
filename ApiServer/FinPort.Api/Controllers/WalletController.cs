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
    public class WalletController : ControllerBase
    {
        //private readonly WalletBLL _WalletBLL;
        //private readonly IWalletService _WalletService;

        //public WalletController(IWalletService WalletService)
        //{
        //    _WalletService = WalletService ?? throw new ArgumentException(nameof(WalletService));
        //    _WalletBLL = new WalletBLL(_WalletService);
        //}

        //[HttpGet]
        //[Authorize(JwtBearerDefaults.AuthenticationScheme)]
        //[EnableCors("CorsPolicy")]
        //[ProducesResponseType(typeof(JResponseEntity<WalletEntity>), 200)]
        //public async Task<IActionResult> GetWallet(string userId)
        //{
        //    JResponseEntity<WalletEntity> RObj = await _WalletBLL.GetWalletData(Int32.Parse(userId));
        //    return Ok(RObj);
        //}
    }
}