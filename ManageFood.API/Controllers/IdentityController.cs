using Asp.Versioning;
using ManageFood.Contracts.Repository;
using ManageFood.Domain.Entities;
using ManageFood.Infrastructure.Contexts.FoodShop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageFood.API.Controllers
{
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  [Produces("application/json")]
  public class IdentityController : ControllerBase
  {
    public IdentityController(IRepository<FoodShopContext, RoleEntity> repository)
    {
      
    }
  }
}
