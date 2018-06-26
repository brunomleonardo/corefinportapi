using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using entities.apifinport.Entities;
using apicore.Controllers;
using entities.apifinport.Models;
using utils.apifinport;
using System;
using Microsoft.AspNetCore.Cors;
using entities.apifinport.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using dal.apifinport.Context;
using bll.apifinport;

namespace api.coreapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickersController : BaseController<Ticker>
    {
        private TickerBLL _TickerBLL;
        public TickersController(FinPortContext context) : base(context)
        {
            _TickerBLL = new TickerBLL(context);
        }

        [Route("loadtickers"), HttpGet]
        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        [EnableCors("CorsPolicy")]
        public ActionResult<JResponseEntity<TickerEntity>> LoadTickers()
        {
            return _TickerBLL.LoadTickers();
        }

        [Route("byabbv/{term}"), HttpGet]
        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        [EnableCors("CorsPolicy")]
        public ActionResult<JResponseEntity<TickerEntity>> GetByAbbv(string term)
        {
            return _TickerBLL.FindByText(term);
        }
    }
}