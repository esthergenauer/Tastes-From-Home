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
    /// Interaction logic for WindowHomePage.xaml
    /// </summary>
    public partial class WindowHomePage : Window
    {
        public WindowHomePage()
        {
            InitializeComponent();
        }


        private void Homepage_Selected(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new A_Homepage_Page());
        }

        private void AccountSettings_Selected(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new B_AccountSettings_Page());
        }

        private void AllRecipes_Selected(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new C_AllRecipes_Page());
        }

        private void FavoriteRecipes_Selected(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new D_FavriteRecipes_Page());
        }

        private void MyRecipes_Selected(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new E_MyRecipes_Page());
        }

        private void NewMessages_Selected(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new F_NewMessages_Page());
        }

        private void AddNewRecipe_Selected_1(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new G_AddNewRecipe_Page());
        }
    }
}
