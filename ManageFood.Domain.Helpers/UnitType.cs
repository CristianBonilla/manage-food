namespace ManageFood.Domain.Helpers
{
  public class UnitType(int key, string value) : StringEnumeration(key, value)
  {
    public static UnitType Liter => new(1, "Lt");
    public static UnitType Milliliter => new(2, "Ml");
    public static UnitType Kilograms => new(3, "Kg");
    public static UnitType Gram => new(4, "G");
    public static UnitType Pound => new(5, "Lb");
    public static UnitType Once => new(6, "Oz");
  }
}
