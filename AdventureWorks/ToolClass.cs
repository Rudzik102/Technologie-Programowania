using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorks
{
    public static class ToolClass
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            List<Product> products = new List<Product>();

            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                IQueryable<Product> query = from p in db.Product
                                            where p.Name == namePart
                                            select p;
                products = query.ToList();
            }

            return products;
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            List<Product> products = new List<Product>();

            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                IQueryable<Product> query = from p in db.Product
                                            from v in db.Vendor
                                            from pv in db.ProductVendor
                                            where pv.ProductID == p.ProductID &&
                                                  pv.BusinessEntityID == v.BusinessEntityID &&
                                                  v.Name == vendorName
                                            select p;
                products = query.ToList();
            }

            return products;
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            List<string> names = new List<string>();

            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                IQueryable<string> query = from p in db.Product
                                           from v in db.Vendor
                                           from pv in db.ProductVendor
                                           where pv.ProductID == p.ProductID &&
                                                 pv.BusinessEntityID == v.BusinessEntityID &&
                                                 v.Name == vendorName
                                           orderby p.Name
                                           select p.Name;
                names = query.ToList();
            }

            return names;
        }

        public static string GetProductVendorByProductName(string productName)
        {
            string vendor = "";

            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                IEnumerable<string> query = from p in db.Product
                                            from v in db.Vendor
                                            from pv in db.ProductVendor
                                            where pv.ProductID == p.ProductID &&
                                                  pv.BusinessEntityID == v.BusinessEntityID &&
                                                  p.Name == productName
                                            orderby v.Name ascending
                                            select v.Name;
                vendor = query.First().ToString();
            }

            return vendor;
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReview)
        {
            List<Product> products = new List<Product>();

            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                IQueryable<Product> query = (from p in db.Product
                                             from pr in db.ProductReview
                                             where p.ProductID == pr.ProductID
                                             orderby pr.ReviewDate descending
                                             select p).Take(howManyReview).Distinct();
                products = query.ToList();
            }

            return products;
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            List<Product> products = new List<Product>();

            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                IQueryable<Product> query = (from p in db.Product
                                             from pr in db.ProductReview
                                             where p.ProductID == pr.ProductID
                                             orderby pr.ReviewDate descending
                                             select p).Distinct().Take(howManyProducts);
                products = query.ToList();

            }

            return products;
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            List<Product> products = new List<Product>();

            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                IQueryable<Product> query = (from p in db.Product
                                             from ps in db.ProductSubcategory
                                             from pc in db.ProductCategory
                                             where p.ProductSubcategoryID == ps.ProductSubcategoryID &&
                                                   pc.ProductCategoryID == ps.ProductCategoryID &&
                                                   pc.Name == categoryName
                                             orderby pc.Name, p.Name ascending
                                             select p).Take(n);
                products = query.ToList();

            }

            return products;
        }
        
        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            int cost = 0;

            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                cost = Convert.ToInt32((from p in db.Product
                                        from ps in db.ProductSubcategory
                                        from pc in db.ProductCategory
                                        where p.ProductSubcategoryID == ps.ProductSubcategoryID &&
                                              pc.ProductCategoryID == ps.ProductCategoryID &&
                                              pc == category
                                        orderby ps.Name, p.Name ascending
                                        select p.StandardCost).Sum());
            }

            return cost;
        }
    }
}
