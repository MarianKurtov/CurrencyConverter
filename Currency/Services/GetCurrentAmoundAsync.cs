using Currency.Models;
using CurrencyConverterApp.Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Currency.Services
{
    public class GetCurrentAmoundAsync
    {
        public async Task GetResponseAsync(ApplicationDbContext db)
        {
            var httpClient = HttpClientFactory.Create();
            var url = "https://api.exchangeratesapi.io/latest";
            HttpResponseMessage messege = await httpClient.GetAsync(url);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            if (messege.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = messege.Content;
                
                var data = await content.ReadAsAsync<RequestModel>();

                foreach (var (name,value) in data.rates)
                {
                    ExchangeRate exchange = new ExchangeRate
                    {
                        NameOfValue = name,
                        AmoundOfValue = value,
                        ConvertType = data.@base,
                        RefreshedAt = data.date
                    };
                    db.ExchangeRates.Add(exchange);
                    db.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
