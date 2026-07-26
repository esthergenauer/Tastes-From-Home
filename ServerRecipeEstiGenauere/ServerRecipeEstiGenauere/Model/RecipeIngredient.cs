using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RecipeIngredient:BaseEntity
    {
        public int recipeIngredientCode { get; set; }//קוד רכיב מתכון-מפתח ראשי
        public Recipes recipeCode  { get; set; }//קוד מתכון
        public Ingredients ingredientCode { get; set; }//קוד מרכיב
        public double ingredientamount { get; set; }//כמות מרכיב
        public Yechidot codeYechidot { get; set; }//קוד יחידות
        public bool recipeIngredientStatus { get; set; }//פעיל-לא פעיל
        public override string[] GetKeyFields()
        {
            return new string[] { "recipeIngredientCode" };
        }

        public override string GetTableName()
        {
            return "RecipeIngredient";
        }

        public override string ToString()
        {
            return this.recipeIngredientCode.ToString();

        }
    }
}
