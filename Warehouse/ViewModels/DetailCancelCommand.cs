using System;
using System.Windows.Input;

namespace Warehouse.ViewModels
{
    public class DetailCancelCommand : ICommand
    {
        private DetailViewModel viewModel;

        public DetailCancelCommand(DetailViewModel viewModel)
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
            viewModel.Cancel();
        }
    }
}
