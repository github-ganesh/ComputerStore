using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTest.ComputerStore.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingTest.ComputerStore.Package;
using CodingTest.ComputerStore.Purchase;
namespace CodingTest.ComputerStore.Client.Tests
{
    [TestClass()]
    public class CheckOutTests
    {

        [TestMethod()]
        public void ScanTestWithoutOffer()
        {
            CheckOut target = new CheckOut(null);
            var product =new Moq.Mock<IProduct>();
            target.Scan(product.Object);
            PrivateObject po = new PrivateObject(target);
            var orders= (IEnumerable<IProductOrder>)po.GetField("orders");
            Assert.IsTrue( orders.Count() == 1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "product object cannot be null")]
        public void ScanTestArgumentNullException()
        {
            CheckOut target = new CheckOut(null);
            target.Scan(null);

        }
        [TestMethod()]
        public void ActualPriceTestWithoutOffer()
        {
            CheckOut target = new CheckOut(null);
            var product = new Moq.Mock<IProduct>();
            product.SetupGet(x => x.Price).Returns(100);
            target.Scan(product.Object);
            Assert.AreEqual(target.ActualPrice() , 100);
        }

        [TestMethod()]
        public void TotalTestWithOffer()
        {
            CheckOut target = new CheckOut( new List<IOffer>()  { new Offer("Test", "Test")});
            var product = new Moq.Mock<IProduct>();
            product.SetupGet(x => x.Price).Returns(100);
            target.Scan(product.Object);
            Assert.IsTrue(target.Total() == 100);
        }
        [TestMethod()]
        public void BuyOneGetManyOfferTest()
        {
            CheckOut target = new CheckOut(new List<IOffer>() { new BuyAndGetManyOffer("BuyOneGetManyTest", "BuyOneGetManyTest", "atv", 2,3 ) });
            Product pro = new Product("atv","Apple Tv", 109.50);
            target.Scan(pro);
            target.Scan(pro);
            target.Scan(pro);
            Assert.AreEqual(target.Total() , (109.50 *2));
        }
        [TestMethod()]
        public void BuyOneGetOtherOfferTest()
        {
            CheckOut target = new CheckOut(new List<IOffer>() { new BuyOneGetOtherOffer("BuyOneGetOtherOffer", "BuyOneGetOtherOffer", "mbp", "hdm") });
            Product pro = new Product("mbp", "MacBook Pro", 1399.99);
            Product pro1 = new Product("hdm", "HDMI Adapter", 30);
            target.Scan(pro);
            target.Scan(pro1);
            Assert.AreEqual(target.Total() , 1399.99);
        }
        [TestMethod()]
        public void BulkDiscountOffterTest()
        {
            CheckOut target = new CheckOut(new List<IOffer>() { new FlatDiscountOffer("FlatDiscountOffer", "FlatDiscountOffer", "nx9", 4, 499.99) });
            Product pro = new Product("nx9", "Nexus 9", 549.99);
            
            target.Scan(pro);
            target.Scan(pro);
            target.Scan(pro);
            target.Scan(pro);
            Assert.AreEqual(target.Total() , (499.99 * 4));
        }

        [TestMethod()]
        public void Example1Test()
        {
            CheckOut target = new CheckOut(new List<IOffer>()
            { new BuyAndGetManyOffer("BuyOneGetManyTest", "BuyOneGetManyTest", "atv", 2,3 ) 
            , new FlatDiscountOffer("FlatDiscountOffer", "FlatDiscountOffer", "nx9", 4, 499.99) 
            ,new BuyOneGetOtherOffer("BuyOneGetOtherOffer", "BuyOneGetOtherOffer", "mbp", "hdm") 
            });
            Product nx9 = new Product("nx9", "Nexus 9", 549.99);
            Product mpb = new Product("mbp", "MacBook Pro", 1399.99);
            Product hdm = new Product("hdm", "HDMI Adapter", 30);
            Product atv = new Product("atv","Apple Tv", 109.50);
            target.Scan(atv);
            target.Scan(atv);
            target.Scan(atv);
            target.Scan(hdm);
            Assert.AreEqual(target.Total() , 249.00);
        }

        [TestMethod()]
        public void Example2Test()
        {
            CheckOut target = new CheckOut(new List<IOffer>()
            { new BuyAndGetManyOffer("BuyOneGetManyTest", "BuyOneGetManyTest", "atv", 2,3 ) 
            , new FlatDiscountOffer("FlatDiscountOffer", "FlatDiscountOffer", "nx9", 4, 499.99) 
            ,new BuyOneGetOtherOffer("BuyOneGetOtherOffer", "BuyOneGetOtherOffer", "mbp", "hdm") 
            });
            Product nx9 = new Product("nx9", "Nexus 9", 549.99);
            Product mpb = new Product("mbp", "MacBook Pro", 1399.99);
            Product hdm = new Product("hdm", "HDMI Adapter", 30);
            Product atv = new Product("atv", "Apple Tv", 109.50);
            target.Scan(atv);
            target.Scan(nx9);
            target.Scan(nx9);
            target.Scan(atv);
            target.Scan(nx9);
            target.Scan(nx9);
            target.Scan(nx9);
            Assert.AreEqual(target.Total() ,2718.95);
        }
        [TestMethod()]
        public void Example3Test()
        {
            CheckOut target = new CheckOut(new List<IOffer>()
            { new BuyAndGetManyOffer("BuyOneGetManyTest", "BuyOneGetManyTest", "atv", 2,3 ) 
            , new FlatDiscountOffer("FlatDiscountOffer", "FlatDiscountOffer", "nx9", 4, 499.99) 
            ,new BuyOneGetOtherOffer("BuyOneGetOtherOffer", "BuyOneGetOtherOffer", "mbp", "hdm") 
            });
            Product nx9 = new Product("nx9", "Nexus 9", 549.99);
            Product mbp = new Product("mbp", "MacBook Pro", 1399.99);
            Product hdm = new Product("hdm", "HDMI Adapter", 30);
            Product atv = new Product("atv", "Apple Tv", 109.50);
            target.Scan(mbp);
            target.Scan(hdm);
            target.Scan(nx9);
          
            Assert.AreEqual(target.Total() , 1949.98);
        }



    }
}
