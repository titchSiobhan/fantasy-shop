using fantasy_shop.Models;

namespace fantasy_shop.Controllers
{
    public static class ManagedProducts
    {
        static HttpClient client = new HttpClient();

        static void ShowProduct(Product product)
        {
            Console.WriteLine($"Name: {product.Name}\n Price: £{product.Price}");

        }

        static async Task<Uri> AddNewProduct(Product product)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "products", product);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
    }
}
