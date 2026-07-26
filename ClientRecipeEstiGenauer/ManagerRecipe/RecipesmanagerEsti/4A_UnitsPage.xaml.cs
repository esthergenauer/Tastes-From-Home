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
    /// Interaction logic for _4A_UnitsPage.xaml
    /// </summary>
    public partial class _4A_UnitsPage : Page
    {
        ServiceReference1.Yechidot currentu;
        public _4A_UnitsPage()
        {
            
            InitializeComponent();

            List<ServiceReference1.Yechidot> lst = Global.proxy.GetAllYechidot();
            ServiceReference1.Yechidot i = lst.FirstOrDefault(x => x.codeYechidot == 0);
            lst.Remove(i);
            unitslst1.ItemsSource = lst;
            unitslst1.DataContext = lst;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new _4B_AddUnitPage());
        }


        private void update_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as Button;
            var item = cb.DataContext;
            currentu = (ServiceReference1.Yechidot)item;
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new _4C_UpdateUnitPage(currentu));
        }
        
        private void deleatebutton_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as Button;
            var item = cb.DataContext;
            currentu = (ServiceReference1.Yechidot)item;

            MessageBoxResult result = MessageBox.Show("למחוק?", "מחיקה", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Global.proxy.DeletePartiallyYechidot(currentu);
                MessageBox.Show("יחידת המידה נמחקה");
                List<ServiceReference1.Yechidot> k = Global.proxy.GetAllYechidot();
                unitslst1.ItemsSource = k;
                unitslst1.DataContext = k;
            }
        }


    }
}
