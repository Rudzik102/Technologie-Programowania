﻿using System;
using System.Windows.Input;

namespace Warehouse.ViewModels
{
    class MasterRemoveItemCommand : ICommand
    {
        private MasterViewModel viewModel;

        public MasterRemoveItemCommand(MasterViewModel viewModel)
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
            viewModel.RemoveItem();
        }
    }
}
