using ProjektHund.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektHund.ViewModels
{
    public class MainViewModels : BaseViewModel
    {
		private BaseViewModel selectedViewModel;

		public BaseViewModel SelectedViewModel
		{
			get { return selectedViewModel; }
			set 
			{ 
				selectedViewModel = value; 
				OnPropertyChanged(nameof(SelectedViewModel));
			}
		}

		public ICommand UpdateViewCommand { get; set; }

		public MainViewModels()
		{
			UpdateViewCommand = new UpdateViewCommand(this);
		}
		private string title = "Welcome To Boxer-Klubben";

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

	}
}
