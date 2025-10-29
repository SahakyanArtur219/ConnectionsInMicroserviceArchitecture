using System;
using System.Threading;
using System.Threading.Tasks;
using SimpleHttp;

namespace HttpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Route.Add("/api/products/{id}", async (req, res, props) =>
            {
                string id = props["id"];
                string response = $"{{ \"id\": {id}, \"name\": \"Laptop\", \"price\": 999.99 }}";
                Thread.Sleep(5000);
                await res.AsJson(response); // We use await for sync connection
            });
            SimpleHttp.HttpServer.ListenAsync(
                1337,
                CancellationToken.None,
                Route.OnHttpRequestAsync
            ).Wait();
        }
    }
}
