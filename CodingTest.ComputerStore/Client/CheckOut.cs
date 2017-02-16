using CodingTest.ComputerStore.Package;
using CodingTest.ComputerStore.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore.Client
{
    public class CheckOut
    {
        IEnumerable<IOffer> offers;
        List<IProductOrder> orders = new List<IProductOrder>();
        public CheckOut(IEnumerable<IOffer> offers)
        {
            // assumption -- same offers will not be added multiple times 
            //               before injecting to this constructor this will be validated
            this.offers = offers;
        }
        public void Scan(IProduct product)
        {
            if (product == null)
                throw new ArgumentNullException("product object is null");
            
            var order = orders.FirstOrDefault(x => x.Product.SKU == product.SKU);

            if (order == null)
            {
                order = new ProductOrder() { Product = product, Quantity = 1 };
                orders.Add(order);
            }
            else
                order.Quantity++;

            // assumption -- offers can be validated different ways but not much concerned at this point
            if (offers != null)
            {
                foreach (Offer offer in offers)
                {
                    if (offer.IsValid(order))
                    {
                        offer.ApplyOffer(order, orders);
                    }
                }
            }
        }
        public double Total()
        {
            return orders.Sum(x => x.OfferPrice);
        }
        public double ActualPrice()
        {
            return orders.Sum(x => x.Quantity * x.Product.Price);
        }
    }
}
