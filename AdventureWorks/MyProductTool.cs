using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks
{
    public static class MyProductTool
    {

        public static List<MyProduct> GetMyProductsByName(string namePart)
        {
            List<MyProduct> my_list = new List<MyProduct>();
            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                IEnumerable<Product> enumerable = from mp in db.Product where mp.Name == namePart select mp;
                foreach(Product p in enumerable)
                {
                    my_list.Add(new MyProduct(p.ProductID, p.Name));
                }
            }
            return my_list;
        }

        public static List<MyProduct> GetMyProductsWithNRecentReviews(int howManyReview)
        {
            List<MyProduct> my_list = new List<MyProduct>();
            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                Table<MyProduct> table = db.GetTable<MyProduct>();
                IQueryable<MyProduct> enumerable = (from mp in table
                                                    orderby mp.ProductReview.ReviewDate descending
                                                    select mp).Take(howManyReview).Distinct();
                my_list = enumerable.ToList();
            }
            return my_list;
        }

        public static List<MyProduct> GetNRecentlyReviewedMyProducts(int howManyReview)
        {
            List<MyProduct> my_list = new List<MyProduct>();
            using (AdventureClassesDataContext db = new AdventureClassesDataContext())
            {
                Table<MyProduct> table = db.GetTable<MyProduct>();
                IQueryable<MyProduct> enumerable = (from mp in table
                                                    orderby mp.ProductReview.ReviewDate descending
                                                    select mp).Distinct().Take(howManyReview);
                my_list = enumerable.ToList();
            }
            return my_list;
        }

    }


}
