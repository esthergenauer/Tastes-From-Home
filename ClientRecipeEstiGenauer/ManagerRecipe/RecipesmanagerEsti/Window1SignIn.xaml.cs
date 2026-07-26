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
using System.Windows.Shapes;

namespace RecipesmanagerEsti
{
    /// <summary>
    /// Interaction logic for Window1SignIn.xaml
    /// </summary>
    public partial class Window1SignIn : Window
    {
        public Window1SignIn()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {




            if (EnterEmailTextBox.Text == "מנהל" && EnterPassCodeTextBox.Text == "12345")

            {

                Window2HomePage windowHomePage = new Window2HomePage();
                windowHomePage.Show();
                this.Close();
            }

            else
                MessageBox.Show("הנתונים אינם תקינים");




        }


        private void EnterEmailTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (EnterEmailTextBox.Text == "...הכנס שם")
                EnterEmailTextBox.Text = "";
        }

        private void EnterEmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EnterEmailTextBox.Text == "")
                EnterEmailTextBox.Text = "...הכנס שם";
        }



        private void EnterPassCodeTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (EnterPassCodeTextBox.Text == "...הכנס קוד")
                EnterPassCodeTextBox.Text = "";
        }

        private void EnterPassCodeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EnterPassCodeTextBox.Text == "")
                EnterPassCodeTextBox.Text = "...הכנס קוד";
        }






    }
}
