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

namespace UserClientRecipeEstiGenauer
{
    /// <summary>
    /// Interaction logic for WindowSignInUserClient.xaml
    /// </summary>
    public partial class WindowSignInUserClient : Window
    {
        public WindowSignInUserClient()
        {
            InitializeComponent();
        }



        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            WindowNewSignInUser p = new WindowNewSignInUser();
            
            p.Show();
            this.Close();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (Global.proxy.CheckUsers(EnterEmailTextBox.Text, EnterPassCodeTextBox.Text) == true)

            {
                Global.currentUser = Global.proxy.FindUserByEmail(EnterEmailTextBox.Text);
                WindowHomePage windowHomePage = new WindowHomePage();
                windowHomePage.Show();
                this.Close();
            }
            else
                MessageBox.Show("הנתונים אינם תקינים");
        }

        private void EnterEmailTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (EnterEmailTextBox.Text.Contains("הכנס כתובת דואר אלקטרוני"))
                EnterEmailTextBox.Text = "";
        }
        private void EnterEmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EnterEmailTextBox.Text == "")
                EnterEmailTextBox.Text = "הכנס כתובת דואר אלקטרוני...";
        }

        private void EnterPassCodeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EnterPassCodeTextBox.Text == "")
                EnterPassCodeTextBox.Text = "הכנס קוד...";
        }


        private void EnterPassCodeTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (EnterPassCodeTextBox.Text.Contains("הכנס קוד"))
                EnterPassCodeTextBox.Text = "";
        }
    }
}
