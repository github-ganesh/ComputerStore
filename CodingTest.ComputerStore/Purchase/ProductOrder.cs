using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore.Purchase
{
    public class ProductOrder : IProductOrder
    {
        private double offerprice;
        public IProduct Product { get; set; }
        public int Quantity { get; set; }
        public double OfferPrice 
        {
            get
            {
                if (IsOfferApplied)
                    return offerprice;
                return Quantity * Product.Price;
            }
            set
            {
                offerprice = value;
                IsOfferApplied = true;
            }

        }
        public bool IsOfferApplied { get; private set; }
        
    }
}
