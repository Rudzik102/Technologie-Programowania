using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAdventureWorks
{
    [TestClass]
    public class MyProductTest
    {
        [TestMethod]
        public void Test_MyProduct_GetProductsByName()
        {
            List<MyProduct> my_list = MyProductTool.GetMyProductsByName("Blade");
            Assert.AreEqual(1, my_list.Count());
            Assert.AreEqual(316, my_list[0].ProductID);

        }
        [TestMethod]
        public void GetMyProductsWithNRecentReviews()
        {

            List<MyProduct> my_lists = MyProductTool.GetMyProductsWithNRecentReviews(4);
            Assert.AreEqual(3, my_lists.Count());
            Assert.AreEqual("Mountain Bike Socks, M", my_lists[0].Name);
        }

        [TestMethod]
        public void GetNRecentlyReviewedMyProducts()
        {
            List<MyProduct> my_lists = MyProductTool.GetNRecentlyReviewedMyProducts(3);
            Assert.AreEqual(3, my_lists.Count());
            Assert.AreEqual("Mountain Bike Socks, M", my_lists[0].Name);
        }
    }
}
