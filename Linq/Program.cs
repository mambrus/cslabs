using System;

namespace LinqExercise
{
  class Program
  {
    static void Main(string[] args)
    {
      new Lambdas().print_below_and_above(4,
        7,
        new[]
        {
          3,
          8,
          4,
          6,
          1,
          7,
          9,
          2,
          4,
          8
        });

      Func<int, bool> myChooser = (mupp) =>
      {
        if (mupp > 5)
          return true;
        else
          return false;
      };

      new Lambdas().print_your_choice(myChooser,
        new int[]
        {
          9,
          2,
          8,
          4,
          23,
          4,
          3
        });
      Console.ReadKey();
    }
  }
}
