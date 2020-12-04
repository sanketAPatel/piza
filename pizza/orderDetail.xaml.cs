using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using MySql.Data;
using System.Collections;
namespace pizza
{
    /// <summary>
    /// Interaction logic for orderDetail.xaml
    /// </summary>
    public partial class orderDetail : Window
    {
        public orderDetail()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = "datasource=localhost;port= 3306;username=root;password=admin;database=Orders";
            int id = Convert.ToInt32(tbId.Text);
            string querry = "select * from o1 where id='" + id + "'";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(querry, conn);
            command.CommandTimeout = 60;
            conn.Open();
            MySqlDataReader mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                //cbb1.Items.Add(mdr.GetValue(0).ToString());
                //cbb2.Items.Add(mdr.GetValue(1).ToString());
                //cbb3.Items.Add(mdr.GetValue(3).ToString());
                tb1.Text = mdr.GetValue(0).ToString();
                tb2.Text = mdr.GetValue(1).ToString();
                tb3.Text = mdr.GetValue(3).ToString();
                tb4.Text = mdr.GetValue(4).ToString();
                tb5.Text = mdr.GetValue(5).ToString();
                tb6.Text = mdr.GetValue(6).ToString();
                //cbb4.Items.Add(mdr.GetValue(4).ToString());
                //cbb5.Items.Add(mdr.GetValue(5).ToString());
            }
            command.Dispose();
            conn.Close();
        }
    }
}
