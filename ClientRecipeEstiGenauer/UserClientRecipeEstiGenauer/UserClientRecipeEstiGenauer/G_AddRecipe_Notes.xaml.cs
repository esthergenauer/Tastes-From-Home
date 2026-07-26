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
    /// Interaction logic for G_AddRecipe_Notes.xaml
    /// </summary>
    public partial class G_AddRecipe_Notes : Page
    {
        List<RecipesBookService.RecipeIngredient> lstri = new List<RecipesBookService.RecipeIngredient>();
        RecipesBookService.Recipes currentRecipe;
        public G_AddRecipe_Notes()
        {
            InitializeComponent();
        }

        public G_AddRecipe_Notes(RecipesBookService.Recipes r, List<RecipesBookService.RecipeIngredient> lst) : this()
        {
            currentRecipe = r;
            lstri = lst;
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            // כפתור המשך לעמוד הבא
            try
            {
                if (!(currentRecipe.recipePicture == null || currentRecipe.recipePicture == ""))
                    PicturesFunctions.SendImage(currentRecipe.recipePicture);
            }
            catch(Exception ex) { }
            currentRecipe.recipeStatus = true;
            currentRecipe.recipeNotes = notesTextBox.Text;
            try
            {
                Global.proxy.AddNewRecipes(currentRecipe);
                foreach (var x in lstri)
                {
                    x.recipeIngredientCode = Global.proxy.GetNextKeyRecipeIngredient();
                    Global.proxy.AddNewRecipeIngredient(x);
                }

                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Recipe_Page(currentRecipe));
            }
            catch(Exception ex)
            { }

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
    }
}
