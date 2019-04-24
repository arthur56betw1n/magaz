using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace simpleCalc
{
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product()
        {
        }

        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{Code=1,Name="Galaxy Fold",Price=125_000},
                new Product{Code=2,Name="Galaxy F1",Price=9_000},
                new Product{Code=3,Name="Galaxy S2",Price=15_000},
                new Product{Code=4,Name="Galaxy S8",Price=68_000},
                new Product{Code=5,Name="iPhone XR",Price=140_000}
            };
        }
    }
}
