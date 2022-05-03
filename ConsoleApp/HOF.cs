
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace ConsoleApp
{

  // kan detta vara i en egen fil?
  public static class Extensions
  {
    public static IEnumerable<T> FilterWithWhereExpressions<T>(this IEnumerable<T> items, Func<T, bool> predicate)
    {
      foreach (T item in items)
      {
        if (predicate(item))
        {
          yield return item;
        }
      }
    }

    public static IEnumerable<T1> TransformWithOperation<T1>(this IEnumerable<T1> items, Func<T1, T1> transformer)
    {
      foreach (T1 item in items)
      {
        yield return transformer(item);
      }
    }

    // compose function
    public static Func<T, TReturn2> Compose<T, TReturn1, TReturn2>(this Func<TReturn1, TReturn2> func1, Func<T, TReturn1> func2)
    {
      return x => func1(func2(x));
    }

    // pipe function

    // can create similar pipeline functions for arrays. This is similar to Linq functions
    // https://github.com/LinkedInLearning/functional-csharp-2833002/blob/07-05/source/FunctionalCSharp/ConsoleApp/Examples.cs
    // input and return are the same type
    public static int PipeAddTo(this int candidate, int adder)
    {
      return candidate + adder;
    }
    public static T PerformOperation<T>(this T value, Func<T, T> performer)
    {
      return performer(value);
    }

    //  Function factory, return a function
    public static Func<int, int> AddTo(int n) => i => i + n;

    public static Func<int, int> RemoveTo(int n) => i => i - n;

  }
}