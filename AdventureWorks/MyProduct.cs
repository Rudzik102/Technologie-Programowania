using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks
{
    [Table(Name = "Production.Product")]
    public class MyProduct
    {

        private int _ProductID;
        private string _Name;
        private EntityRef<ProductReview> _review = new EntityRef<ProductReview>();

        public MyProduct()
        {

        }

        public MyProduct(int id, string name)
        {
            this.ProductID = id;
            this.Name = name;
        }
        [Column(IsPrimaryKey = true, Storage = "_ProductID")]
        public int ProductID
        {
            get
            {
                return this._ProductID; ;
            }
            set
            {
                this._ProductID = value;
            }
        }
        [Column(Storage = "_Name")]
        public string Name
        {
            get
            {
                return this._Name; ;
            }
            set
            {
                this._Name = value;
            }
        }

        [Association(Name = "Product_ProductReview", Storage ="_review",IsForeignKey = true, ThisKey = "ProductID",OtherKey = "ProductID")]
        public ProductReview ProductReview
        {
            get { return _review.Entity; }
            set { _review.Entity = value; }
        }
    }
}







