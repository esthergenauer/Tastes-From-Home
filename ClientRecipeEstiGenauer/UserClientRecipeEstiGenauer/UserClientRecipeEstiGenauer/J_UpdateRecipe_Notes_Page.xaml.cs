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
    /// Interaction logic for J_UpdateRecipe_Notes_Page.xaml
    /// </summary>
    public partial class J_UpdateRecipe_Notes_Page : Page
    {
        List<RecipesBookService.RecipeIngredient> lstri = new List<RecipesBookService.RecipeIngredient>();
        RecipesBookService.Recipes currentRecipe;
        public J_UpdateRecipe_Notes_Page()
        {
            InitializeComponent();
        }
        public J_UpdateRecipe_Notes_Page(RecipesBookService.Recipes r, List<RecipesBookService.RecipeIngredient> lst) : this()
        {
            currentRecipe = r;
            lstri = lst;

            notesTextBox.Text = currentRecipe.recipeNotes;


        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {// עובר לעמוד הבא 

            if (!(currentRecipe.recipePicture == null || currentRecipe.recipePicture == ""))
                PicturesFunctions.SendImage(currentRecipe.recipePicture);
            currentRecipe.recipeStatus = true;
            currentRecipe.recipeNotes=notesTextBox.Text;
            Global.proxy.UpdateRecipes(currentRecipe);
            List<RecipesBookService.RecipeIngredient> lstoldri = Global.proxy.GetAllRecipeIngredientByRecipe(currentRecipe);
            foreach (var x in lstoldri)
            { Global.proxy.DeleteCompletelyRecipeIngredient(x); }
            foreach (var x in lstri)
            { Global.proxy.AddNewRecipeIngredient(x); }

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Recipe_Page(currentRecipe));

        }


        private void notesTextBox_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            // כשלוחצים הכתב נעלם 
            if (notesTextBox.Text == "...הקלד כאן... אופציונלי")
                notesTextBox.Text = "";
        }

        private void notesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // אם הכתב ריק הוא חוזר
            if (notesTextBox.Text == "")
                notesTextBox.Text = "...הקלד כאן... אופציונלי";
        }

        private void continueButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void notesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
