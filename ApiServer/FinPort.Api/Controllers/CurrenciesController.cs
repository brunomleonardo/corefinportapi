using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinPort.Core.DtoModels;
using FinPort.Core.Models;
using FinPort.Services.Currency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FinPort.Api.Controllers
{
    public class CurrenciesController : BaseController
    {
        private readonly ICurrencyService _currencyService;
        private readonly CurrenciesExtensions currenciesExtensions = new CurrenciesExtensions();

        public CurrenciesController(ICurrencyService _currService)
        {
            _currencyService = _currService ?? throw new ArgumentNullException(nameof(_currService));
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(JResponseEntity<IEnumerable<CurrenciesDTO>>), 200)]
        public IActionResult LoadCurrencies()
        {
            JResponseEntity<IEnumerable<CurrenciesDTO>> ResponseData = new JResponseEntity<IEnumerable<CurrenciesDTO>>();
            IEnumerable<Currencies> CurrenciesList = _currencyService.GetAll();
            if(CurrenciesList != null)
            {
                ResponseData.Data = CurrenciesList.Select(x => currenciesExtensions.MapToModel(x)).ToList();
                ResponseData.Status = true;
            }
            return Ok(ResponseData);
        }
    }
}