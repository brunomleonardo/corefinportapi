using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinPort.Core.Models;
using FinPort.Data;

namespace FinPort.Services.Currency
{
    public partial class CurrencyService : ICurrencyService
    {
        private readonly IRepository<Currencies> _currencyRepository;
        private readonly IDbContext _dbContext;

        public CurrencyService(IRepository<Currencies> _currencyRep, IDbContext _context)
        {
            this._dbContext = _context;
            this._currencyRepository = _currencyRep;
        }

        public IEnumerable<Currencies> GetAll()
        {
            return this._currencyRepository.Table.ToList();
        }
    }
}
