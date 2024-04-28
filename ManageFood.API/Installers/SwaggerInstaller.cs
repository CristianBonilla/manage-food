using Microsoft.OpenApi.Models;
using ManageFood.API.Filters;
using ManageFood.API.Options;
using ManageFood.Domain.Helpers;

namespace ManageFood.API.Installers
{
  class SwaggerInstaller : IInstaller
  {
    public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
      IConfigurationSection swaggerSection = configuration.GetSection(nameof(SwaggerOptions));
      services.Configure<SwaggerOptions>(swaggerSection);
      SwaggerOptions? swagger = swaggerSection.Get<SwaggerOptions>();
      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new()
        {
          Title = "Manage Food API",
          Version = "v1",
          Description = "Backend project with an API to manage food through a store",
          Contact = swagger is null ? default : swagger.Contact
        });
        options.SchemaFilter<EnumSchemaFilter>();
        OpenApiSecurityScheme apiSecurity = new()
        {
          Reference = new OpenApiReference
          {
            Id = ApiConfigKeys.Bearer,
            Type = ReferenceType.SecurityScheme
          }
        };
        options.AddSecurityRequirement(new OpenApiSecurityRequirement { { apiSecurity, new List<string>() } });
      });
    }
  }
}
