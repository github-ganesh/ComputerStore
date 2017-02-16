using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTest.ComputerStore.Package;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingTest.ComputerStore.Purchase;
namespace CodingTest.ComputerStore.Package.Tests
{
    [TestClass()]
    public class FlatDiscountOfferTests
    {
       

        [TestMethod()]
        public void IsValidTrueTest()
        {
            FlatDiscountOffer target = new FlatDiscountOffer("Test","Test", "Testproduct", 2, 100);
            var productOrder = new Moq.Mock<IProductOrder>();
            var product = new Moq.Mock<IProduct>();
            product.SetupGet(x => x.SKU).Returns("Testproduct");
            productOrder.SetupGet(x => x.Product).Returns(product.Object);
            Assert.IsTrue(target.IsValid(productOrder.Object));
        }
        [TestMethod()]
        public void IsValidFalseTest()
        {
            FlatDiscountOffer target = new FlatDiscountOffer("Test", "Test", "Testproduct", 2, 100);
            var productOrder = new Moq.Mock<IProductOrder>();
            var product = new Moq.Mock<IProduct>();
            product.SetupGet(x => x.SKU).Returns("DifferentProduct");
            productOrder.SetupGet(x => x.Product).Returns(product.Object);
            Assert.IsFalse(target.IsValid(productOrder.Object));
        }

        [TestMethod()]
        public void ApplyOfferTest()
        {
            FlatDiscountOffer target = new FlatDiscountOffer("Test", "Test", "Testproduct", 2, 100);
            ProductOrder order = new ProductOrder();
            var product = new Moq.Mock<IProduct>();
            product.SetupGet(x => x.SKU).Returns("Testproduct");
            order.Quantity=2;
            order.Product = product.Object;
            target.ApplyOffer(order, new List<IProductOrder>() { order});
            Assert.AreEqual<double>(order.OfferPrice , (2 * 100));

        }
    }
}
