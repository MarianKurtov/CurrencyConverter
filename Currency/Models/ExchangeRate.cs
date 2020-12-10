namespace Currency.Models
{
    public class ExchangeRate
    {
        public int Id { get; set; }

        public string NameOfValue { get; set; }

        public decimal AmoundOfValue { get; set; }

        public string ConvertType { get; set; }

        public string RefreshedAt { get; set; }
    }
}
