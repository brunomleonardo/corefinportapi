using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using entities.apifinport.DtoModels;
using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using bll.apifinport;
using dal.apifinport.Interfaces;
using System.Threading.Tasks;

namespace api.coreapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductssController : ControllerBase
    {
        private readonly ProductsBLL _ProductsBLL;
        private readonly IProductsService _ProductsService;

        public ProductssController(IProductsService ProductsService) //: base(context)
        {
            _ProductsService = ProductsService ?? throw new ArgumentNullException(nameof(ProductsService));
            _ProductsBLL = new ProductsBLL(_ProductsService);
        }

        //[Route("loadProductss"), HttpGet]
        //[Authorize(JwtBearerDefaults.AuthenticationScheme)]
        //[EnableCors("CorsPolicy")]
        //public ActionResult<JResponseEntity<ProductsEntity>> LoadProductss()
        //{
        //    return _ProductsBLL.LoadProductss();
        //}

        [Route("{term}"), HttpGet]
        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        [EnableCors("CorsPolicy")]
        [ProducesResponseType(typeof(JResponseEntity<IEnumerable<ProductsEntity>>), 200)]
        public async Task<IActionResult> GetByAbbv([FromRoute]string term)
        {
            JResponseEntity<IEnumerable<ProductsEntity>> Response = await _ProductsBLL.FindByTextAsync(term);
            return Ok(Response);
        }

        //[Route("updateprices"), HttpGet]
        //[Authorize(JwtBearerDefaults.AuthenticationScheme)]
        //[EnableCors("CorsPolicy")]
        //public ActionResult<JResponseEntity<string>> UpdateProductsPrices()
        //{
        //    return _ProductsBLL.UpdateProductsPrices();
        //}
    }
}