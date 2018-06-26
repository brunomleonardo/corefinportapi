using System;
using System.Collections.Generic;
using System.Linq;
using dal.apifinport.Context;
using dal.apifinport.Interfaces;
using entities.apifinport.Entities;
using entities.apifinport.Mappers;
using entities.apifinport.Models;

namespace dal.apifinport.DataAccess
{
    public class TickerDAL : ICrud<JResponseEntity<TickerEntity>, Ticker>
    {
        private FinPortContext _context;
        public TickerDAL(FinPortContext context)
        {
            this._context = context;
        }
        public JResponseEntity<TickerEntity> Create(Ticker Entity)
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<TickerEntity> CreatePlus(List<TickerCSVMapper> Tickers)
        {
            JResponseEntity<TickerEntity> RObj = new JResponseEntity<TickerEntity>();
            try
            {
                List<Ticker> TickersMapped = Tickers.Select(x => (Ticker)x).ToList();
                _context.Tickers.AddRange(TickersMapped);
                _context.SaveChanges();
                RObj.Status = true;
            }
            catch (Exception e)
            {
                RObj.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return RObj;
        }

        public JResponseEntity<TickerEntity> Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<TickerEntity> GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<TickerEntity> GetByText(string input)
        {
            JResponseEntity<TickerEntity> Result = new JResponseEntity<TickerEntity>();
            try
            {
                List<Ticker> TickersByAbbv
                    = _context.Tickers.Where(x => x.Abbv.ToLower().Contains(input.ToLower())).ToList();
                List<TickerEntity> DataResult = new List<TickerEntity>();
                if (TickersByAbbv != null && TickersByAbbv.Count > 0)
                {
                    DataResult = TickersByAbbv.Select(x => new TickerEntity()
                    {
                        id = x.Id,
                        abbv = x.Abbv,
                        company = x.Company,
                        current_price = x.CurrentPrice,
                        market_cap = x.MarketCap,
                        sector = x.Sector,
                        industry = x.Industry,
                        href = x.Href,
                        index_traded = x.IndexTraded,
                        currency = x.Currency
                    }).ToList();
                }
                Result.Status = true;
                Result.DataList = DataResult;
            }
            catch (Exception e)
            {
                Result.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return Result;
        }

        public JResponseEntity<TickerEntity> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<TickerEntity> Recover(int Id)
        {
            throw new System.NotImplementedException();
        }

        public JResponseEntity<TickerEntity> Update(Ticker Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}