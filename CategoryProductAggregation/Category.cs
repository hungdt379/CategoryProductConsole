using System;
using System.Collections.Generic;
using System.IO;

namespace CategoryProductAggregation
{
    class Category : IComparable
    {
        int id;
        string title;
        List<Product> products;

        public Category()
        {
            products = new List<Product>();
        }

        public Category(int id, string title)
        {
            this.id = id;
            this.title = title;
            products = new List<Product>();
        }

        public void AddProduct(Product p)
        {
            products.Add(p);
        }

        public override string ToString()
        {
            string str;
            str = String.Format("ID:{0}-Title:{1}\nList Of Product:\n",id , title);
            foreach (Product s in products)
            {
                str += s.ToString() + "\n";
            }
            return str;
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

        public int CompareTo(object obj)
        {
             Category c = (Category) obj;
            return this.id.CompareTo(c.id);
        }
    }
}
