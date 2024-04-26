using System.Reflection;

namespace ManageFood.Domain.Helpers
{
  public abstract class StringEnumeration : IComparable
  {
    public int Key {  get; set; }
    public string Value { get; set; }

    protected StringEnumeration(int key, string value) => (Key, Value) = (key, value);

    public static IEnumerable<T> GetAll<T>() where T : StringEnumeration =>
      typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
        .Select(field => field.GetValue(null))
        .Cast<T>();

    public int CompareTo(object? other) => Key.CompareTo((other as StringEnumeration)?.Key ?? -1);

    public override string ToString() => Value;

    public override bool Equals(object? obj)
    {
      if (obj is not StringEnumeration otherValue)
        return false;
      bool typeMatches = GetType().Equals(obj.GetType());
      bool valueMatches = Key.Equals(otherValue.Key);

      return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Key.GetHashCode();
  }
}
