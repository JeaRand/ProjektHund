using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

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
                    string ConString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Hunde;Integrated Security=True";
                    SqlConnection cnn = new SqlConnection(ConString);
                    SqlCommand sc;
                    SqlDataReader rd;
            //ViewModel
            string firstnum = firstNumber.Text;
            string secoundnum = secondNumber.Text;
            //Model
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
                    //ViewModel
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
