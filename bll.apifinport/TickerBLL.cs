using System.Collections.Generic;
using dal.apifinport.Context;
using dal.apifinport.DataAccess;
using entities.apifinport.Entities;
using entities.apifinport.Mappers;
using utils.apifinport;

namespace bll.apifinport
{
    public class TickerBLL
    {
        private TickerDAL _TickerDALL;
        public TickerBLL(FinPortContext context)
        {
            _TickerDALL = new TickerDAL(context);
        }

        public JResponseEntity<TickerEntity> LoadTickers()
        {
            JResponseEntity<TickerEntity> RObj = new JResponseEntity<TickerEntity>();
            CsvJob loaderCsv = new CsvJob(@"C:\Users\bleonardo\Desktop\Work\STUFF_CORE_AJS\corefinportapi\utils.apifinport\CsvFiles\nasdaq_tickers.csv");
            List<TickerCSVMapper> Tickers = loaderCsv.GetAllTickers();
            RObj = _TickerDALL.CreatePlus(Tickers);
            return RObj;
        }

        public JResponseEntity<TickerEntity> FindByText(string input)
        {
            JResponseEntity<TickerEntity> RObj = new JResponseEntity<TickerEntity>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                RObj = _TickerDALL.GetByText(input);
            }
            else
            {
                RObj.Message = "Invalid term.";
            }
            return RObj;
        }
    }
}