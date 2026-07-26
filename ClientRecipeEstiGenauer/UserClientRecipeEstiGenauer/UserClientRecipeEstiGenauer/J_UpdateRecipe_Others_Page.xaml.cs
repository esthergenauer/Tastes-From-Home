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
    /// Interaction logic for J_UpdateRecipe_Others_Page.xaml
    /// </summary>
    public partial class J_UpdateRecipe_Others_Page : Page
    {
        List<RecipesBookService.RecipeIngredient> lstri = new List<RecipesBookService.RecipeIngredient>();
        RecipesBookService.Recipes currentRecipe;

        public J_UpdateRecipe_Others_Page()
        {
            InitializeComponent();
        }
        public J_UpdateRecipe_Others_Page(RecipesBookService.Recipes r, List<RecipesBookService.RecipeIngredient> lst) : this()
        {
            currentRecipe = r;
            lstri = lst;
            if (currentRecipe.recipeDifficulty == 1)
            {
                recipeDifficultyImage.Visibility = Visibility.Visible;
                recipeDifficultyTextBlock.Text = "קל";
            }
            if (currentRecipe.recipeDifficulty == 2)
            {
                recipeDifficultyImage.Visibility = Visibility.Visible;
                recipeDifficultyTextBlock.Text = "בינוני";
            }
            if (currentRecipe.recipeDifficulty == 3)
            {
                recipeDifficultyImage.Visibility = Visibility.Visible;
                recipeDifficultyTextBlock.Text = "קשה";
            }

            if (currentRecipe.recipeSarvingAmount.ToString() != "0" && currentRecipe.recipeSarvingAmount.ToString() != null)
            {
                recipeServingsTextBlock.Text = currentRecipe.recipeSarvingAmount.ToString();
                recipeServingsImage.Visibility = Visibility.Visible;
            }
            if (currentRecipe.recipePreparationTime.ToString() != "0" && currentRecipe.recipePreparationTime.ToString() != null)
            {
                recipePreparationTextBlock.Text = currentRecipe.recipePreparationTime.ToString();
                recipePreparationImage.Visibility = Visibility.Visible;
            }

            try
            {
                if (!(currentRecipe.recipePicture == "" || currentRecipe.recipePicture == null))
                    recipePictureImage.Source = PicturesFunctions.GetImage(currentRecipe.recipePicture);
            }
            catch (Exception ex)
            { }
        }
        private void continueButton_Click(object sender, RoutedEventArgs e)
        {// עובר לעמוד הבא 
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new J_UpdateRecipe_Notes_Page(currentRecipe, lstri));

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
            {
                if (servingsIntegerUpDown.Value != 0)
                    recipeServingsTextBlock.Text = servingsIntegerUpDown.Value.ToString();
                currentRecipe.recipeSarvingAmount = (int)servingsIntegerUpDown.Value;
            }
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
             currentRecipe.recipePreparationTime = (int)preparationTimeDateTimePicker.Value; }
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
        private void picButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
