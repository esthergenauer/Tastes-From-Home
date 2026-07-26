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

namespace RecipesmanagerEsti
{
    /// <summary>
    /// Interaction logic for _3C_UpdateIngredientPage.xaml
    /// </summary>
    public partial class _3C_UpdateIngredientPage : Page
    {string oldname;
        ServiceReference1.Ingredients currenti;
        public _3C_UpdateIngredientPage()
        {
            InitializeComponent();
        }
        public _3C_UpdateIngredientPage(ServiceReference1.Ingredients i):this()
        {
            currenti = i;
            oldname = i.ingredientName;
            this.DataContext = i;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new _3A_IngredientsPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateNameTextBox.Text == null || UpdateNameTextBox.Text == "")
                MessageBox.Show("חסר שם מרכיב");
            else
            {
                if (Global.proxy.hasDoubleIngredient(UpdateNameTextBox.Text) && oldname != UpdateNameTextBox.Text)
                    MessageBox.Show("מרכיב זה כבר קיים");
                else
                {
                  
                    Global.proxy.UpdateIngredients(currenti);
                    MessageBox.Show("המרכיב עודכן");
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new _3A_IngredientsPage());
                }
            }
        }
    }
}
