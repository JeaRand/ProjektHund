using ProjektHund.Commands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
using ProjektHund.Views;

namespace ProjektHund.ViewModels
{
    public class MainViewModels : BaseViewModel
    {
        FindHDIndexView hdview = new FindHDIndexView();
        private BaseViewModel selectedViewModel;
        static String connectionString = @"Server=localhost\SQLEXPRESS;Database=Hunde;Trusted_Connection=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        SqlDataReader reader;

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

        private string question = "Enter Name:";

        public string Question
        {
            get { return question; }
            set { question = value; }
        }


        private string enterName = "Enter Dog Name:";

        public string EnterName
        {
            get { return enterName; }
            set { enterName = value; }
        }

        public class Dogs
        {
            public string navn { get; set; }
            public string HDindex { get; set; }

        }
    }
}
