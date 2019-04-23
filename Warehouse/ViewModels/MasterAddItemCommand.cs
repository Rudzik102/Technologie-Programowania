using System;
using System.Windows.Input;

namespace Warehouse.ViewModels
{
    public class MasterAddItemCommand : ICommand
    {
        private MasterViewModel viewModel;

        public MasterAddItemCommand(MasterViewModel viewModel)
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
            viewModel.AddItem();
        }
    }
}
