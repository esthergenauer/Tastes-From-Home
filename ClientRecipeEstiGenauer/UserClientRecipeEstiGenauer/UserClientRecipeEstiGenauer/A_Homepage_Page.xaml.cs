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

namespace UserClientRecipeEstiGenauer
{
    /// <summary>
    /// Interaction logic for A_Homepage_Page.xaml
    /// </summary>
    public partial class A_Homepage_Page : Page
    {//good version
        List<RecipesBookService.Recipes> lst=Global.proxy.GetAllRecipes();
        public A_Homepage_Page()
        {
            InitializeComponent();
        }

        public A_Homepage_Page(int code) : this()
        {

        }

        public void Search()
        {
            

            if (glutanCheckBox.IsChecked == true)
            {
                lst = Global.proxy.GetAllRecipesWithoutGluten(lst);
            }
            if (sesameCheckBox.IsChecked == true)
            {
                lst = Global.proxy.GetAllRecipesWithoutSesame(lst);
            }

            if (milkCheckBox.IsChecked == true)
            {
                lst = Global.proxy.GetAllRecipesWithoutMilk(lst);
            }

            if (nutsCheckBox.IsChecked == true)
            {
                lst = Global.proxy.GetAllRecipesWithoutNuts(lst);
            }

            if (sugarCheckBox.IsChecked == true)
            {
                lst = Global.proxy.GetAllRecipesWithoutSugar(lst);
            }

            if (soyCheckBox.IsChecked == true)
            {
                lst = Global.proxy.GetAllRecipesWithoutSoy(lst);

            }

            if (eggsCheckBox.IsChecked == true)
            {
                lst = Global.proxy.GetAllRecipesWithoutEggs(lst);
            }

            lst = lst.Where(x => x.recipeName.Contains(SearchTextBox.Text)).ToList();

            recipeWrapPanel.Children.Clear();

            foreach (RecipesBookService.Recipes r in lst)
            {
                //recipeWrapPanel.Children.Add(new Recipes_UserControl(r));
                if (Global.proxy.RecipeHasNewMessage(r, Global.currentUser))
                {
                    NewMessageUserControlRecipe nmucr = new NewMessageUserControlRecipe(r);
                    nmucr.Margin = new Thickness(10);
                    nmucr.Height = 250;
                    nmucr.Width = 350;
                    recipeWrapPanel.Children.Add(nmucr);
                }
                else
                {
                    Recipes_UserControl ruc = new Recipes_UserControl(r);
                    ruc.Margin = new Thickness(10);
                    ruc.Height = 250;
                    ruc.Width = 350;
                    recipeWrapPanel.Children.Add(ruc);
                }
            }
            lst = Global.proxy.GetAllRecipes();

        }

        private void SearchTextBox_PreviewMouseDown_2(object sender, MouseButtonEventArgs e)
        {
            aStackPanel.Visibility = Visibility.Visible;
        }

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            aStackPanel.Visibility = Visibility.Collapsed;
        }
       
        private void glutanCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void glutanCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void sesameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void milkCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void nutsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void sugarCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void soyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void eggsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void sesameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void milkCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void nutsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void sugarCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void soyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void eggsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void SearchTextBox_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            aStackPanel.Visibility = Visibility.Visible;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            aStackPanel.Visibility = Visibility.Collapsed;
            Search();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

       
    }
}
