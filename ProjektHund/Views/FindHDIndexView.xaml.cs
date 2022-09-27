using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektHund.ViewModels;
using ProjektHund.Views;
using System.Data.SqlClient;
using static ProjektHund.ViewModels.MainViewModels;

namespace ProjektHund.Views
{
    /// <summary>
    /// Interaction logic for FindHDIndexView.xaml
    /// </summary>
    public partial class FindHDIndexView : UserControl
    {
        public FindHDIndexView()
        {
            InitializeComponent();
        }

        private void SearchHDIndex_Click(object sender, RoutedEventArgs e)
        {
                    string ConString = @"Server=localhost\SQLEXPRESS;Database=Hunde;Trusted_Connection=True";
                    SqlConnection cnn = new SqlConnection(ConString);
                    SqlCommand sc;
                    SqlDataReader rd;
            string firstnum = firstNumber.Text;
            string secoundnum = secondNumber.Text;

            string sql = $"SELECT ID,navn,HDindex FROM [dbo].[Grunddata$] WHERE HDindex BETWEEN {firstnum} AND {secoundnum}";
            try
            {
                cnn.Open();
                MessageBox.Show("Connection is active");
                sc = new SqlCommand(sql, cnn);
                rd = sc.ExecuteReader();
                lstView.Items.Clear();
                while (rd.Read())
                {
                    
                    this.lstView.Items.Add(new {ID = rd.GetValue(0), Name = rd.GetValue(1), HDindex = rd.GetValue(2) });

                }

                sc.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
