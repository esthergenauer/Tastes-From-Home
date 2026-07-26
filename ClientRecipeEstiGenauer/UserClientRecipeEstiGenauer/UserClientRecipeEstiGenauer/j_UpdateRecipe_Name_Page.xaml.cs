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
    /// Interaction logic for j_UpdateRecipe_Name_Page.xaml
    /// </summary>
    public partial class j_UpdateRecipe_Name_Page : Page
    {
        string oldName;
        RecipesBookService.Recipes currentRecipe;
        List<RecipesBookService.Folder> lstFolders;
        public j_UpdateRecipe_Name_Page()
        {
            InitializeComponent();

        }
        public j_UpdateRecipe_Name_Page(RecipesBookService.Recipes r) : this()
        {
            oldName = r.recipeName;
            currentRecipe = r;
            lstFolders = Global.proxy.GetAllFolder();
            folderForRecipeComboBox.ItemsSource = lstFolders;
            this.DataContext = currentRecipe;
            recipeNameTextBox.Text = currentRecipe.recipeName;
            currentRecipe.folderCode = lstFolders.Find(x => x.folderCode == currentRecipe.folderCode.folderCode);

            folderForRecipeComboBox.SelectedItem = currentRecipe.folderCode;
            currentRecipe.folderCode = lstFolders.Find(x => x.folderCode == currentRecipe.folderCode.folderCode);

            recipeNotesTextBox.Text = currentRecipe.recipeComments;
            descriptionTextBox.Text = currentRecipe.recipeDescription;


            recipeNameTextBlock1.Text = currentRecipe.recipeName;
            recipefulderTextBlock1.Text = currentRecipe.folderCode.folderName;
            recipeNotesTextBlock1.Text = currentRecipe.recipeComments;
            descriptionTextBlock1.Text = currentRecipe.recipeDescription;






        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Global.proxy.HasDoubleName(recipeNameTextBox.Text) && recipeNameTextBox.Text != oldName) || recipeNameTextBox.Text.Contains("הכנס שם מתכון"))
            {
                if ((Global.proxy.HasDoubleName(recipeNameTextBox.Text) && recipeNameTextBox.Text != oldName))
                {
                    MessageBox.Show("שם זה כבר קיים- הכנס שם אחר");

                    recipeNameTextBox.Text = "(הכנס שם מתכון (חובה";

                    recipeNameTextBox.BorderBrush = Brushes.Red;
                }

                if (recipeNameTextBox.Text.Contains("הכנס שם מתכון"))
                {
                    recipeNameTextBox.ToolTip = "הכנס שם מתכון";

                    recipeNameTextBox.BorderBrush = Brushes.Red;
                }

            }

            else
            {

                currentRecipe.recipeName = recipeNameTextBox.Text;
                currentRecipe.folderCode = (RecipesBookService.Folder)folderForRecipeComboBox.SelectedItem;
                currentRecipe.recipeComments = recipeNotesTextBox.Text;
                currentRecipe.recipeDescription = descriptionTextBox.Text;

                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new J_UpdateRecipe_Ingredients_Page(currentRecipe));
            }
        }

        private void recipeNameTextBox_PreviewMouseDown_2(object sender, MouseButtonEventArgs e)
        {// כשלוחצים הכתב נעלם 
            //if (recipeNameTextBox.Text == "(הכנס שם מתכון (חובה")
            //    recipeNameTextBox.Text = "";
        }

        private void recipeNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {// אם הכתב ריק הוא חוזר
            //if (recipeNameTextBox.Text == "")
            //    recipeNameTextBox.Text = "(הכנס שם מתכון (חובה";
            //else
            //{
            //    recipeNameTextBlock1.Text = recipeNameTextBox.Text;
            //    recipeNameTextBox.Text = "(הכנס שם מתכון (חובה";
            //}

            recipeNameTextBlock1.Text = recipeNameTextBox.Text;
        }

        private void recipeNotesTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {// כשלוחצים הכתב נעלם
         //    if (recipeNameTextBox.Text == "(הארות כאן...(אופציונלי")
         //        recipeNameTextBox.Text = "";
        }

        private void recipeNotesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (recipeNotesTextBox.Text == "")
            //    recipeNotesTextBox.Text = "(הארות כאן...(אופציונלי";

            recipeNotesTextBlock1.Text = recipeNotesTextBox.Text;
        }

        private void descriptionTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // כשלוחצים הכתב נעלם
            //if (descriptionTextBox.Text == "(תיאור כאן...(אופציונלי")
            //    descriptionTextBox.Text = "";
        }

        private void recipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            recipeNameTextBox.ToolTip = null;

            recipeNameTextBox.BorderBrush = new SolidColorBrush(Global.colorDarkBrown);
        }

        private void descriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            descriptionTextBlock1.Text = descriptionTextBox.Text;
        }

        private void folderForRecipeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            recipefulderTextBlock1.Text = ((RecipesBookService.Folder)folderForRecipeComboBox.SelectedItem).folderName;
        }


    }
}
