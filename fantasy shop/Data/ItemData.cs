using fantasy_shop.Models;
using System.Data.SqlTypes;
using System.Text.Json;
namespace fantasy_shop.Data
{
    public class ItemData
    {
        public List<Product> Items { get; set; }
        public  ItemData()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Product.json");
            string json = File.ReadAllText(filePath);
            Items = JsonSerializer.Deserialize<List<Product>>(json, options) ?? new List<Product>();
        }
        public async Task SaveToJson()
        {
            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "Product.json");

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(Items, options);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
