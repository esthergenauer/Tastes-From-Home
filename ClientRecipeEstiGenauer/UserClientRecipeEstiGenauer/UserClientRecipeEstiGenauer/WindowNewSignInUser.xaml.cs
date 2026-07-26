using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for WindowNewSignInUser.xaml
    /// </summary>
    
    public partial class WindowNewSignInUser : Window
    {
        //WindowNewSignInUser

        RecipesBookService.WebUser w = new RecipesBookService.WebUser();
        public WindowNewSignInUser()
        {
            InitializeComponent();
        }

        private void NameButton_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameTextBox.ToolTip = "";
            NameTextBox.BorderBrush = new SolidColorBrush(Global.colorDarkBrown);
        }

        private void EnterNewSignInButton_Click(object sender, RoutedEventArgs e)
        {
            bool hasErrors = false;
            if (Tekinot.TekinutRules.ValidEmail(EmailAddressTextBox.Text) == false || Tekinot.TekinutRules.ValidPassword(PassCodeTextBox.Text) == false)
                hasErrors = true;  
            bool isDouble = false;

            if (Global.proxy.FindUserByEmail(EmailAddressTextBox.Text) != null)//בדיקה האם יש כפילות
                isDouble = true;

            if (hasErrors || isDouble || NameTextBox.Text == "" || EmailAddressTextBox.Text == "" || PassCodeTextBox.Text == "" || EmailAddressTextBox.Text.Contains( "הכנס כתובת דואר אלקטרוני")||NameTextBox.Text.Contains("הכנס שם משתמש") || PassCodeTextBox.Text.Contains("הכנס קוד"))
            {
                if (hasErrors || EmailAddressTextBox.Text == "" || PassCodeTextBox.Text == "" || Validation.GetHasError(PassCodeTextBox)|| EmailAddressTextBox.Text.Contains( "הכנס כתובת דואר אלקטרוני")||NameTextBox.Text.Contains("הכנס שם משתמש") || PassCodeTextBox.Text.Contains("הכנס קוד"))
                {
                    MessageBox.Show("חסר נתונים או נתונים לא תקינים");
                }

                if (isDouble == true)
                {
                    MessageBox.Show("משתמש זה כבר קיים במערכת");
                }

                //Check Name
                //בדיקת שהשם אינו ריק או שלא מילאו את השם 

                if (NameTextBox.Text == ""|| NameTextBox.Text.Contains("הכנס שם משתמש") )
                {
                    NameTextBox.ToolTip = "הכנס שם משתמש";

                    NameTextBox.BorderBrush = Brushes.Red;
                }

                // Check Email Address
                // בדיקה שהכתובת איימיל אינו ריק או שלא מילאו את הכתובת אימיל

                if (EmailAddressTextBox.Text == ""|| EmailAddressTextBox.Text.Contains("הכנס כתובת דואר אלקטרוני"))
                {
                    EmailAddressTextBox.ToolTip = "הכנס כתובת דואל אלקטרוני ";

                    EmailAddressTextBox.BorderBrush = Brushes.Red;
                }

                // בדיקה שהאיימיל תקין על פי הכללים

                if (Tekinot.TekinutRules.ValidEmail(EmailAddressTextBox.Text))
                {
                    EmailAddressTextBox.ToolTip = "כתובת איימיל לא תקין  ";

                    EmailAddressTextBox.BorderBrush = Brushes.Red;
                }
                if (Tekinot.TekinutRules.ValidPassword(PassCodeTextBox.Text))
                {
                    PassCodeTextBox.ToolTip = "סיסמא לא תקינה  ";

                    PassCodeTextBox.BorderBrush = Brushes.Red;
                }

                // Check PassCode
                // בדיקה שהקוד אינו ריק או שלא מילאו את הקוד

                if (PassCodeTextBox.Text == "" || PassCodeTextBox.Text.Contains("הכנס קוד"))
                {
                    PassCodeTextBox.ToolTip = "הכנס קוד";

                    PassCodeTextBox.BorderBrush = Brushes.Red;
                }

                // בדיקה שהקוד תקין על פי הכללים

                if (Validation.GetHasError(PassCodeTextBox))
                {
                    PassCodeTextBox.ToolTip = "קוד לא תקין";

                    PassCodeTextBox.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                try
                {
                    w.userCode = Global.proxy.GetNextKeyUsers();
                    w.userName = NameTextBox.Text;
                    w.userEmail = EmailAddressTextBox.Text;
                    w.userPasscode = PassCodeTextBox.Text;
                    w.userStatus = true;
                    Global.proxy.AddNewUsers(w);
                    Global.currentUser = w;
                    MessageBox.Show("הוסף בהצלחה");
                    WindowHomePage windowHomePage = new WindowHomePage();
                    windowHomePage.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        // EmailAddressTextBox____________
        private void EmailAddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmailAddressTextBox.BorderBrush = new SolidColorBrush(Global.colorDarkBrown);
            EmailAddressTextBox.ToolTip = "";
        }

        private void EmailAddressTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (EmailAddressTextBox.Text.Contains("הכנס כתובת דואר אלקטרוני"))
                EmailAddressTextBox.Text = "";
        }

        // NameTextBox.Text.Contains
        private void EmailAddressTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EmailAddressTextBox.Text == "")
                EmailAddressTextBox.Text = "...הכנס כתובת דואר אלקטרוני";
            else
            {
                string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(EmailAddressTextBox.Text))
                {
                    EmailAddressTextBox.BorderBrush = Brushes.Red; ;
                    EmailAddressTextBox.ToolTip = "כתובת הדואר אלקטרוני אינה תקינה";
                }
            }
        }


        // PassCodeTextBox____________
        private void PassCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PassCodeTextBox.BorderBrush = new SolidColorBrush(Global.colorDarkBrown);
            PassCodeTextBox.ToolTip = "";
        }

        private void PassCodeTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PassCodeTextBox.Text.Contains("הכנס קוד"))
                PassCodeTextBox.Text = "";
        }

        private void PassCodeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PassCodeTextBox.Text == "")
                PassCodeTextBox.Text = "הכנס קוד...";

            else
            {
                string s = PassCodeTextBox.Text;

                if (s.Length < 3)
                {
                    PassCodeTextBox.BorderBrush = Brushes.Red; ;
                    PassCodeTextBox.ToolTip = "הקוד חייב להכיל לפחות 3 תווים";
                    
                }
                if (s.Length < 3)
                {
                    PassCodeTextBox.BorderBrush = Brushes.Red; ;
                    PassCodeTextBox.ToolTip = "הקוד חייב להכיל לפחות 3 תווים";
                }
                
                if(!s.Contains('0') && !s.Contains('1') && !s.Contains('2') && !s.Contains('3') && !s.Contains('4') && !s.Contains('5') && !s.Contains('6') && !s.Contains('7') && !s.Contains('8') && !s.Contains('9'))
                {
                    PassCodeTextBox.BorderBrush = Brushes.Red; ;
                    PassCodeTextBox.ToolTip = "הקוד חייב להכיל לפחות מספר אחד";
                }
            }
        }

        //NameTextBox__________
        private void NameTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (NameTextBox.Text.Contains("הכנס שם משתמש"))
                NameTextBox.Text = "";
        }

        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "")
                NameTextBox.Text = "הכנס שם משתמש...";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowSignInUserClient w = new WindowSignInUserClient();
            w.Show();
            this.Close();
            //
        }

        private void EnterNewSignInButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
