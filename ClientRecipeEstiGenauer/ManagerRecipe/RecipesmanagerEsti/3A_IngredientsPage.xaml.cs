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
    /// Interaction logic for _3A_IngredientsPage.xaml
    /// </summary>
    public partial class _3A_IngredientsPage : Page
    {
        ServiceReference1.Ingredients currentI;
        public _3A_IngredientsPage()
        {
            InitializeComponent();
            InitializeComponent();
            List<ServiceReference1.Ingredients> lst = Global.proxy.GetAllIngredients();
            lst.Remove(lst.FirstOrDefault(x => x.ingredientsCode == 0));
            ServiceReference1.Ingredients i = lst.FirstOrDefault(x => x.ingredientsCode == 0);
            lst.Remove(i);
            ingredientlst1.ItemsSource = lst;
            ingredientlst1.DataContext =lst;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new _3B_AddIngredientPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var cb = sender as Button;
            var item = cb.DataContext;
            currentI = (ServiceReference1.Ingredients)item;
            if (currentI != null)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new _3C_UpdateIngredientPage(currentI));
            }
        }

        private void deleatebutton_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as Button;
            var item = cb.DataContext;
            currentI = (ServiceReference1.Ingredients)item;

            MessageBoxResult result = MessageBox.Show("למחוק?", "מחיקה", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Global.proxy.DeletePartiallyIngredients(currentI);
                MessageBox.Show("המרכיב נמחק");
                List<ServiceReference1.Ingredients> k = Global.proxy.GetAllIngredients();
               
                k.Remove(k.FirstOrDefault(x => x.ingredientsCode == 0));
                ingredientlst1.ItemsSource = k;
                ingredientlst1.DataContext = k;
            }
        }
    }
}

