using CodingTest.ComputerStore.Exceptions;
using CodingTest.ComputerStore.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore.Package
{
    public class FlatDiscountOffer : Offer
    {
        private string productSKU;
        private int nBuy;
        private double newPrice;

        public FlatDiscountOffer(string name, string description,string productSKU, int nBuy, double newPrice)
            : base(name, description)
        {
            this.productSKU = productSKU;
            this.nBuy = nBuy;
            this.newPrice = newPrice;
        }
        public override bool IsValid(IProductOrder order)
        {
            return (order.Product.SKU == productSKU);
        }
        public override void ApplyOffer(IProductOrder order, List<IProductOrder> orders)
        {
            if (order == null)
            {
                throw new ArgumentNullException("Order object is null");
            }
            if (!IsValid(order))
            {
                throw new OfferNotValidException(string.Format("Offer {0} not valid for this {1} product", Name, order.Product.Name));
            }
            if (order.Quantity >= nBuy)
            {
                order.OfferPrice = order.Quantity * newPrice;
            }

        }

    }
}
