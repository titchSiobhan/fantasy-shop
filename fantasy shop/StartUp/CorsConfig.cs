namespace fantasy_shop.StartUp
{
    public static class CorsConfig
    {
        private const string CorsPolicyName = "AllowAll";
        public static void AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyName, policy =>
                {
                    policy.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }
        public static void ApplyCorsConfig(this WebApplication app)
        {
            app.UseCors(CorsPolicyName);
        }
    }
}
