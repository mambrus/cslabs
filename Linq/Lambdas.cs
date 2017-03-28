#region Header
// Copyright (c) Medius AB, 2017
// 
// Modified by: Michael Ambrus
#endregion
namespace LinqExercise
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Linq.Expressions;
  using System;

  delegate bool WhereDelegate(int a);
  delegate int AddDelegate(int a, int b);

  public class Lambdas
  {

    public void print_below_and_above(int below, int above, int[] source)
    {

      // The last parameter of Func<...> is always the result.
      Func<int, int, int> Add = (lhs, rhs) => lhs + rhs;
      AddDelegate adder = (lhs, rhs) => lhs + rhs;

      foreach (int i in source.Where(
        (y) =>
        {
          if (y <= below)

            return true;
          else if (y >= above)
            return true;

          return false;
        }
      ))
        Console.WriteLine(i);

      Console.WriteLine(below + " + " + above + " = " + Add(below, above));
      Console.WriteLine(below + " + " + above + " = " + adder(below, above));
    }

    public void print_your_choice(Func<int, bool> what, int[] source)
    {
      foreach (int i in source.Where(what))
        Console.WriteLine(i);
    }
  }
}
