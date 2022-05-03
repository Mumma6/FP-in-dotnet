
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/*

Example of currying and HOF
Delegates gör att functions blir First Class Cititens
*/

namespace ConsoleApp
{

  public static class Math
  {

    public static Func<decimal, decimal, decimal> GetOperation(char oper)
    {
      switch (oper)
      {
        case '+': return (x, y) => x + y;
        case '-': return (x, y) => x - y;
      }

      throw new NotSupportedException("Wierd stuff");
    }

    public static decimal Eval(string expr)
    {
      var el = expr.Split(new[] { ' ' }, 3);
      var x = Decimal.Parse(el[0]);
      var y = Decimal.Parse(el[1]);
      var op = el[2][0];

      return GetOperation(op)(x, y);
    }

  }
}