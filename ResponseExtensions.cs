using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HttpServer
{
    public static class ResponseExtensions
    {
        public static async Task AsJson(this HttpListenerResponse response, string json)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            response.ContentType = "application/json";
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }
    }
}
