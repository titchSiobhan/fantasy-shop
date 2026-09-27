using fantasy_shop.Models;

using Microsoft.EntityFrameworkCore;

namespace fantasy_shop.Data;

public class ItemData
{
    //public List<Product> Items { get; set; }
    //public  ItemData()
    //{
    //    var options = new JsonSerializerOptions
    //    {
    //        PropertyNameCaseInsensitive = true
    //    };
    //    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Product.json");
    //    string json = File.ReadAllText(filePath);
    //    Items = JsonSerializer.Deserialize<List<Product>>(json, options) ?? new List<Product>();
    //}
    //public async Task SaveToJson()
    //{
    //    string filePath = Path.Combine(
    //        Directory.GetCurrentDirectory(),
    //        "Data",
    //        "Product.json");

    //    var options = new JsonSerializerOptions
    //    {
    //        WriteIndented = true
    //    };

    //    string json = JsonSerializer.Serialize(Items, options);
    //    await File.WriteAllTextAsync(filePath, json);
    //}

    private readonly AppDbContext _db;
    public ItemData(AppDbContext db)
    {
        _db = db;
    }
    public async Task<List<Product>> GetAll()
    {
        return await _db.Items.ToListAsync();
    }

    public async Task Add(Product product)
    {
        _db.Items.Add(product);
        await _db.SaveChangesAsync();

    }
    public async Task Remove(Product product)
    {
        _db.Items.Remove(product);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _db.Items.Update(product);
        await _db.SaveChangesAsync();
    }
}

