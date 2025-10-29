using System.Net.Http;
using System.Threading.Tasks;

namespace OrderServiceApp
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetProductInfoAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"/api/products/{productId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
