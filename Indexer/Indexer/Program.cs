using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
  class IndexedNames
  {
    private string[] namelist = new string[size];
    static public int size = 10;

    public IndexedNames()
    {
      for (int i = 0; i < size; i++)
      {
        namelist[i] = "N. A.";
      }
    }

    public IndexedNames(params string[] arglist)
    {
      for (int i = 0; i < arglist.Length; i++)
      {
        namelist[i] = arglist[i];
      }
    }

    public string this[int index]
    {
      get
      {
        string tmp;

        if (index >= 0 && index <= size - 1)
        {
          tmp = namelist[index];
        }
        else
        {
          tmp = "";
        }

        return (tmp);
      }
      set
      {
        if (index >= 0 && index <= size - 1)
        {
          namelist[index] = value;
        }
      }
    }

    public int this[string name]
    {
      get
      {
        int index = 0;
        while (index < size)
        {
          if (namelist[index] == name)
          {
            return index;
          }
          index++;
        }
        return index;
      }

    }

    static void Main(string[] args)
    {
      IndexedNames names_2 = new IndexedNames(
        "Zara",
        "Riz",
        "Nuha",
        "Asif",
        "Davinder",
        "Sunil",
        "Rubic");

      IndexedNames names = new IndexedNames();
      //using the first indexer with int parameter to reverse the order
      for (int i = 0; i < IndexedNames.size; i++)
      {
        names[i] = names_2[IndexedNames.size -i];
      }

      //using the first indexer with int parameter to print the list
      for (int i = 0; i < IndexedNames.size; i++)
      {
        Console.WriteLine(i + ": " + names[i]);
      }

      //using the second indexer with the string parameter
      Console.WriteLine("Type which name to find it's index for:");
      string name = Console.ReadLine();
      Console.WriteLine("Indexed is: " + names[name]);
      Console.ReadKey();
    }
  }
}