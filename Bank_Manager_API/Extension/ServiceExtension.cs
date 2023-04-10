using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Bank_Manager_API.Extension
{
    public static class ServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection svc)
        {
            svc.AddSwaggerGen(opt =>
            {
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => opt.IncludeXmlComments(xmlFile));

                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movies_API",
                    Contact = new OpenApiContact
                    {
                        Name = "Davinci Montas"
                    }
                });
                opt.EnableAnnotations();
                opt.DescribeAllParametersInCamelCase();
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your bearer token in this format - Bearer {your token goes in here}"
                });

            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection svc)
        {
            svc.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
