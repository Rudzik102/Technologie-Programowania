using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorks;


namespace UnitTestAdventureWorks
{
    [TestClass]
    public class ExtensionMethodTest
    {
        [TestMethod]
        public void Test_ExtensionMethod_WithoutNullCategoryDeclarative()
        {
            List<Product> products = ToolClass.GetProductsByName("Blade");
            List<Product> filtered = products.WithoutNullCategoryDeclarative();
            Assert.AreEqual(0, filtered.Count());
        }

        [TestMethod]
        public void Test_ExtensionMethod_WithoutNullCategoryImperative()
        {
            List<Product> products = ToolClass.GetProductsByName("Blade");
            List<Product> filtered = products.WithoutNullCategoryImperative();
            Assert.AreEqual(0, filtered.Count());
        }

        [TestMethod]
        public void Test_ExtensionMethod_OnPageDeclarative()
        {
            List<Product> products = ToolClass.GetNProductsFromCategory("Bikes", 97);
            List<Product> paged = products.OnPageDeclarative(5, 2);
            Assert.AreEqual(772, paged[0].ProductID);
            Assert.AreEqual(5, paged.Count());
        }

        [TestMethod]
        public void Test_ExtensionMethod_OnPageImperative()
        {
            List<Product> products = ToolClass.GetNProductsFromCategory("Bikes", 97);
            List<Product> paged = products.OnPageImperative(5, 2);
            Assert.AreEqual(772, paged[0].ProductID);
            Assert.AreEqual(5, paged.Count());
        }

        [TestMethod]
        public void Test_ExtensionMethod_StringProductVendor()
        {
            List<Product> products = ToolClass.GetProductsByName("LL Crankarm");
            string result = products.StringProductVendor();

            Assert.IsTrue(result.Contains("LL Crankarm - Vision Cycles, Inc."));
        }
    }
}
