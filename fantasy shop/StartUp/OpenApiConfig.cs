using Scalar.AspNetCore;

namespace fantasy_shop.StartUp
{
    public static class OpenApiConfig
    {
        public static void AddOpenApiServices(this IServiceCollection services)
        {
            services.AddOpenApi();
        }
        public static void UseOpenApi(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.Title = "Fanstay Shop";
                    options.Theme = ScalarTheme.Kepler;
                    options.Layout = ScalarLayout.Modern;
                    //options.HideClientButton = true;
                });
            }
        }
    }
}
