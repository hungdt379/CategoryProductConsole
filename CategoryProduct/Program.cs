using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CategoryProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Category category = new Category();
            category.Input(@"D:\data.txt");
            //category.SortProductByID();
            category.SortProductByPrice();
            Console.WriteLine(category.ToString());
            Console.ReadLine();
        }
    }
}
