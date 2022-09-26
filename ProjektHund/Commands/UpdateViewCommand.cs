using ProjektHund.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektHund.Commands
{
    public class UpdateViewCommand : ICommand
    {

        private MainViewModels viewModel;

        public UpdateViewCommand(MainViewModels viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter.ToString() == "FindDog")
            {
                viewModel.SelectedViewModel = new FindDogViewModel();
            }
            else if (parameter.ToString() == "CreateDog")
            {
                viewModel.SelectedViewModel = new CreateDogViewModel();
            }
            else if (parameter.ToString() == "SearchHDIndex")
            {
                viewModel.SelectedViewModel = new FindHDIndexViewModel();
            }
        }
    }
}
