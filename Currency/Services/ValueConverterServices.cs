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
            var fromAfter = Convert.ToDecimal(db
                .ExchangeRates
                .Where(x => x.NameOfValue == resultModel.from)
                .Select(s => s.AmoundOfValue).ToString());

            var toAfter = Convert.ToDecimal(db
                .ExchangeRates
                .Where(x => x.NameOfValue == resultModel.to)
                .Select(s => s.AmoundOfValue).ToString());

            //decimal result = (toAfter / fromAfter) * resultModel.amound;

            return 0;//
        }
    }
}
