using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using entities.apifinport.Entities;
using entities.apifinport.Mappers;

namespace entities.apifinport.Models
{
    public class Ticker : BaseEntity
    {
        [Key]
        public override int Id { get; set; }
        public string Abbv { get; set; }
        public string Company { get; set; }
        public string IndexTraded { get; set; }
        public string Currency { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal Change { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string MarketCap { get; set; }
        public string Href { get; set; }
        public List<UserOperationHistory> UserOperationHistories { get; set; }

        public static explicit operator Ticker(TickerCSVMapper ticker)
        {
            decimal currentPrice = 0;
            decimal.TryParse(ticker.LastSale, out currentPrice);
            return new Ticker()
            {
                Abbv = ticker.Symbol,
                Company = ticker.Name,
                CurrentPrice = currentPrice,
                MarketCap = ticker.MarketCap,
                Sector = ticker.Sector,
                Industry = ticker.industry,
                Href = ticker.SummaryQuote,
                IndexTraded = "NASDAQ",
                Currency = "USD"
            };
        }

        public static explicit operator Ticker(TickerEntity entity)
        {
            return new Ticker();
        }

    }
}