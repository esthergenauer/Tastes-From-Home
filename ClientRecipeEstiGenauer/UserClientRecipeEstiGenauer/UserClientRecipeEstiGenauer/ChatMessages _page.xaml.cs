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
using Xceed.Wpf.Toolkit;

namespace UserClientRecipeEstiGenauer
{
    /// <summary>
    /// Interaction logic for ChatMessages__page.xaml
    /// </summary>
    public partial class ChatMessages__page : Page
    {
        RecipesBookService.RecipeMessages r1 = new RecipesBookService.RecipeMessages();
        RecipesBookService.Recipes currentRecipe;
        RecipesBookService.Rating rate1 = new RecipesBookService.Rating();
        
        Page parentPage;
        int countfav;
        public ChatMessages__page()
        {
            InitializeComponent();
            
        }
        public ChatMessages__page(RecipesBookService.Recipes r) : this()
        {
            currentRecipe = r;
            int n = 0;
            if (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser) != null)
                n = Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser).rateValue; 
           
            if(n==1)
            {
                star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }
            if (n == 2)
            {
                star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }
            if (n == 3)
            {
                star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }
            if (n == 4)
            {
                star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }
            if (n == 5)
            {
                star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            }


            if (Global.proxy.isFavRecipe(currentRecipe, Global.currentUser))
            {
                countfav = 1;
                favRecipeImage.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/DarkHeart.png"));
            }
            else
            {
                countfav = 0;
                favRecipeImage.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/LightHeart.png"));
            }
            List<RecipesBookService.RecipeMessages> lstR = Global.proxy.GetMessagesByRecipe(r);
            foreach (var x in lstR)
            { //שם את כל ההודעות של המתכון הנוכחי בצאט של המתכון לפי הסדר
                UserControlMessages um = new UserControlMessages(x);
                um.Margin = new Thickness(10);
                messagesStackPanel.Children.Add(um);
            }
        }
        public ChatMessages__page(RecipesBookService.Recipes r, Page p) : this()
        {
            parentPage = p;
            currentRecipe = r;
            if (Global.proxy.isFavRecipe(currentRecipe, Global.currentUser))
            {
                countfav = 1;
                favRecipeImage.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/DarkHeart.png"));
            }
            else
            {
                countfav = 0;
                favRecipeImage.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/LightHeart.png"));
            }
            List<RecipesBookService.RecipeMessages> lstR = Global.proxy.GetMessagesByRecipe(r);
            foreach (var x in lstR)
            { //שם את כל ההודעות של המתכון הנוכחי בצאט של המתכון לפי הסדר

                messagesStackPanel.Children.Add(new UserControlMessages(x));
            }
            int n = 0;

            if(Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser)!=null)
                n=Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser).rateValue; 
            
            if (n == 1)
            {
                star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }
            if (n == 2)
            {
                star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }
            if (n == 3)
            {
                star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
                star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }
            if (n == 4)
            {
                star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            }
            if (n == 5)
            {
                star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
                star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            }

        }
        private void sendMessageButton_Click(object sender, RoutedEventArgs e)
        {//כשלוחצים על לשלוח הודעה זה מוסיף ושולח
            //בודק שההודעה הנשלחת לא ריקה

            if (textTextBox.Text == null || textTextBox.Text == "")
            {
                System.Windows.MessageBox.Show("אין אפשרות לשלוח הודעה ריקה");
            }
            else
            {
                r1.messageCode = Global.proxy.GetNextKeyRecipeMessages();
                r1.messageStatus = true;
                r1.userCode = Global.currentUser;
                r1.messagesText = textTextBox.Text;
                r1.recipeCode = currentRecipe;
                //r1.messagesPicture

                Global.proxy.AddNewRecipeMessages(r1);
                List<RecipesBookService.RecipeMessages> lstR = Global.proxy.GetMessagesByRecipe(currentRecipe);
                messagesStackPanel.Children.Clear();
                foreach (var x in lstR)
                { //שם את כל ההודעות של המתכון הנוכחי בצאט של המתכון לפי הסדר
                    UserControlMessages u = new UserControlMessages(x);
                    u.Margin = new Thickness(2);
                    messagesStackPanel.Children.Add(u);
                }
                textTextBox.Text = "";
            }

        }

       
        private void favRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            RecipesBookService.FavoriteRecipes favR = new RecipesBookService.FavoriteRecipes();
            countfav++;
            if (countfav % 2 != 0)
            {
                favRecipeImage.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/DarkHeart.png"));

                //make a new fav
                favR.favRecipeCode = Global.proxy.GetNextKeyFavoriteRecipes();
                favR.favRecipeStatus = true;
                favR.recipeCode = currentRecipe;
                favR.userCode = Global.currentUser;
                Global.proxy.AddNewFavoriteRecipes(favR);
            }
            else
            {
                favR = Global.proxy.favRecipeForUser(currentRecipe, Global.currentUser);
                Global.proxy.DeleteCompletelyFavoriteRecipes(favR);
                favRecipeImage.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/LightHeart.png"));
            }
        }

        private void star1Button_Click(object sender, RoutedEventArgs e)
        {//להוסיף את הדירוג לממוצא דירוגים של המתכון הנוכח

            if (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser) == null)
            { //make a new rating

                RecipesBookService.Rating newRating1 = new RecipesBookService.Rating();
                newRating1.ratingCode = Global.proxy.GetNextKeyRating();
                newRating1.rateValue = 1;
                newRating1.ratingStatus = true;
                newRating1.recipeCode = currentRecipe;
                newRating1.userCode = Global.currentUser;
                Global.proxy.AddNewRating(newRating1);
            }
            else
            {//update fav
                rate1 = (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser));

                rate1.rateValue = 1;
                rate1.ratingStatus = true;
                rate1.recipeCode = currentRecipe;
                rate1.userCode = Global.currentUser;
                Global.proxy.UpdateRating(rate1);
            }

            star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));

            if (parentPage != null)
            {
                parentPage.Dispatcher.Invoke(() =>
                {
                    ((Recipe_Page)parentPage).UpdateStars(); // Call the makechatbig method on the parent page
                });
            }
        }

        private void star2Button_Click(object sender, RoutedEventArgs e)
        {//להוסיף את הדירוג לממוצא דירוגים של המתכון הנוכח

            if (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser) == null)
            { //make a new rating

                RecipesBookService.Rating newRating1 = new RecipesBookService.Rating();
                newRating1.ratingCode = Global.proxy.GetNextKeyRating();
                newRating1.rateValue = 2;
                newRating1.ratingStatus = true;
                newRating1.recipeCode = currentRecipe;
                newRating1.userCode = Global.currentUser;

                Global.proxy.AddNewRating(newRating1);
            }
            else
            {
                rate1 = (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser));

                rate1.rateValue = 2;
                rate1.ratingStatus = true;
                rate1.recipeCode = currentRecipe;
                rate1.userCode = Global.currentUser;
                Global.proxy.UpdateRating(rate1);
            }

            star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));

            if (parentPage != null)
            {
                parentPage.Dispatcher.Invoke(() =>
                {
                    ((Recipe_Page)parentPage).UpdateStars(); // Call the makechatbig method on the parent page
                });
            }
        }

        private void star3Button_Click(object sender, RoutedEventArgs e)
        {//להוסיף את הדירוג לממוצא דירוגים של המתכון הנוכח

            if (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser) == null)
            { //make a new rating

                RecipesBookService.Rating newRating1 = new RecipesBookService.Rating();
                newRating1.ratingCode = Global.proxy.GetNextKeyRating();
                newRating1.rateValue = 3;
                newRating1.ratingStatus = true;
                newRating1.recipeCode = currentRecipe;
                newRating1.userCode = Global.currentUser;

                Global.proxy.AddNewRating(newRating1);
            }
            else
            {
                rate1 = (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser));

                rate1.rateValue = 3;
                rate1.ratingStatus = true;
                rate1.recipeCode = currentRecipe;
                rate1.userCode = Global.currentUser;
                Global.proxy.UpdateRating(rate1);
            }

            star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));
            star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));

            if (parentPage != null)
            {
                parentPage.Dispatcher.Invoke(() =>
                {
                    ((Recipe_Page)parentPage).UpdateStars(); // Call the makechatbig method on the parent page
                });
            }
        }

        private void star4Button_Click(object sender, RoutedEventArgs e)
        {//להוסיף את הדירוג לממוצא דירוגים של המתכון הנוכח

            if (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser) == null)
            { //make a new rating

                RecipesBookService.Rating newRating1 = new RecipesBookService.Rating();
                newRating1.ratingCode = Global.proxy.GetNextKeyRating();
                newRating1.rateValue = 4;
                newRating1.ratingStatus = true;
                newRating1.recipeCode = currentRecipe;
                newRating1.userCode = Global.currentUser;

                Global.proxy.AddNewRating(newRating1);
            }
            else
            {
                rate1 = (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser));

                rate1.rateValue = 4;
                rate1.ratingStatus = true;
                rate1.recipeCode = currentRecipe;
                rate1.userCode = Global.currentUser;
                Global.proxy.UpdateRating(rate1);
            }

            star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/lightStar.png"));

            if (parentPage != null)
            {
                parentPage.Dispatcher.Invoke(() =>
                {
                    ((Recipe_Page)parentPage).UpdateStars(); // Call the makechatbig method on the parent page
                });
            }
        }

        private void star5Button_Click(object sender, RoutedEventArgs e)
        {//להוסיף את הדירוג לממוצא דירוגים של המתכון הנוכח

            if (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser) == null)
            { //make a new rating

                RecipesBookService.Rating newRating1 = new RecipesBookService.Rating();
                newRating1.ratingCode = Global.proxy.GetNextKeyRating();
                newRating1.rateValue = 5;
                newRating1.ratingStatus = true;
                newRating1.recipeCode = currentRecipe;
                newRating1.userCode = Global.currentUser;

                Global.proxy.AddNewRating(newRating1);
            }
            else
            {
                rate1 = (Global.proxy.RatingRecipeForUser(currentRecipe, Global.currentUser));

                rate1.rateValue = 5;
                rate1.ratingStatus = true;
                rate1.recipeCode = currentRecipe;
                rate1.userCode = Global.currentUser;
                Global.proxy.UpdateRating(rate1);
            }

            star1Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star2Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star3Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star4Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));
            star5Image.Source = new BitmapImage(new Uri("pack://application:,,,/RecipeBookPictuers/WindowhomePage/Recipe/darkStar.png"));

            if (parentPage != null)
            {
                parentPage.Dispatcher.Invoke(() =>
                {
                    ((Recipe_Page)parentPage).UpdateStars(); // Call the makechatbig method on the parent page
                });
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (parentPage != null)
                {
                    parentPage.Dispatcher.Invoke(() =>
                    {
                        ((Recipe_Page)parentPage).MakeChatBig(); // Call the makechatbig method on the parent page
                });
                }
                else
                {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new Recipe_Page(currentRecipe));
                }
            }
            catch(Exception ex)
            {
               
            }
        }
    }
}

