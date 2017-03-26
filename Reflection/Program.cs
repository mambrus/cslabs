﻿using System;
using System.Reflection;

using Reflection.Attributes;

namespace Reflection
{

  #region Class rectangle

  [BugTag(45, "Zara Ali", "12/8/2012", Message = "Return type mismatch")]
  [BugTag(49, "Nuha Ali", "10/10/2012", Message = "Unused variable")]
  class Rectangle
  {
    //member variables
    protected double length;
    protected double width;

    public Rectangle(double l, double w)
    {
      length = l;
      width = w;
    }

    [BugTag(55, "Zara Ali", "19/10/2012", Message = "Return type mismatch")]
    public double GetArea()
    {
      return length * width;
    }

    [BugTag(56, "Zara Ali", "19/10/2012")]
    public void Display()
    {
      Console.WriteLine("Length: {0}", length);
      Console.WriteLine("Width: {0}", width);
      Console.WriteLine("Area: {0}", GetArea());
    }
  }

  #endregion

  #region class Program

  class Program
  {
    static void PrintBug(ref BugTag dbi)
    {
      Console.WriteLine("Bug no: {0}", dbi.BugNo);
      Console.WriteLine("Developer: {0}", dbi.Developer);
      Console.WriteLine("Last Reviewed: {0}", dbi.LastReview);
      Console.WriteLine("Remarks: {0}", dbi.Message);
      Console.WriteLine("........................");
    }

    static void Main(string[] args)
    {
      Rectangle rectangle = new Rectangle(4.5, 7.5);
      rectangle.Display();
      Console.WriteLine("========================");
      Type classInfo = typeof(Rectangle);

      #region iterating through the attribtues of the Rectangle class

      Console.WriteLine();
      Console.WriteLine("Print bugs tagged for Rectangle class");
      Console.WriteLine("=====================================");
      foreach (Object classAttribute in classInfo.GetCustomAttributes(false))
      {
        BugTag dbi = (BugTag) classAttribute;
        if (null != dbi)
        {
          PrintBug(ref dbi);
        }
      }

      #endregion

      #region  iterating through the method attribtues

      Console.WriteLine();
      Console.WriteLine("Print bugs tagged for each method");
      Console.WriteLine("=====================================");
      foreach (MethodInfo methodInfo in classInfo.GetMethods())
      {
        Console.WriteLine("Method: {0}", methodInfo.Name);
        Console.WriteLine("........................");
        foreach (Attribute methodAttribute in methodInfo.GetCustomAttributes(true))
        {
          BugTag dbi = (BugTag) methodAttribute;
          if (null != dbi)
          {
            PrintBug(ref dbi);
          }
        }
      }

      #endregion

      Console.ReadLine();
    }
  }

  #endregion
}