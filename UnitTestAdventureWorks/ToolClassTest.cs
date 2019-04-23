using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorks;

namespace UnitTestAdventureWorks
{
    [TestClass]
    public class ToolClassTest
    {
        [TestMethod]
        public void Test_ToolClass_GetProductByName()
        {
            List<Product> products = ToolClass.GetProductsByName("Blade");
            Assert.AreEqual(1, products.Count());
        }

        [TestMethod]
        public void Test_ToolClass_GetProductsByVendorName()
        {
            List<Product> products = ToolClass.GetProductsByVendorName("Vision Cycles, Inc.");
            Assert.AreEqual(3, products.Count());
        }

        [TestMethod]
        public void Test_ToolClass_GetProductNamesByVendorName()
        {
            List<string> names = ToolClass.GetProductNamesByVendorName("Vision Cycles, Inc.");
            Assert.AreEqual(3, names.Count());
            Assert.IsTrue(names.Contains("LL Crankarm"));
            Assert.IsTrue(names.Contains("ML Crankarm"));
            Assert.IsTrue(names.Contains("HL Crankarm"));
        }

        [TestMethod]
        public void Test_ToolClass_GetProductVendorByProductName()
        {
            string vendor = ToolClass.GetProductVendorByProductName("LL Crankarm");
            Assert.AreEqual("Proseware, Inc.", vendor);
        }

        [TestMethod]
        public void Test_ToolClass_GetProductsWithNRecentReviews()
        {
            List<Product> products = ToolClass.GetProductsWithNRecentReviews(3);
            Assert.AreEqual(2, products.Count());
        }

        [TestMethod]
        public void Test_ToolClass_GetNRecentlyReviewedProducts()
        {
            List<Product> products = ToolClass.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(3, products.Count());
        }

        [TestMethod]
        public void Test_ToolClass_GetNProductsFromCategory()
        {
            List<Product> products = ToolClass.GetNProductsFromCategory("Bikes", 50);
            Assert.AreEqual(50, products.Count());
            Assert.AreEqual(775, products[0].ProductID);
            Assert.AreEqual(756, products[49].ProductID);
        }

        [TestMethod]
        public void Test_ToolClass_GetTotalStandardCostByCategory()
        {
            ProductCategory category = new ProductCategory();

            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                category = (from c in db.ProductCategory where c.Name == "Clothing" select c).First();
            }

            int cost = ToolClass.GetTotalStandardCostByCategory(category);

            Assert.AreEqual(868, cost);
        }
    }
}
