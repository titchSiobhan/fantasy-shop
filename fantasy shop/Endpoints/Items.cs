using fantasy_shop.Data;
using fantasy_shop.Models;
using Microsoft.AspNetCore.Mvc;
using fantasy_shop.Controllers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace fantasy_shop.Endpoints
{
    public static class Items
    {
        public static int CreateRandomId()
        {
            // Return a positive random id between 1 and int.MaxValue
            return System.Random.Shared.Next(1, int.MaxValue);
        }
       
        public static void AddShopEndpoints(this WebApplication app)
        {
            app.MapGet("/shop", GetShop);
            app.MapGet("/", () => "Hello :)");
            app.MapPost("/product", AddNewProduct);
            app.MapGet("/product/{Id}", GetSingleProduct);
            app.MapDelete("/product/{Id}/delete", DeleteProduct);
            app.MapPut("/product/{Id}/edit", UpdateItem);
        }

        private static async Task<IResult> GetShop([FromServices] ItemData data, string? search)
        {
            var items = await data.GetAll();
            var output = items.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
                output = output.Where(x => x.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

            return Results.Ok(output);
        }

        

        static async Task<IResult> AddNewProduct( Product product, [FromServices] ItemData data)
        {

            product.Id = CreateRandomId();
            var items = await data.GetAll();
            var item = items.Find(x => x.Id == product.Id);
            while (item != null)
            { 
                product.Id = CreateRandomId();
                item =items.Find(x => x.Id == product.Id);

            }
                if (product.Name == "" || product.Description == "")
            {
                return Results.BadRequest(new {message =  "Please enter product name and description."});
            }

            if (product.Price < 0 || product.StockQuantity < 0)
            {
                return Results.BadRequest(new {message = "Prices and Stock amount must not be a negative number."});
            }
            await data.Add(product);
            //await data.SaveToJson();

            return Results.Created($"/product/{product.Id}", product);
        }

        static async Task<IResult> GetSingleProduct(int Id, [FromServices] ItemData data)
        {
            var items = await data.GetAll();
            

             var item = items.Find(x => x.Id == Id);
            if (item == null)
                return Results.NotFound();

            return Results.Ok(item);
        }

        static async Task<IResult> DeleteProduct(int Id, [FromServices] ItemData data)
        {

            var items = await data.GetAll();
            var item = items.Find(x => x.Id == Id);
            if (item == null)
                return Results.NotFound();

            await data.Remove(item);
            //await data.SaveToJson();

            Console.WriteLine($"{item.Id} was deleted");
            return Results.Ok(new { message = $"{item.Name} was deleted." });
        }

      

        static async Task<IResult> UpdateItem(int Id, UpdateItemRequest request, [FromServices] ItemData data)
        {
           
            var items = await data.GetAll();
            var item = items.Find(x => x.Id == Id);
            if (item == null)
                return Results.NotFound();
            if (string.IsNullOrWhiteSpace(item.Name) || string.IsNullOrWhiteSpace(item.Description) )
            {
                return Results.BadRequest(new { message = "Please enter product name and description." });
            }


            if (item.Price < 0 || item.StockQuantity < 0)
            {
                return Results.BadRequest(new { message = "Prices and Stock amount must not be a negative number." });
            }

            item.Name = request.Name;
            item.Description = request.Description;
            item.Price = request.Price;
            item.StockQuantity = request.StockQuantity;

            //await data.SaveToJson();
            await data.Update(item);

            return Results.Ok(item);
        }

        static async Task<IResult> ItemsBought(int Id, [FromServices] ItemData data)
        {
            var items = await data.GetAll();

          
            
            var item = items.Find(x => x.Id == Id);
            if (item == null)
                return Results.NotFound();
            if (item.StockQuantity <= 0)
            {
                return Results.BadRequest(new { message = "Item is out of stock." });
            }
            item.StockQuantity--;
            await data.Update(item);
           //await data.SaveToJson();
            return Results.Ok(new { message = $"{item.Name} was bought. Remaining stock: {item.StockQuantity}" });
        }   
    }
}
