using System;

namespace Reflection.Attributes
{
  [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]

  public class BugTag : System.Attribute
  {

    public BugTag(int bg, string dev, string d)
    {
      BugNo = bg;
      Developer = dev;
      LastReview = d;
    }

    public int BugNo { get; }

    public string Developer { get; }

    public string LastReview { get; }

    public string Message { get; set; }

  }
}