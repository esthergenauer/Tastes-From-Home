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
    /// Interaction logic for NewMessageUserControlRecipe.xaml
    /// </summary>
    public partial class NewMessageUserControlRecipe : UserControl
    {
        RecipesBookService.Recipes currentRecipe;
        public NewMessageUserControlRecipe()
        {
            InitializeComponent();
        }
        public NewMessageUserControlRecipe(RecipesBookService.Recipes r) : this()
        {
            currentRecipe = r;
            this.DataContext = currentRecipe;
            try
            {
                if (!(currentRecipe.recipePicture == "" || currentRecipe.recipePicture == null))
                    recipeImage.Source = PicturesFunctions.GetImage(currentRecipe.recipePicture);
            }
            catch (Exception ex)
            { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Recipe_Page(currentRecipe));

        }
    }
}
