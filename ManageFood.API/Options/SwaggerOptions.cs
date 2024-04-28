using Microsoft.OpenApi.Models;

namespace ManageFood.API.Options
{
  class SwaggerOptions
  {
    public required string JsonRoute { get; set; }
    public required string UIEndpoint { get; set; }
    public string? Description { get; set; }
    public OpenApiContact? Contact { get; set; }
  }
}
