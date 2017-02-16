using CodingTest.ComputerStore.Exceptions;
using CodingTest.ComputerStore.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore.Package
{
    public class BuyAndGetManyOffer : Offer
    {
        private string productSKU;
        private int nBuy;
        private int mOffer;
        public BuyAndGetManyOffer(string name, string description, string productSKU, int nBuy, int mOffer)
            : base(name, description)
        {
            this.productSKU = productSKU;
            this.nBuy = nBuy;
            this.mOffer = mOffer;
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
            int set = (order.Quantity / mOffer);

            if (set > 0)
            {
                order.OfferPrice = (set * nBuy) * order.Product.Price;
                order.OfferPrice += (order.Quantity - (set * mOffer)) * order.Product.Price;
            }
            // 5/2 = 2  
            //total=  2 * 2 * price = (2*2) * $10 == 4*10 = 40
            //total+=  5-( 2*2) =1 * price; = (5-4) =1 * $10 = 10 // remaining one product doesn't have any discount 
        }

    }
}
