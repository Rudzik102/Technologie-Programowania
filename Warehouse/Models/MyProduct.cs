using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Warehouse.Models;

namespace AdventureWorks
{
    [Table(Name = "Production.Product")]
    public class MyProduct : INotifyPropertyChanged
    {
        private int _ProductID;
        private string _Name;
        private string _ProductNumber;
        private bool _MakeFlag;
        private bool _FinishedGoodsFlag;
        private Int16 _SafetyStockLevel;
        private Int16 _ReorderPoint;
        private Decimal _StandardCost;
        private Decimal _ListPrice;
        private int _DaysToManufacture;
        private DateTime _SellStartDate;
        private Guid _rowguid;
        private DateTime _ModifiedDate;

        public MyProduct()
        {
            MakeFlag = false;
            FinishedGoodsFlag = false;
            ReorderPoint = 750;
            ListPrice = 0;
            DaysToManufacture = 0;
            rowguid = Guid.NewGuid();
            ModifiedDate = DateTime.Now;
        }

        public MyProduct(int ProductID, string Name)
        {
            this.ProductID = ProductID;
            this.Name = Name;
        }

        [Column(Name = "ProductID", IsPrimaryKey = true, Storage = "_ProductID", IsDbGenerated = true)]
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        [Column(Name = "Name", Storage = "_Name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        
        [Column(Name = "ProductNumber", Storage = "_ProductNumber")]
        public string ProductNumber
        {
            get { return _ProductNumber; }
            set { _ProductNumber = value; }
        }

        [Column(Name = "MakeFlag", Storage = "_MakeFlag")]
        public bool MakeFlag
        {
            get { return _MakeFlag; }
            set { _MakeFlag = value; }
        }
        
        [Column(Name = "FinishedGoodsFlag", Storage = "_FinishedGoodsFlag")]
        public bool FinishedGoodsFlag
        {
            get { return _FinishedGoodsFlag; }
            set { _FinishedGoodsFlag = value; }
        }
        
        [Column(Name = "SafetyStockLevel", Storage = "_SafetyStockLevel")]
        public Int16 SafetyStockLevel
        {
            get { return _SafetyStockLevel; }
            set { _SafetyStockLevel = value; }
        }
        
        [Column(Name = "ReorderPoint", Storage = "_ReorderPoint")]
        public Int16 ReorderPoint
        {
            get { return _ReorderPoint; }
            set { _ReorderPoint = value; }
        }
        
        [Column(Name = "StandardCost", Storage = "_StandardCost")]
        public Decimal StandardCost
        {
            get { return _StandardCost; }
            set { _StandardCost = value; }
        }

        [Column(Name = "ListPrice", Storage = "_ListPrice")]
        public Decimal ListPrice
        {
            get { return _ListPrice; }
            set { _ListPrice = value; }
        }
        
        [Column(Name = "DaysToManufacture", Storage = "_DaysToManufacture")]
        public int DaysToManufacture
        {
            get { return _DaysToManufacture; }
            set { _DaysToManufacture = value; }
        }

        [Column(Name = "SellStartDate", Storage = "_SellStartDate")]
        public DateTime SellStartDate
        {
            get { return _SellStartDate; }
            set { _SellStartDate = value; }
        }
        
        [Column(Name = "rowguid", Storage = "_rowguid")]
        public Guid rowguid
        {
            get { return _rowguid; }
            set { _rowguid = value; }
        }
        
        [Column(Name = "ModifiedDate", Storage = "_ModifiedDate")]
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
