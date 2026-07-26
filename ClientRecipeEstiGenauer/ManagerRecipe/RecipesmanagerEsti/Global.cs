using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesmanagerEsti
{
    class Global
    {
        public static ServiceReference1.RecipeServiceClient proxy = new ServiceReference1.RecipeServiceClient();
        public static ServiceReference1.WebUser currentUser;

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
