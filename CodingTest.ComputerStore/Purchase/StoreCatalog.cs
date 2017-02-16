using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore.Purchase
{
    public class StoreCatalog
    {
        private List<IProduct> products = new List<IProduct>();
        public StoreCatalog()
        {
            // assumption -- data will be retrieved from db or external source
            
            products.Add(new Product("nx9", "Nexus 9", 549.99));
            products.Add(new Product("mbp", "MacBook Pro", 1399.99));
            products.Add(new Product("atv", "Apple TV", 109.50));
            products.Add(new Product("hdm", "HDMI adapter", 30.00));

        }
        public string Name { get; set; }
        public IEnumerable<IProduct> Products { get { return products; } }
    }
}
