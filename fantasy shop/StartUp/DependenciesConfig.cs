using fantasy_shop.Data;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace fantasy_shop.StartUp
{
    public static class DependenciesConfig
    {
        
        public static void AddDenpendencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenApiServices();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            builder.Services.AddTransient<ItemData>();

        
            builder.Services.AddCorsServices();
        }
    }
}
