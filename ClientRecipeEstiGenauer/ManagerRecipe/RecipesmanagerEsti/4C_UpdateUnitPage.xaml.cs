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
    /// Interaction logic for _4C_UpdateUnitPage.xaml
    /// </summary>
    public partial class _4C_UpdateUnitPage : Page
    {
        string oldname;
        ServiceReference1.Yechidot currentu;
        public _4C_UpdateUnitPage()
        {
            InitializeComponent();
        }

        public _4C_UpdateUnitPage(ServiceReference1.Yechidot u):this()
        {
            currentu = u;
            this.DataContext = currentu;
            oldname = currentu.nameYechidot;
        }

        

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new _4A_UnitsPage());
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
            {
            if (UpdateNameTextBox.Text == null || UpdateNameTextBox.Text == "")
                MessageBox.Show("חסר שם יחידה");

            else
            {
                if (Global.proxy.hasDoubleIngredient(UpdateNameTextBox.Text) && oldname != UpdateNameTextBox.Text)
                    MessageBox.Show("יחידה זו כבר קיימת");
                else
                {
                    Global.proxy.UpdateYechidot(currentu);
                    MessageBox.Show("היחידה עודכנה");
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new _4A_UnitsPage());
                }
            }
         }
        
    }
}
