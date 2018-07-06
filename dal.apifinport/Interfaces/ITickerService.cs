using entities.apifinport.Entities;
using entities.apifinport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dal.apifinport.Interfaces
{
    public interface IProductsService : IBaseService<JResponseEntity<ProductsEntity>, Products>
    {
        Task<JResponseEntity<IEnumerable<ProductsEntity>>> ReadByAbbvAsync(string Abbv);
    }
}
