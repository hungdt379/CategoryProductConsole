using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CategoryProduct
{
    class Product : Category, IComparable<Product>
    {
        int id;
        string name;
        double price;

        public Product()
        {
        }

        public Product(int id, string name, double price, string categoryName):base(categoryName)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public int CompareTo(Product other)
        {
            return this.id.CompareTo(other.id);
        }

        public override string ToString()
        {
            return String.Format("ID:{0} - Name:{1} - Price:{2}", id, name, price);
        }

        public int SortByProductName(Product p)
        {
            return this.name.CompareTo(p.name);
        }

        public int SortByProductPrice(Product p)
        {
            return this.price.CompareTo(p.price);
        } 
        
    }

    class PriceComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.SortByProductPrice(y);
        }
    }

    class NameComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.SortByProductName(y);
        }
    }
}
