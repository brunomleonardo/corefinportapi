using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using dal.apifinport.Context;
using dal.apifinport.Interfaces;
using entities.apifinport.Entities;
using entities.apifinport.Models;

namespace dal.apifinport.DataAccess
{
    public class ProductsDAL : IProductsService
    {
        private readonly FinPortContext _context;

        public ProductsDAL(FinPortContext context)
        {
            _context = context;
        }
        public JResponseEntity<ProductsEntity> Create(Products Entity)
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<ProductsEntity> Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<ProductsEntity> GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<string> UpdatePrices()
        {
            JResponseEntity<string> Result = new JResponseEntity<string>();
            HttpClient client = new HttpClient();
            // private static readonly HttpClient client = new HttpClient();
            try
            {
                client.GetStreamAsync("");
            }
            catch (Exception e)
            {
                Result.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return Result;
        }

        public Task<JResponseEntity<ProductsEntity>> ReadOneAsync(int Id, string Name)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<ProductsEntity>> CreateAsync(ProductsEntity Product)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<ProductsEntity>> CreateMultipleAsync(List<Products> Data)
        {
            JResponseEntity<ProductsEntity> RObj = new JResponseEntity<ProductsEntity>();
            try
            {
                _context.Products.AddRange(Data);
                _context.SaveChanges();
                RObj.Status = true;
            }
            catch (Exception e)
            {
                RObj.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return Task.FromResult(RObj);
        }

        public Task<JResponseEntity<ProductsEntity>> UpdateAsync(ProductsEntity Product)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<ProductsEntity>> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<IEnumerable<ProductsEntity>>> ReadByAbbvAsync(string Abbv)
        {
            JResponseEntity<IEnumerable<ProductsEntity>> Result = new JResponseEntity<IEnumerable<ProductsEntity>>();
            try
            {
                List<Products> ProductsByAbbv
                    = _context.Products.Where(x => x.Abbv.ToLower().Contains(Abbv.ToLower())).ToList();
                if (ProductsByAbbv != null && ProductsByAbbv.Count > 0)
                {
                    Result.Data = ProductsByAbbv.Select(x => new ProductsEntity()
                    {
                        id = x.Id,
                        abbv = x.Abbv,
                        company = x.Company,
                        current_price = x.CurrentPrice.Value,
                        market_cap = x.MarketCap,
                        sector = x.Sector,
                        industry = x.Industry,
                        href = x.Href,
                        index_traded = x.Exchange.Designation,
                        currency = x.Currency
                    }).ToList();
                }
                Result.Status = true;
            }
            catch (Exception e)
            {
                Result.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return Task.FromResult(Result);
        }

        public Task<JResponseEntity<ProductsEntity>> CreateAsync(Products Entity)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<ProductsEntity>> UpdateAsync(Products Entity)
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<ProductsEntity>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<JResponseEntity<ProductsEntity>> ReadMultipleByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}