using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CategoryProductAggregation
{
    class CategoryList
    {
        List<Category> categories;

        public CategoryList()
        {
            categories = new List<Category>();
        }

        public void ReadFromFile(string FileName)
        {
            try
            {
                StreamReader reader = new StreamReader(FileName);
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        string[] items = line.Split('|');
                        if (items.Length == 2)
                        {
                            Category c = new Category(Convert.ToInt32(items[0]), items[1]);
                            categories.Add(c);
                        }
                        else if (items.Length == 3)
                        {
                            if (categories.Count == 0) throw new FormatException("Chua co category nao");
                            Product p = new Product(Convert.ToInt32(items[0]), items[1], Convert.ToDouble(items[2]));
                            categories[categories.Count - 1].AddProduct(p);
                        }
                        else
                        {
                            throw new FormatException("Sai format");
                        }
                    }catch(FormatException fe)
                    {
                        Console.WriteLine(fe.Message);
                    }
                }

                reader.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ten file khong ton tai");
            }
        }

        public void Display()
        {
            Console.WriteLine("Categories:");
            foreach (Category c in categories)
            {
                Console.WriteLine(c);
            }
        }

        public void Sort()
        {
            foreach(Category c in categories)
            {
                c.SortProductByID();
            }
            categories.Sort();
        }

        public void SortByProductName()
        {
            foreach (Category c in categories)
            {
                c.SortProductByName();
            }
            categories.Sort();
        }

        public void SortByProductPrice()
        {
            foreach (Category c in categories)
            {
                c.SortProductByPrice();
            }
            categories.Sort();
        }
    }
}
