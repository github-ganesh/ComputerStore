using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore.Purchase
{
    /// <summary>
    /// Purchase Product Order
    /// </summary>
    public interface IProductOrder
    {
        /// <summary>
        /// Gets value indicating whether this instance is offer applied.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is offer applied; otherwise, <c>false</c>.
        /// </value>
        bool IsOfferApplied { get;  }
        /// <summary>
        /// Gets or sets the offer product price.
        /// </summary>
        /// <value>
        /// The offer product price.
        /// </value>
        double OfferPrice { get; set; }
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        IProduct Product { get; set; }
        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        /// <value>
        /// The product quantity.
        /// </value>
        int Quantity { get; set; }
    }
}
