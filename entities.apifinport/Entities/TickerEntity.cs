namespace entities.apifinport.Entities
{
    public class TickerEntity
    {
        public int id { get; set; }
        public string abbv { get; set; }
        public string company { get; set; }
        public string index_traded { get; set; }
        public string currency { get; set; }
        public decimal current_price { get; set; }
        public decimal Change { get; set; }
        public string sector { get; set; }
        public string industry { get; set; }
        public string market_cap { get; set; }
        public string href { get; set; }
    }
}