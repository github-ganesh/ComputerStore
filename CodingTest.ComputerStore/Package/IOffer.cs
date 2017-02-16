using CodingTest.ComputerStore.Purchase;
using System;
using System.Collections.Generic;
namespace CodingTest.ComputerStore.Package
{
    /// <summary>
    /// Product offer
    /// </summary>
    public interface IOffer
    {
        /// <summary>
        /// Applies the offer.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="orders">The orders.</param>
        void ApplyOffer(IProductOrder order, List<IProductOrder> orders);
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; }
        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        int Priority { get;  }
        /// <summary>
        /// Validates the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        bool IsValid(IProductOrder order);
    }
}
