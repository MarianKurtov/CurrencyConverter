using Currency.Model;

namespace Currency.Services
{
    public interface IValueConverterServices
    {
        public decimal ConvertAndReturnResult(ResultModel resultModel);
    }
}
