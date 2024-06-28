using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.Entities;
using ManageFood.Domain.Helpers;

namespace ManageFood.Domain.SeedWork.Collections.Auth
{
  class UserCollection : SeedDataCollection<UserEntity>
  {
    static readonly RoleCollection _roles = AuthCollection.Roles;
    readonly (string Password, byte[] SaltBytes) _hash = HashPasswordHelper.Create("C.C1023944678.1995");

    protected override UserEntity[] Collection => [
      new UserEntity
      {
        UserId = new("{c880a1fd-2c32-46cb-b744-a6fad6175a53}"),
        RoleId = _roles[0].RoleId,
        DocumentNumber = "1023944678",
        Mobile = "+573163534451",
        Username = "chris__boni",
        Password = _hash.Password,
        Email = "cristian10camilo95@gmail.com",
        Firstname = "Cristian Camilo",
        Lastname = "Bonilla",
        IsActive = true,
        Salt = _hash.SaltBytes
      }
    ];
  }
}
