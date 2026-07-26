using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModal
{
    public class RecipeIngredientDB : BaseDB
    {
        public RecipeIngredientDB() : base("RecipeIngredient")
        { }
        public RecipeIngredient GetRecipeIngredientByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.recipeIngredientCode == code);
        }
        public List<RecipeIngredient> GetList()
        {
            Select();
            return base.list.Cast<RecipeIngredient>().ToList();
        }

        public override BaseEntity CreateModel()
        {
            RecipeIngredient item = new RecipeIngredient();
            item.recipeIngredientCode = Convert.ToInt32(reader["recipeIngredientCode"]);
            item.recipeCode = MyDB.recipeslist.GetRecipesByCode(Convert.ToInt32(reader["recipeCode"]));
            item.ingredientCode = MyDB.ingredientslist.GetIngredientsByCode(Convert.ToInt32(reader["ingredientCode"]));
            item.ingredientamount = Convert.ToDouble(reader["ingredientamount"]);
            item.codeYechidot = MyDB.yechidotlist.GetYechidotByCode(Convert.ToInt32(reader["codeYechidot"]));
            item.recipeIngredientStatus = Convert.ToBoolean(reader["recipeIngredientStatus"]);
            return item;


    }
    public override int GetNextKey()
        {
            List<RecipeIngredient> list = MyDB.recipeIngredientlist.GetList();
            if (list.Count() == 0)
                return 1;
            else
                return (list.Max(x => x.recipeIngredientCode) + 1);
        }

    }
}

