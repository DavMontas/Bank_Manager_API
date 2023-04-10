using Swashbuckle.AspNetCore.SwaggerUI;

namespace Bank_Manager_API.Extension
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "RealEstateAPI");
                opt.DefaultModelRendering(ModelRendering.Model);
            });
        }

    }
}
