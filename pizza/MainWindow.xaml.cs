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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double sizePrize = 0.00;
        double crustPrize = 0.0;
        double toppingPrize = 0.0;
        int toppingSelected = 0;
        double sidePrize = 0.0;
        double totalPrize = 0.0;
        double taxAmount = 0.0;
        double grandTotal = 0.00;
        string size = "";
        string crust = "";
        double total = 0.0;
        string toppings = "";
        string extras = "";
        int id = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        /*radiobutton for  size 
         **param @ double sizePrize
         */
        private void rdbtnsm_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbtnsm.IsChecked == true)
            {
                sizePrize = 5.00;
                size = "small";
            }
            lblTotal.Content = findTotal();
        }

        /*radiobutton for  size 
         **param @ double sizePrize
         */
        private void rdbtnmed_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbtnmed.IsChecked == true)
            {
                sizePrize = 8.0;
                size = "Med";
            }
            lblTotal.Content = findTotal();
        }

        /*radiobutton for  size 
         **param @ double sizePrize
         */
        private void rdbtnlarge_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbtnlarge.IsChecked == true)
            {
                sizePrize = 10.0;
                size = "Large";
            }
            lblTotal.Content = findTotal();
        }

        /*radiobutton for  crust 
         **param @ double crustPrize
         */
        private void rdbtnthick_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbtnthick.IsChecked == true)
            {
                crustPrize = 1.00;
                crust = "Thick";
            }
            lblTotal.Content = findTotal();
        }

        /*radiobutton for  crust 
         **param @ double crustPrize
         */
        private void rdbtnthin_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbtnthin.IsChecked == true)
            {
                crustPrize = 2.00;
                crust = "Thin";
            }
            lblTotal.Content = findTotal();
        }

        /*checkbox for  toppings
         **param @ double toppintPrize
         */
        private void cbOnion_Checked(object sender, RoutedEventArgs e)
        {
            if (cbOnion.IsChecked == true)
            {
                toppingSelected++;
                if (toppingSelected > 3)
                {
                    toppingPrize += 1.0;
                }
                toppings = string.Concat(toppings, "onion, ");
            }
            else
            {
                toppingPrize = toppingPrize - 1.0;
                toppings = toppings.Replace("onion, ", "");
            }
            lblTotal.Content = findTotal();
        }

        /*checkbox for  toppings
         **param @ double toppintPrize
         */
        private void cbMushroom_Checked(object sender, RoutedEventArgs e)
        {
            if (cbMushroom.IsChecked == true)
            {
                toppingSelected++;
                if (toppingSelected > 3)
                {
                    toppingPrize += 1.0;
                }
                toppings = string.Concat(toppings, "mshrom, ");
            }
            else
            {
                toppingPrize = toppingPrize - 1.0;
                toppings = toppings.Replace("mshrom, ", "");
            }
            lblTotal.Content = findTotal();
        }

        /*checkbox for  toppings
         **param @ double toppintPrize
         */
        private void cbOlives_Checked(object sender, RoutedEventArgs e)
        {
            if (cbOlives.IsChecked == true)
            {
                toppingSelected++;
                if (toppingSelected > 3)
                {
                    toppingPrize += 1.0;
                }
                toppings = string.Concat(toppings, "olives, ");
            }
            else
            {
                toppingPrize = toppingPrize - 1.0;
                toppings = toppings.Replace("olives, ", "");
            }
            lblTotal.Content = findTotal();
        }

        /*checkbox for  toppings
         **param @ double toppintPrize
         */
        private void cbPineapple_Checked(object sender, RoutedEventArgs e)
        {
            if (cbPineapple.IsChecked == true)
            {
                toppingSelected++;
                if (toppingSelected > 3)
                {
                    toppingPrize += 1.0;
                }
                toppings = string.Concat(toppings, "pineple, ");
            }
            else
            {
                toppingPrize = toppingPrize - 1.0;
                toppings = toppings.Replace("pineple, ", "");
            }
            lblTotal.Content = findTotal();
        }

        /*checkbox for toppings
         **param @ double toppintPrize
         */
        private void cbPepper_Checked(object sender, RoutedEventArgs e)
        {
            if (cbPepper.IsChecked == true)
            {
                toppingSelected++;
                if (toppingSelected > 3)
                {
                    toppingPrize += 1.0;
                }
                toppings = string.Concat(toppings, "pepper, ");
            }
            else
            {
                toppingPrize = toppingPrize - 1.0;
                toppings = toppings.Replace("pepper, ", "");
            }
            lblTotal.Content = findTotal();
        }

        /*checkbox for side selection
         **param @ double sideprize
         */
        private void cbDipping_Checked(object sender, RoutedEventArgs e)
        {
            if (cbDipping.IsChecked == true)
            {
                sidePrize += 1.0;
                extras = string.Concat(extras, "dipping, ");
            }
            else
            {
                sidePrize -= 1.0;
                extras = extras.Replace("dipping, ", "");
            }
            lblTotal.Content = findTotal();
        }

        /*checkbox for side selection
         **param @ double sideprize
         */
        private void cbChknWng_Checked(object sender, RoutedEventArgs e)
        {
            if (cbChknWng.IsChecked == true)
            {
                sidePrize += 5.0;
                extras = string.Concat(extras, "chknwing, ");
            }
            else
            {
                sidePrize -= 5.0;
                extras = extras.Replace("chknwing, ", "");
            }
            lblTotal.Content = findTotal();
        }

        /*checkbox for side selection
         **param @ double sideprize
         */
        private void cbPop_Checked(object sender, RoutedEventArgs e)
        {
            if (cbPop.IsChecked == true)
            {
                sidePrize += 1.0;
                extras = string.Concat(extras, "pop, ");
            }
            else
            {
                sidePrize -= 1.0;
                extras = extras.Replace("pop, ", "");
            }
            lblTotal.Content = findTotal();
        }

        /*checkbox for side selection
         **param @ double sideprize
         */
        private void cbBrownie_Checked(object sender, RoutedEventArgs e)
        {
            if (cbBrownie.IsChecked == true)
            {
                sidePrize = 5.0;
                extras = string.Concat(extras, "Brownie, ");
            }
            else
            {
                sidePrize -= 5.0;
                extras = extras.Replace("Brownie, ", "");
            }
            lblTotal.Content = findTotal();
        }

        /*This method will find the total*/
        public double findTotal()
        {
            totalPrize = sizePrize + crustPrize + toppingPrize + sidePrize;
            taxAmount = 0.13 * (totalPrize);
            grandTotal = totalPrize + taxAmount;
            lblTax.Content = taxAmount;
            lblTp.Content = grandTotal;
            total = grandTotal;
            return totalPrize;
        }

        /* Social media Button*/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/pages/category/Pizza-Place/Pizza-Pizza-349301015552294/");
        }
        /* Social media Button*/
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/pizzapizzaltd/?hl=en");
        }

        /*Database record saving 
         * 
         */
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            string connectionString = "datasource=localhost;port= 3306;username=root;password=admin;database=Orders";
            string querry = "INSERT INTO o1(`id`,`size`,`crust`,`toppings`,`extras`,`total`)" +
            "VALUES('" + id + "','" + size + "','" + crust + "','" + toppings + "','" + extras + "','" + total + "')";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(querry, conn);
            command.CommandTimeout = 60;
            conn.Open();
            MySqlDataReader mdr = command.ExecuteReader();
            lblMsg.Content = "Order Saved!!";
            conn.Close();
        }

        /* This will close an application*/
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            orderDetail od = new orderDetail();
            od.Show();
        }
    }
}

