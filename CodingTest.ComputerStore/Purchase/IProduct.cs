using System;
namespace CodingTest.ComputerStore.Purchase
{
    /// <summary>
    /// Product
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets the sku.
        /// </summary>
        /// <value>
        /// The sku.
        /// </value>
        string SKU { get;  }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get;  }
        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        double Price { get;  }

        // assumption -- product can show associated offers in the UI but not considered in this test
        //public <IOffer> Offers{get;}
    }
}
