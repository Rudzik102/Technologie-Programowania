using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorks
{
    public static class ExtensionMethod
    {
        public static List<Product> WithoutNullCategoryDeclarative(this List<Product> list)
        {
            List<Product> products = (from p in list
                                      where p.ProductSubcategoryID != null
                                      select p).ToList();

            return products;
        }

        public static List<Product> WithoutNullCategoryImperative(this List<Product> list)
        {
            List<Product> products = new List<Product>();

            foreach (Product p in list)
            {
                if (p.ProductSubcategoryID != null)
                {
                    products.Add(p);
                }
            }

            return products;
        }

        public static List<Product> OnPageDeclarative(this List<Product> list, int elements, int page)
        {
            List<Product> products = (from p in list
                                      select p).Skip(elements * (page - 1)).Take(elements).ToList();

            return products;
        }

        public static List<Product> OnPageImperative(this List<Product> list, int elements, int page)
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < list.Count(); i++)
            {
                if (i > (elements * (page - 1) - 1) && i <= (elements * page - 1))
                {
                    products.Add(list[i]);
                }
            }

            return products;
        }

        public static string StringProductVendor(this List<Product> list)
        {
            string text = "";

            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                var result = from p in list
                             from v in db.Vendor
                             from pv in db.ProductVendor
                             where p.ProductID == pv.ProductID &&
                                   v.BusinessEntityID == pv.BusinessEntityID
                             select new { Product = p.Name, Vendor = v.Name };

                foreach (var r in result)
                {
                    text += r.Product.ToString() + " - " + r.Vendor.ToString() + "\n";
                }
            }

            return text;
        }
    }
}
