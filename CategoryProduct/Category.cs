using System;
using System.Collections.Generic;
using System.IO;

namespace CategoryProduct
{
    class Category
    {
        int id;
        string title;
        List<Product> products;
        List<Category> categories;

        public Category()
        {
            products = new List<Product>();
            categories = new List<Category>();
        }

        public Category(string title)
        {
            this.title = title;
            products = new List<Product>();
            categories = new List<Category>();
        }

        public Category(int id, string title)
        {
            this.id = id;
            this.title = title;
            products = new List<Product>();
            categories = new List<Category>();
        }

        public override string ToString()
        {
            string str = "";
            foreach (Category c in categories)
            {
                str += String.Format("Category ID:{0} - Title{1}\n", c.id, c.title);
                foreach (Product p in products)
                {
                    if (p.title.Equals(c.title))
                    {
                        str += p.ToString() + "\n";
                    }
                }
            }

            return str;
        }

        public void Input(string fileName)
        {
            try
            {
                StreamReader reader = new StreamReader(fileName);
                string line;
                int categoryIndex = 0;
                while ((line = reader.ReadLine()) != null)
                {

                    string[] items = line.Split('|');
                    Category c;
                    Product p;
                    if (items.Length == 2)
                    {
                        categoryIndex++;
                        c = new Category(Convert.ToInt32(items[0]), items[1]);
                        categories.Add(c);
                    }
                    else if (items.Length == 3)
                    {
                        p = new Product(Convert.ToInt32(items[0]), items[1], Convert.ToDouble(items[2]), categories[categoryIndex - 1].title);
                        products.Add(p);
                    }
                    else throw new Exception("Not match product or category");

                }

                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SortProductByID()
        {
            products.Sort();
        }
        public void SortProductByName()
        {
            products.Sort(new NameComparer());
        }
        public void SortProductByPrice()
        {
            products.Sort(new PriceComparer());
        }
    }
}
