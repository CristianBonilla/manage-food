using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ManageFood.Contracts.DTO.SeedData
{
  public abstract class SeedDataCollection<TData> where TData : class
  {
    int _index;
    readonly TData[] _collection;

    public int Count => _collection.Length;

    protected abstract TData[] Collection { get; }

    public TData this[int index] => _collection[index];

    protected SeedDataCollection(int size)
    {
      _collection = new TData[size];
      Init([.. _collection]);
    }

    public TProperty GetFromProperty<TProperty>(int index, Expression<Func<TData, TProperty>> property)
    {
      TData data = _collection[index];
      object? propertyValue = property.GetPropertyAccess().GetValue(data, null);

      return (propertyValue is TProperty value ? value : default)!;
    }

    private void Init(params TData[] collection)
    {
      foreach (TData data in collection)
        _collection[_index++] = data;
    }
  }
}
