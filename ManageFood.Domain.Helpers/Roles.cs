namespace ManageFood.Domain.Helpers
{
  public readonly struct Roles
  {
    public static readonly (Guid Id, string Name) AdminUser = (new("{d146b771-7df4-411f-8ccb-490b2d65d22f}"), nameof(AdminUser));
    public static readonly (Guid Id, string Name) CommonUser = (new("{838c1363-9abd-4999-95e8-71382312ac74}"), nameof(CommonUser));
  }
}
