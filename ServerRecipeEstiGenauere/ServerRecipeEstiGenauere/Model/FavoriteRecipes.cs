using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FavoriteRecipes:BaseEntity 
    {//מתכונים מועדפים
        public Recipes recipeCode { get; set; }//קוד מתכון  
        public WebUser userCode { get; set; }//קוד משתמש
        public int favRecipeCode { get; set; }//קוד משתמש מתכון-מפתח ראשי
        public bool favRecipeStatus { get; set; }//פעיל-לא פעיל
        public override string[] GetKeyFields()
        {
            return new string[] { "favRecipeCode" };
        }

        public override string GetTableName()
        {
            return "FavoriteRecipes";
        }

        public override string ToString()
        {
            return this.favRecipeCode.ToString();
        }

    }
}
