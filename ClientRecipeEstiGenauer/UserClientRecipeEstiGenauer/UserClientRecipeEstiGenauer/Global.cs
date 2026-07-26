using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UserClientRecipeEstiGenauer
{
   public class Global
    {
        public static RecipesBookService.RecipeServiceClient proxy = new RecipesBookService.RecipeServiceClient();
        public static RecipesBookService.WebUser currentUser;
        public static Color colorDarkBrown = (Color)ColorConverter.ConvertFromString("#FF794827");



        public static string GetCurrentPath()
        {// מחזירה את הנתיב כדי להגיע לקובץ אקסס
            string path = System.IO.Directory.GetCurrentDirectory();
            string[] arr = path.Split('\\');
            path = "";
            for (int i = 0; i < arr.Length - 2; i++)
            {
                path += arr[i] + "\\";
            }
            return path;
        }

    }
}
