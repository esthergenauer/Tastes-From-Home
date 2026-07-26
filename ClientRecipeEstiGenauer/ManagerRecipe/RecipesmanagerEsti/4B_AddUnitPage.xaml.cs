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
    /// Interaction logic for _4B_AddUnitPage.xaml
    /// </summary>
    public partial class _4B_AddUnitPage : Page
    {
        ServiceReference1.Yechidot currentu = new ServiceReference1.Yechidot();
        public _4B_AddUnitPage()
        {
            InitializeComponent();
            this.DataContext = currentu;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateNameTextBox.Text == null || UpdateNameTextBox.Text == "")
                MessageBox.Show("חסר שם יחידת מידה ");
            if (Global.proxy.hasDoubleIngredient(UpdateNameTextBox.Text))
                MessageBox.Show("יחידת מידה זו כבר קיימת");
            else
            {
                currentu.codeYechidot = Global.proxy.GetNextKeyYechidot();
                currentu.statusYechidot = true;
                Global.proxy.AddNewYechidot(currentu);
                MessageBox.Show("יחידת המידה הוספה");
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new _4A_UnitsPage());
            }
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new _4A_UnitsPage());
        }
    }
}
