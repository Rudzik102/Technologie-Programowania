using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Warehouse.ViewModels
{
    public class MasterRefreshCommand : ICommand
    {
        private MasterViewModel viewModel;

        public MasterRefreshCommand(MasterViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.RefreshList();
        }
    }
}
