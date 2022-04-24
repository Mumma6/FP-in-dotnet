using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
  public class Boken
  {

    public List<int> QuickSort(List<int> list)
    {
      if (list.Count == 0) return new List<int>();

      var pivot = list[0];
      var rest = list.Skip(1);

      var small = from item in rest where item <= pivot select item;
      var large = from item in rest where pivot < item select item;

      return QuickSort(small.ToList())
        .Append(pivot)
        .Concat(QuickSort(large.ToList()))
        .ToList();
    }


    Func<int, int> AddByNum(int x) => (int y) => x * y;

    public IEnumerable<int> IncreseBy(IEnumerable<int> arr, int x) => arr.Select(AddByNum(x));


    // hur använder man denna?
    Func<T, bool> Negate<T>(Func<T, bool> pred) => t => !pred(t);


  }
}