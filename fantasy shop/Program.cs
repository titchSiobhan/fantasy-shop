
using fantasy_shop.Endpoints;
using fantasy_shop.StartUp;


var builder = WebApplication.CreateBuilder(args);
builder.AddDenpendencies();

var app = builder.Build();
app.UseHttpsRedirection();

app.UseOpenApi();
app.ApplyCorsConfig();


app.AddShopEndpoints();
app.Run();