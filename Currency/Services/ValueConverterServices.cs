using CurrencyConverterApp.Data;
using System;
using System.Linq;

namespace Currency.Services
{
    public class ValueConverterServices : IValueConverterServices
    {
        private readonly ApplicationDbContext db;

        public ValueConverterServices(ApplicationDbContext db)
        {
            this.db = db;
        }
        public decimal ConvertAndReturnResult(string from, string to, decimal amound)
        {
            var fromAfter = Convert.ToDecimal(db
                .ExchangeRates
                .Where(x => x.NameOfValue == from)
                .Select(s => s.AmoundOfValue).ToString());

            var toAfter = Convert.ToDecimal(db
                .ExchangeRates
                .Where(x => x.NameOfValue == to)
                .Select(s => s.AmoundOfValue).ToString());

            decimal result = (toAfter / fromAfter) * amound;

            return result;
        }
    }
}
