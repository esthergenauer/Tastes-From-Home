using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModal
{
    public class MyDB 
    {
        public static FolderDB folderlist = new FolderDB();
        public static FavoriteRecipesDB favRecipeslist  = new FavoriteRecipesDB();
        public static IngredientsBD ingredientslist = new IngredientsBD();
        public static RatingDB ratinglist = new RatingDB();
        public static RecipeIngredientDB recipeIngredientlist = new RecipeIngredientDB();
        public static RecipeMessagesDB recipeMessageslist = new RecipeMessagesDB();
        public static RecipesDB recipeslist = new RecipesDB();
        public static WebUserDB userlist = new WebUserDB();
        public static YechidotDB yechidotlist = new YechidotDB();

    }
}
