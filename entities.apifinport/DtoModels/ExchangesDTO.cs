using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using entities.apifinport.DtoModels.Infrastructure;
using entities.apifinport.Models;

namespace entities.apifinport.DtoModels
{
    public class ExchangesDTO : BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public string Designation { get; set; }
        public string Symbol { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyDesignation { get; set; }
        public string CurrencyName { get; set; }
    }

    public class ExchangesMapper : MapperBase<Exchanges, ExchangesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private BaseEntityMapper _baseEntityMapper = new BaseEntityMapper();
        public override Expression<Func<Exchanges, ExchangesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Exchanges, ExchangesDTO>>)(p => new ExchangesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Designation = p.Designation,
                    Symbol = p.Symbol,
                    CurrencySymbol = p.Currency != null ? p.Currency.Symbol : default(string),
                    CurrencyDesignation = p.Currency != null ? p.Currency.Designation : default(string),
                    CurrencyName = p.Currency != null ? p.Currency.Name : default(string),
                    CurrencyId = p.Currency != null ? p.Currency.Id : default(int),
                })).MergeWith(this._baseEntityMapper.SelectorExpression);
            }
        }

        public override void MapToModel(ExchangesDTO dto, Exchanges model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Designation = dto.Designation;
            model.Symbol = dto.Symbol;
            model.CurrencyId = dto.CurrencyId;
            this._baseEntityMapper.MapToModel(dto, model);
        }
    }
}
