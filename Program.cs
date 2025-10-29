using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderServiceApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:1337");
            var orderService = new OrderService(httpClient);
            while (true)
            {
                Console.Write("Enter product ID: ");
                int productId = int.Parse(Console.ReadLine() ?? "1");

                /*   try
                   {
                       var productInfo = await orderService.GetProductInfoAsync(productId);
                       Console.WriteLine("Product Info:");
                       Console.WriteLine(productInfo);
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine($"Error: {ex.Message}");
                   }*/

                try
                {
                    int capturedId = productId;
                    Task.Run(async () =>
                    {
                        try
                        {
                            var productInfo = await orderService.GetProductInfoAsync(capturedId);
                            Console.WriteLine("Product Info:");
                            Console.WriteLine(productInfo);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Async Error: {ex.Message}");
                        }
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
    }
}
