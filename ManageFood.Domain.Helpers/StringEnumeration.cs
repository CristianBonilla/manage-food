using System.Reflection;

namespace ManageFood.Domain.Helpers
{
  public abstract class StringEnumeration : IComparable
  {
    static readonly BindingFlags _bindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;

    public int Key {  get; set; }
    public string Value { get; set; }

    protected StringEnumeration(int key, string value) => (Key, Value) = (key, value);

    public static IEnumerable<T> GetAll<T>() where T : StringEnumeration => GetEnumerations<T>();

    public static T? FromValue<T>(string value) where T : StringEnumeration =>
      GetEnumerations<T>().FirstOrDefault(enumeration => enumeration.Value == value);

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

    private static IEnumerable<T> GetEnumerations<T>() where T : StringEnumeration
    {
      Type type = typeof(T);
      IEnumerable<MemberInfo> members = [.. type.GetFields(_bindingFlags), .. type.GetProperties(_bindingFlags)];
      foreach (MemberInfo member in members)
      {
        object? memberValue = member switch
        {
          FieldInfo field => field.GetValue(null),
          PropertyInfo property => property.GetValue(null),
          _ => null
        };
        if (memberValue is T enumeration)
          yield return enumeration;
      }
    }
  }
}
