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
    /// Interaction logic for G_AddNewRecipe_Others.xaml
    /// </summary>
    public partial class G_AddNewRecipe_Others : Page
    {
        List<RecipesBookService.RecipeIngredient> lstri = new List<RecipesBookService.RecipeIngredient>();
        RecipesBookService.Recipes currentRecipe;

        public G_AddNewRecipe_Others()
        {
            InitializeComponent();
        }

        public G_AddNewRecipe_Others(RecipesBookService.Recipes r, List<RecipesBookService.RecipeIngredient> lst) : this()
        {
            currentRecipe = r;
            lstri = lst;
        }
        private void continueButton_Click(object sender, RoutedEventArgs e)
        {// עובר לעמוד הבא 
            try
            {
                if (currentRecipe != null && lstri != null)
                {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new G_AddRecipe_Notes(currentRecipe, lstri));
                }
            }
            catch(Exception ex)
            { }
        }

        //רמת קושי////////////////////
        private void difficultyEasy_Click(object sender, RoutedEventArgs e)
        {//קל
            recipeDifficultyImage.Visibility = Visibility.Visible;
            recipeDifficultyTextBlock.Text = "קל";
            currentRecipe.recipeDifficulty = 1;
        }

        private void difficultyModerate_Click(object sender, RoutedEventArgs e)
        {//בינוני
            recipeDifficultyImage.Visibility = Visibility.Visible;
            recipeDifficultyTextBlock.Text = "בינוני";
            currentRecipe.recipeDifficulty = 2;
        }

        private void difficultyDifficult_Click(object sender, RoutedEventArgs e)
        {//קשה
            recipeDifficultyImage.Visibility = Visibility.Visible;
            recipeDifficultyTextBlock.Text = "קשה";
            currentRecipe.recipeDifficulty = 3;
        }

        //כמות מנות ////////////////////////////
        private void servingsIntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            recipeServingsImage.Visibility = Visibility.Visible;
            try
            {  if(servingsIntegerUpDown.Value!=0)
                recipeServingsTextBlock.Text = servingsIntegerUpDown.Value.ToString();
            currentRecipe.recipeSarvingAmount = servingsIntegerUpDown.Value.Value; }
            catch (Exception ex)
            { }
        }

        //זמן הכנה////////////////////
        private void preparationTimeDateTimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            { if(preparationTimeDateTimePicker.Value!=0)
                recipePreparationImage.Visibility = Visibility.Visible;
            recipePreparationTextBlock.Text = preparationTimeDateTimePicker.Value.ToString();
             currentRecipe.recipePreparationTime = preparationTimeDateTimePicker.Value.Value; }
            catch (Exception ex)
            { }
        }

        //תמונה////////////////////////////
        private void addRecipeImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentRecipe.recipePicture = PicturesFunctions.UploadImage_Dlg();
                if (currentRecipe.recipePicture != null)
                    recipePictureImage.Source = PicturesFunctions.GetImage(currentRecipe.recipePicture);

                if (!(currentRecipe.recipePicture == null || currentRecipe.recipePicture == ""))
                    PicturesFunctions.SendImage(currentRecipe.recipePicture);

            }
            catch (Exception ex)
            { MessageBox.Show("הוספת תמונה לא הצליחה"); }
        }
    }
}
