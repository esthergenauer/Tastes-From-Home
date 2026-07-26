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
    /// Interaction logic for Recipe_Page.xaml
    /// </summary>
    public partial class Recipe_Page : Page
    {
        List<RecipesBookService.RecipeIngredient> lst = new List<RecipesBookService.RecipeIngredient>();
        RecipesBookService.Recipes currentRecipe;

        public Recipe_Page()
        {
            InitializeComponent();
        }

        public Recipe_Page(RecipesBookService.Recipes r) : this()
        {
            currentRecipe = r;

            if (currentRecipe.userCode.userCode == Global.currentUser.userCode)
            {
                UpdateRecipeButton.Visibility = Visibility.Visible;
                deleteRecipeButton.Visibility = Visibility.Visible;

                List<RecipesBookService.RecipeMessages> lstR = Global.proxy.GetAllRecipeMessages().Where(x => x.recipeCode.recipeCode == r.recipeCode && x.messageStatus == true).ToList();
                foreach (var x in lstR)
                {
                    x.messageStatus = false;
                    Global.proxy.UpdateRecipeMessages(x);
                }
            }

            lst = Global.proxy.GetIngredientsByRecipe(currentRecipe);

            this.DataContext = currentRecipe;

            recipeNametextblock.Text = currentRecipe.recipeName;
            recipeCommentsTextBlock.Text = currentRecipe.recipeComments;
            descriptionTextBlock.Text = currentRecipe.recipeDescription;
            userNameOfRecipe.Text = currentRecipe.userCode.userName;
            recipeNotes.Text = currentRecipe.recipeComments;
            int num = Global.proxy.RatingForRecipe(currentRecipe);
          
            //ratingStars
            if (Global.proxy.RatingForRecipe(currentRecipe) == 0)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }

            if (Global.proxy.RatingForRecipe(currentRecipe) == 1)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }

            if (Global.proxy.RatingForRecipe(currentRecipe) == 2)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }

            if (Global.proxy.RatingForRecipe(currentRecipe) == 3)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }

            if (Global.proxy.RatingForRecipe(currentRecipe) == 4)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }

            if (Global.proxy.RatingForRecipe(currentRecipe) == 5)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            }

            //Recipe Difficulty

            if (currentRecipe.recipeDifficulty == 1)
            {//אם רמת קושי המתכון הוא 1 אז זה קל
                recipeDifficulty.Text = "קל";
            }

            if (currentRecipe.recipeDifficulty == 2)
            {//אם רמת קושי המתכון הוא 2 אז זה בינוני
                recipeDifficulty.Text = "בינוני";
            }

            if (currentRecipe.recipeDifficulty == 3)
            {//אם רמת קושי המתכון הוא 3 אז זה קשה
                recipeDifficulty.Text = "קשה";
            }

            if(currentRecipe.recipeSarvingAmount!=0)
            recipeservings.Text = currentRecipe.recipeSarvingAmount.ToString() + " מנות";
            if(currentRecipe.recipePreparationTime!=0)
            recipepreparationTime.Text = currentRecipe.recipePreparationTime.ToString() + " דקות";
            recipeNotes.Text = currentRecipe.recipeNotes;

            string s = "";
            foreach (var x in lst)
            {
                s = s + x.ingredientamount + " " + x.codeYechidot.nameYechidot + " " + x.ingredientCode.ingredientName + Environment.NewLine;
            }

            allIngredientsTextBlock.Text = s;
            alldirectionsTextBlock.Text = currentRecipe.recipePreparation;

            //recipeImage
            try
            {
                if (!(currentRecipe.recipePicture == "" || currentRecipe.recipePicture == null))
                    recipeImage.Source = PicturesFunctions.GetImage(currentRecipe.recipePicture);
            }
            catch (Exception ex)
            { }

            this.messagesFrame.Navigate(new ChatMessages__page(currentRecipe, this));
        }
        public void MakeChatBig()
        {
            try
            {   if (currentRecipe != null)
                {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new ChatMessages__page(currentRecipe));
                }
            }
            catch(Exception ex)
            { }
        }
        public void UpdateStars()
        {
            int num = Global.proxy.RatingForRecipe(currentRecipe);
            //ratingStars***********************************
            if (Global.proxy.RatingForRecipe(currentRecipe) == 0)///////////////////////////////help!!!!!!!!!!!!
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }

            if (Global.proxy.RatingForRecipe(currentRecipe) == 1)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }

            if (Global.proxy.RatingForRecipe(currentRecipe) == 2)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }

            if (Global.proxy.RatingForRecipe(currentRecipe) == 3)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }

            if (Global.proxy.RatingForRecipe(currentRecipe) == 4)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }

            if (Global.proxy.RatingForRecipe(currentRecipe) == 5)
            {
                ratingStars1.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars2.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars3.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars4.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                ratingStars5.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            }
        }

        private void UpdateRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new j_UpdateRecipe_Name_Page(currentRecipe));
        }

        private void mechakButton_Click(object sender, RoutedEventArgs e)
        {//מחיקת המתכון שואל אם בטוח רוצה למחוק ומוחק חלקית

            MessageBoxResult result = MessageBox.Show("!למחוק? אין דרך חזרה", "מחיקה", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Global.proxy.DeletePartiallyRecipes(currentRecipe);
                MessageBox.Show("המתכון נמחק");
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new C_AllRecipes_Page());
            }
           
        }
    }
}