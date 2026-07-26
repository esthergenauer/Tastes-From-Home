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
    /// Interaction logic for _2A_MessagesPage.xaml
    /// </summary>
    public partial class _2A_MessagesPage : Page
    {
        ServiceReference1.RecipeMessages currentm;


        public _2A_MessagesPage()
        {
            InitializeComponent();
            messagelst1.ItemsSource = Global.proxy.GetAllRecipeMessages();
            messagelst1.DataContext = Global.proxy.GetAllRecipeMessages();

        }

        private void deleatebutton_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as Button;
            var item = cb.DataContext;
            currentm = (ServiceReference1.RecipeMessages)item;
            
            MessageBoxResult result = MessageBox.Show("למחוק?", "מחיקה", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                    Global.proxy.DeleteCompletelyRecipeMessages(currentm);
                    MessageBox.Show("ההודעה נמחק");
                    List<ServiceReference1.RecipeMessages> k = Global.proxy.GetAllRecipeMessages();
                    messagelst1.ItemsSource = k;
                    messagelst1.DataContext = k;
            }
            

        }
    }
}
