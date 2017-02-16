using CodingTest.ComputerStore.Client;
using CodingTest.ComputerStore.Package;
using CodingTest.ComputerStore.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore

{
    class Program
    {
        static void Main()
        {
            StoreCatalog catalog = new StoreCatalog();
            do
            {
                CheckOut checkout = new CheckOut(new List<IOffer>()
                    {
                        // assumption -- data will be retrieved from db/external source
                        // assumption -- each offer will go as separate dll & injected at runtime
                       
                       new BuyAndGetManyOffer("Buy 2 Get 3 Apple TV offer", "Buy 2 Get 3 Apple TV offer", "atv", 2, 3)  
                        ,new BuyOneGetOtherOffer("Buy MacBook Pro get HDMI Adapter free","Buy MacBook Pro get HDMI Adapter free","mbp", "hdm")
                        ,new FlatDiscountOffer("Buy 4 or more Nexus 9 and get discounted price of 499.99","Buy 4 or more Nexus 9 and get discounted price of 499.99","nx9", 4, 499.99)
                    });

                Console.WriteLine("Please enter product name to buy ( nx9, mbp, atv, hdm)");
                Console.WriteLine("Press Enter to get total");
                bool cartEnd = false;
                while(!cartEnd)
                {
                    string str = Console.ReadLine();
                    if(string.IsNullOrEmpty(str))
                    {
                        cartEnd = true;
                    }
                    var product = catalog.Products.FirstOrDefault(x => x.SKU == str);
                    if (product != null)
                    {
                        checkout.Scan(product);
                    }
                    else if(!string.IsNullOrEmpty(str))
                    {
                        Console.WriteLine("--"+str+ "-- not valid product");
                    }
                } 

                Console.WriteLine("Actual Price =" + checkout.ActualPrice());
                Console.WriteLine("Discounted Price =" + checkout.Total());
                Console.WriteLine("\nESC to exit / any key to continue\n");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }


    
   
   
   

    

    
   

}

