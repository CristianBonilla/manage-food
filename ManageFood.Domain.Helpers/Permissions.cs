namespace ManageFood.Domain.Helpers
{
  public readonly struct Permissions
  {
    public static readonly (Guid Id, string Name) AllowManageFood = (new("{b4748720-c24d-44bb-9c76-cdddc3a0574d}"), nameof(AllowManageFood));
    public static readonly (Guid Id, string Name) AllowListOrders = (new("{a4f4aba0-8a5c-431d-82d5-de44bebd223e}"), nameof(AllowListOrders));
    public static readonly (Guid Id, string Name) AllowListOrderByUser = (new("{7cadecb0-c11f-4884-beaf-7b37090282a1}"), nameof(AllowListOrderByUser));
    public static readonly (Guid Id, string Name) AllowCreateOrder = (new("{e74c1d1b-c402-43d1-9492-0df9a67729c8}"), nameof(AllowCreateOrder));
  }
}
