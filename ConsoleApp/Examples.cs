using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
  public class Examples
  {

    public void DoWork()
    {
      System.Console.WriteLine("Hello from Examples");
    }

    public int getFive()
    {
      return 5;
    }

    public int Add(int a, int b) => a + b;

    public IEnumerable<int> FilterByOdd(IEnumerable<int> arr, int n)
    {
      Func<int, bool> isMod(int n) => x => x % n != 1;

      return arr.Where(isMod(n));
    }

    public void LogItemsInArray(IEnumerable<int> arr)
    {
      foreach (var item in arr)
      {
        System.Console.WriteLine(item);
      }
    }


  }
}