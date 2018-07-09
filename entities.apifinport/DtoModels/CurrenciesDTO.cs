using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using entities.apifinport.DtoModels.Infrastructure;
using entities.apifinport.Models;
using System.ComponentModel.DataAnnotations;

namespace entities.apifinport.DtoModels
{
    public class CurrenciesDTO : BaseEntityDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public string Symbol { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public IEnumerable<ExchangesDTO> Exchanges { get; set; }
        public IEnumerable<WalletsDTO> Wallets { get; set; }
    }

    public class CurrenciesMapper : MapperBase<Currencies, CurrenciesDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private ExchangesMapper _exchangesMapper = new ExchangesMapper();
        private WalletsMapper _walletsMapper = new WalletsMapper();
        private BaseEntityMapper _baseEntityMapper = new BaseEntityMapper();
        public override Expression<Func<Currencies, CurrenciesDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Currencies, CurrenciesDTO>>)(p => new CurrenciesDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Symbol = p.Symbol,
                    Designation = p.Designation,
                    Name = p.Name,
                    Exchanges = p.Exchanges.AsQueryable().Select(this._exchangesMapper.SelectorExpression),
                    Wallets = p.Wallets.AsQueryable().Select(this._walletsMapper.SelectorExpression)
                })).MergeWith(this._baseEntityMapper.SelectorExpression);
            }
        }

        public override void MapToModel(CurrenciesDTO dto, Currencies model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.Symbol = dto.Symbol;
            model.Designation = dto.Designation;
            model.Name = dto.Name;
            this._baseEntityMapper.MapToModel(dto, model);
        }
    }
}
