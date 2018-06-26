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
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace api.coreapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationsController : BaseController<User>
    {
        private UserOperationsBLL _UserOperationBLL;
        public UserOperationsController(FinPortContext context) : base(context)
        {
            _UserOperationBLL = new UserOperationsBLL(context);
        }

        [Route("addoperation"), HttpPost]
        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        [EnableCors("CorsPolicy")]
        public ActionResult<JResponseEntity<UserOperationHistoryEntity>> AddOperation([FromBody]UserOperationHistoryEntity UsrOEntity)
        {
            UserOperationHistory UserOpEntity = (UserOperationHistory)UsrOEntity;
            UserOpEntity.UserId = UsrOEntity.userId;
            UserOpEntity.TickerId = UsrOEntity.tickerId;
            return _UserOperationBLL.AddOperation(UserOpEntity);
        }

    }
}