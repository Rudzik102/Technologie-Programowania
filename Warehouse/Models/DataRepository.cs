using AdventureWorks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    class DataRepository
    {

        public DataContext context;

        public DataRepository()
        {
            context = new DataContext();
        }

        public void Update(MyProduct product)
        {
            // Find and delete
            MyProduct query = (from mp in context.db.GetTable<MyProduct>()
                               where mp.ProductID == product.ProductID
                               select mp).FirstOrDefault();

            if (query != null)
            {
                context.db.GetTable<MyProduct>().DeleteOnSubmit(query);
            }

            // Add changed product
            context.db.GetTable<MyProduct>().InsertOnSubmit(product);
            context.db.SubmitChanges();
        }

        public void Add(MyProduct product)
        {
            context.db.GetTable<MyProduct>().InsertOnSubmit(product);
            context.db.SubmitChanges();
        }

        public void Refresh(ref ObservableCollection<MyProduct> _products)
        {
            _products.Clear();
            List<MyProduct> temp = context.db.GetTable<MyProduct>().ToList();
            foreach (MyProduct mp in temp)
            {
                _products.Add(mp);
            }
        }


        public void Remove(int rem_id)
        {
            MyProduct query = (from mp in context.db.GetTable<MyProduct>()
                               where mp.ProductID == rem_id
                               select mp).FirstOrDefault();

            if (query != null)
            {
                context.db.GetTable<MyProduct>().DeleteOnSubmit(query);
            }

            context.db.SubmitChanges();
        }
    }
}
