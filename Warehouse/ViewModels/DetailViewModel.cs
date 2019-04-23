using AdventureWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Warehouse.View;
using Warehouse.Models;
using System.Data.Linq;

namespace Warehouse.ViewModels
{
    public class DetailViewModel
    {
        private Detail window;
        private bool isNew;
        private DataRepository repo;
        public MyProduct product { get; set; }

        public DetailViewModel(MyProduct product, ref Detail window, bool isNew)
        {
            this.product = product;
            this.window = window;
            this.isNew = isNew;

            // Set dates
            product.ModifiedDate = DateTime.Now;
            product.SellStartDate = DateTime.Today;

            ModifyCommand = new DetailModifyCommand(this);
            CancelCommand = new DetailCancelCommand(this);
            repo = new DataRepository();
        }

        public ICommand ModifyCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public void Modify()
        {
            if (isNew)
            {
                // Push back to database
                repo.Add(product);
            }
            else
            {
                // Find and change in database
                repo.Update(product);
            }

            window.Close();
        }

        public void Cancel()
        {
            window.Close();
        }
    }
}
