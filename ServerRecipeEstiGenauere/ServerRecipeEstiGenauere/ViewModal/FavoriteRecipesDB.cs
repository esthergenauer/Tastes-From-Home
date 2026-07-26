using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModal
{
    public class FavoriteRecipesDB : BaseDB
    {
        public FavoriteRecipesDB() : base("FavoriteRecipes")
        { }
        public FavoriteRecipes GetFavoriteRecipesByCode(int code)
        {//מקבל מתכון מועדף על פי קוד
            return GetList().FirstOrDefault(x => x.favRecipeCode == code);
        }

        public List<FavoriteRecipes> GetList()
        {
            Select();
            return base.list.Cast<FavoriteRecipes>().ToList();
        }
        public override BaseEntity CreateModel()
        {
            FavoriteRecipes item = new FavoriteRecipes();
            item.recipeCode = MyDB.recipeslist.GetRecipesByCode(Convert.ToInt32(reader["recipeCode"]));
            item.userCode = MyDB.userlist.GetUserByCode(Convert.ToInt32(reader["userCode"]));
            item.favRecipeCode = Convert.ToInt32(reader["favRecipeCode"]);
            item.favRecipeStatus = Convert.ToBoolean(reader["favRecipeStatus"]);
            return item;

        }
        public override int GetNextKey()
        {
            List<FavoriteRecipes> list = MyDB.favRecipeslist.GetList();
            if (list.Count() == 0)
                return 1;
            else
                return (list.Max(x => x.favRecipeCode) + 1);
        }
    }
}