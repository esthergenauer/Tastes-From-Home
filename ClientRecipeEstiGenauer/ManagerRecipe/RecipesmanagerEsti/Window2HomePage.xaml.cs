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

namespace RecipesmanagerEsti
{
    /// <summary>
    /// Interaction logic for Window2HomePage.xaml
    /// </summary>
    public partial class Window2HomePage : Window
    {
        public Window2HomePage()
        {
            InitializeComponent();
        }
        private void Homepage_Selected(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new _1A_HomePage());
        }

        private void messages_Selected(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new _2A_MessagesPage());
        }

        private void ingredients_Selected(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new _3A_IngredientsPage());
        }

        private void units_Selected(object sender, RoutedEventArgs e)
        {
            this.frm1.Navigate(new _4A_UnitsPage());
        }
    }
}
