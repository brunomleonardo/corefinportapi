using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dal.apifinport.Context;
using dal.apifinport.DataAccess;
using dal.apifinport.Interfaces;
using entities.apifinport.DtoModels;
using utils.apifinport;

namespace bll.apifinport
{
    public class ProductsBLL
    {
        private readonly IProductsService _ProductsService;

        public ProductsBLL(IProductsService ProductsService)
        {
            _ProductsService = ProductsService ?? throw new ArgumentException(nameof(ProductsService));
        }

        public async Task<JResponseEntity<IEnumerable<ProductsEntity>>> FindByTextAsync(string input)
        {
            JResponseEntity<IEnumerable<ProductsEntity>> RObj = new JResponseEntity<IEnumerable<ProductsEntity>>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                RObj = await _ProductsService.ReadByAbbvAsync(input);
            }
            else
            {
                RObj.Message = "Invalid term.";
            }
            return RObj;
        }
    }
}