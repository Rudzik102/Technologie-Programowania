using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Warehouse.ViewModels
{
    public class DetailModifyCommand : ICommand
    {
        private DetailViewModel viewModel;

        public DetailModifyCommand(DetailViewModel viewModel)
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
            viewModel.Modify();
        }
    }
}
