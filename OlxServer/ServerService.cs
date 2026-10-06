using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Text;


namespace OlxServer
{
    public class ServerService
    {
        public async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[4096];
            int bytesRead = await stream.ReadAsync(buffer);
            string request = Encoding.UTF8.GetString(
                buffer,
                0,
                bytesRead);
            Console.WriteLine($"Отримано: {request}");
            string response = await ProcessRequest(request);
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await stream.WriteAsync(responseBytes);
            client.Close();
        }

        private async Task<string> ProcessRequest(
            string request)
        {
            if (request == "GET_PRODUCTS")
            {
                return await GetProducts();
            }
            if (request == "AUTH")
            {
                return "AUTH OK";
            }
            return "UNKNOWN COMMAND";
        }

        private async Task<string> GetProducts()
        {
            using var db = new AppDbContext();
            var products = await db.Products
                .Where(x => x.Status == "ForSale")
                .ToListAsync();
            if (products.Count() == 0)
            {
                return "Товарів немає.";
            }
            StringBuilder result = new StringBuilder();
            foreach (var product in products)
            {
                result.AppendLine(
                    $"ID: {product.Id}; " +
                    $"Назва: {product.ProductName}; " +
                    $"Ціна: {product.Price}; " +
                    $"Статус: {product.Status}");
            }
            return result.ToString();
        }
    }
}