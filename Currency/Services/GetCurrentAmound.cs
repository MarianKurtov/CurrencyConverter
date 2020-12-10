using Currency.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Currency.Services
{
    public class GetCurrentAmound
    {
        public async Task GetResponse()
        {
            var httpClient = HttpClientFactory.Create();
            var url = "https://api.exchangeratesapi.io/latest";
            HttpResponseMessage messege = await httpClient.GetAsync(url);

            if (messege.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = messege.Content;
                
                var data = await content.ReadAsAsync<RequestModel>();
                
                // Тук правим записа в базата
                
                Console.WriteLine(data); 
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
