using Currency.Model;
using Currency.Data;
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
        public decimal ConvertAndReturnResult(ResultModel resultModel)
        {
            var fromAfter = db
                 .ExchangeRates
                 .Where(x => x.NameOfValue == resultModel.from)
                 .Select(s => s.AmoundOfValue)
                 .Take(1)
                 .ToList();
            var fAfter = Convert.ToDecimal(fromAfter[0]);
            
            var toAfter = db
                .ExchangeRates
                .Where(x => x.NameOfValue == resultModel.to)
                .Select(s => s.AmoundOfValue)
                .Take(1)
                .ToList();
            var tAfter = Convert.ToDecimal(toAfter[0]);
            var rAfter = Convert.ToDecimal(resultModel.amound);

            decimal result = (tAfter / fAfter)*rAfter;

            return result;//
        }
    }
}
