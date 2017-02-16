using CodingTest.ComputerStore.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore.Package
{
    public class Offer : IOffer
    {
        public Offer(string name, string description )
        {
            Name = name;
            Description = description;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual bool IsValid(IProductOrder order) { return true; }
        public virtual void ApplyOffer(IProductOrder order, List<IProductOrder> orders)
        {
            order.OfferPrice = order.Quantity * order.Product.Price;
        }
        public int Priority { get; set; }

    }
}
