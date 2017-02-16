using CodingTest.ComputerStore.Exceptions;
using CodingTest.ComputerStore.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore.Package
{
    public class BuyOneGetOtherOffer : Offer
    {
        private string buyProductSKU;
        private string getProductSKU;
        public BuyOneGetOtherOffer(string name, string description, string buyProductSKU, string getProductSKU)
            : base(name, description)
        {
            this.buyProductSKU = buyProductSKU;
            this.getProductSKU = getProductSKU;
        }
        public override bool IsValid(IProductOrder order)
        {
            return (order.Product.SKU == getProductSKU || order.Product.SKU == buyProductSKU);
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
            // buyProductSKU count == getProductSKU count so equal
            // mac book pro= buy product 
            // get product is exist in previous scan 
            // apply offer for existing 
            if (order.Product.SKU == buyProductSKU && (orders.Count(x => x.Product.SKU == getProductSKU) >= orders.Count(x => x.Product.SKU == buyProductSKU)))
            {
                var existingGetOrder = orders.FirstOrDefault(x => x.Product.SKU == getProductSKU && x.OfferPrice != 0);
                if (existingGetOrder != null)
                {
                    existingGetOrder.OfferPrice -= existingGetOrder.Product.Price;
                }

            }
            // buyProductSKU count == getProductSKU count so equal
            // HDMI cable= get product 
            // buy product is exist in previous scan 
            // apply offer for current
            if (order.Product.SKU == getProductSKU && (orders.Count(x => x.Product.SKU == buyProductSKU) >= orders.Count(x => x.Product.SKU == getProductSKU)))
            {
                order.OfferPrice -= order.Product.Price;
            }
        }
    }
}
