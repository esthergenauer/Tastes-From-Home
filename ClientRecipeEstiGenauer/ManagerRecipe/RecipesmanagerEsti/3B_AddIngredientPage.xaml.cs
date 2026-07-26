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
    /// Interaction logic for _3B_AddIngredientPage.xaml
    /// </summary>
    public partial class _3B_AddIngredientPage : Page
    {
        ServiceReference1.Ingredients currenti=new ServiceReference1.Ingredients();
        public _3B_AddIngredientPage()
        {
            InitializeComponent();
            this.DataContext = currenti;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == null || NameTextBox.Text == "")
                MessageBox.Show("חסר שם מרכיב");
            if ( Global.proxy.hasDoubleIngredient(NameTextBox.Text))
                MessageBox.Show("מרכיב זה כבר קיים");
            else
            {
                currenti.ingredientsCode = Global.proxy.GetNextKeyIngredient();
                currenti.ingredientsStatus = true;
                Global.proxy.AddNewIngredients(currenti);
                MessageBox.Show("המרכיב הוסף");
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new _3A_IngredientsPage());
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new _3A_IngredientsPage());
        }
    }
}
