using CodingTest.ComputerStore.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore.Purchase
{
     public class Product:IProduct
    {
         public Product(string sku, string name, double price)
         {
             SKU = sku;
             Name = name;
             Price = price;
         }
        public string SKU { get;  private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        
    }
}
