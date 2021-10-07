using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CategoryProductAggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryList list = new CategoryList();
            list.ReadFromFile(@"D:\data.txt");
            list.Sort();
            list.Display();

            Console.WriteLine("\n -------Sort by Name");
            list.SortByProductName();
            list.Display();

            Console.WriteLine("\n -------Sort by Price");
            list.SortByProductPrice();
            list.Display();
            Console.ReadLine();
        }
    }
}
