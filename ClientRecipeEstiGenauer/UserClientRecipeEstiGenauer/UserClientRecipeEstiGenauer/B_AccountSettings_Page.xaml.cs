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

namespace UserClientRecipeEstiGenauer
{
    /// <summary>
    /// Interaction logic for B_AccountSettings_Page.xaml
    /// </summary>
    public partial class B_AccountSettings_Page : Page
    {
        RecipesBookService.WebUser w = new RecipesBookService.WebUser();
        public B_AccountSettings_Page()
        {
            InitializeComponent();
            w.userCode = Global.currentUser.userCode;
            w.userEmail = Global.currentUser.userEmail;
            w.userName = Global.currentUser.userName;
            w.userPasscode = Global.currentUser.userPasscode;
            w.userStatus = Global.currentUser.userStatus;
            this.DataContext = w;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool hasErrors = Validation.GetHasError(UpdatePassCodeTextBox);//בדיקה האם יש שגיאה בנתונים-בקוד החדש

            // PassCodeTextBox.Text.Contains("הכנס קוד")

            if (hasErrors || UpdateNameTextBox.Text == "" || UpdatePassCodeTextBox.Text == "")
            {
                if (hasErrors || UpdatePassCodeTextBox.Text == "" || Validation.GetHasError(UpdatePassCodeTextBox) || UpdateNameTextBox.Text.Contains("הכנס שם משתמש") || UpdatePassCodeTextBox.Text.Contains("הכנס קוד"))
                {
                    MessageBox.Show("חסר נתונים או נתונים לא תקינים");
                }


                //Check Name
                //בדיקת שהשם אינו ריק או שלא מילאו את השם 

                if (UpdateNameTextBox.Text == "" || UpdateNameTextBox.Text.Contains("הכנס שם משתמש"))
                {
                    UpdateNameTextBox.ToolTip = "הכנס שם משתמש";

                    UpdateNameTextBox.BorderBrush = Brushes.Red;
                }


                // Check PassCode
                // בדיקה שהקוד אינו ריק או שלא מילאו את הקוד

                if (UpdatePassCodeTextBox.Text == "" || UpdatePassCodeTextBox.Text.Contains("הכנס קוד"))
                {
                    UpdatePassCodeTextBox.ToolTip = "הכנס קוד";

                    UpdatePassCodeTextBox.BorderBrush = Brushes.Red;
                }

                // בדיקה שהקוד תקין על פי הכללים

                if (Validation.GetHasError(UpdatePassCodeTextBox))
                {
                    UpdatePassCodeTextBox.ToolTip = "קוד לא תקין";

                    UpdatePassCodeTextBox.BorderBrush = Brushes.Red;
                }

            }
            else
            {
                try
                {


                    Global.proxy.UpdateUsers(w);
                    Global.currentUser = w;
                    MessageBox.Show("עודכן בהצלחה");

                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new A_Homepage_Page());


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
        }


        private void UpdatePassCodeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UpdatePassCodeTextBox.Text == "")
            {
                UpdatePassCodeTextBox.Text = Global.currentUser.userPasscode;

            }

        }

        private void UpdatePassCodeTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (UpdatePassCodeTextBox.Text == Global.currentUser.userPasscode)
            {
                UpdatePassCodeTextBox.Text = "";
            }


        }


        private void UpdateNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UpdateNameTextBox.Text == "")
            {
                UpdateNameTextBox.Text = Global.currentUser.userName;
            }
        }


        private void UpdateNameTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (UpdateNameTextBox.Text == Global.currentUser.userName)
            {
                UpdateNameTextBox.Text = "";
            }
        }



        private void UpdateNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdatePassCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}