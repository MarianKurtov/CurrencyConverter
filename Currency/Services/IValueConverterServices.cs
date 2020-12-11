namespace Currency.Services
{
    public interface IValueConverterServices
    {
        public decimal ConvertAndReturnResult(string from, string to, decimal amound);
    }
}
