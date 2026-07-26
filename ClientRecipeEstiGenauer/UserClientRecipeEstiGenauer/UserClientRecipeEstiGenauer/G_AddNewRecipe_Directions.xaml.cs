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
    /// Interaction logic for G_AddNewRecipe_Directions.xaml
    /// </summary>
    public partial class G_AddNewRecipe_Directions : Page
    {
        List<RecipesBookService.RecipeIngredient> lstri = new List<RecipesBookService.RecipeIngredient>();
        RecipesBookService.Recipes currentRecipe;
        int count = 0;
        string rp = "";

        public G_AddNewRecipe_Directions()
        {
            InitializeComponent();
        }

        public G_AddNewRecipe_Directions(RecipesBookService.Recipes r, List<RecipesBookService.RecipeIngredient> lst) : this()
        {
            currentRecipe = r;
            lstri = lst;
        }

        private void continueButton_Click_1(object sender, RoutedEventArgs e)
        {// עובר לעמוד הבא 
            if (stackPanel2.Children.Count == 0)
                MessageBox.Show("חסר אופן ההכנה");
            else
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new G_AddNewRecipe_Others(currentRecipe, lstri));
            }
        }



        private void addDirectionsButton_Click(object sender, RoutedEventArgs e)
        {  //כאשר לוחצים על להוסיף אופן ההכנה  
            if (addDirectionsTextBox.Text == null|| addDirectionsTextBox.Text=="")
            {  //בודק האם לא הוסיף אופן ההכנה

                MessageBox.Show("לא ניתן להוסיף אופן הכנה ריק");
                addDirectionsTextBox.BorderBrush = Brushes.Red;
            }

            else
            {// מוסיף את אופן ההכנה כי בדק תקינות
                count++;
                TextBlock t = new TextBlock();
                t.TextWrapping = TextWrapping.Wrap;
                t.Text = count + ". " + addDirectionsTextBox.Text;
                stackPanel2.Children.Add(t);
                rp = rp + t.Text + Environment.NewLine;
                addDirectionsTextBox.Watermark = "הקלד כאן-אנא הקפד להקליד את זה נכון!";
                addDirectionsTextBox.Text = null;
            }
            currentRecipe.recipePreparation = rp;
        }
    }
}

