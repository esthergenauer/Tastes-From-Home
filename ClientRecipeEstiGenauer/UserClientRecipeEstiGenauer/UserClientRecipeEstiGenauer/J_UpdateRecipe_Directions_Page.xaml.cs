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
    /// Interaction logic for J_UpdateRecipe_Directions_Page.xaml
    /// </summary>
    public partial class J_UpdateRecipe_Directions_Page : Page
    {
        List<RecipesBookService.RecipeIngredient> lstri = new List<RecipesBookService.RecipeIngredient>();
        RecipesBookService.Recipes currentRecipe;
        int count = 0;
        string rp = "";



        public J_UpdateRecipe_Directions_Page()
        {
            InitializeComponent();
        }
        public J_UpdateRecipe_Directions_Page(RecipesBookService.Recipes r, List<RecipesBookService.RecipeIngredient> lst) : this()
        {//פעולת בונה 

            currentRecipe = r;
            lstri = lst;
            t.Text = currentRecipe.recipePreparation;
        }


        private void continueButton_Click_1(object sender, RoutedEventArgs e)
        {// עובר לעמוד הבא 
            //בודק שיש לפחות אופן ההכנה אחד
            if (t.Text == "" || t.Text == null)
                MessageBox.Show("חסר אופן ההכנה");
            else
            {//עמוד הבא
                currentRecipe.recipePreparation = t.Text;
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new J_UpdateRecipe_Others_Page(currentRecipe, lstri));
            }
        }

    }
}
