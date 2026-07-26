using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModal
{
    public class RecipesDB : BaseDB 
    {
        public RecipesDB() : base("Recipes")
        { }
        public Recipes GetRecipesByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.recipeCode == code);
        }
        public List<Recipes> GetList()
        {
            Select();
            return base.list.Cast<Recipes>().ToList();


        }

        public override BaseEntity CreateModel()
        {
            Recipes item = new Recipes();
            item.recipeCode= Convert.ToInt32(reader["recipeCode"]);
            item.recipeName = reader["recipeName"].ToString();
            item.recipeDifficulty = Convert.ToInt32(reader["recipeDifficulty"]);
            item.recipePreparation = reader["recipePreparation"].ToString();
            item.userCode = MyDB.userlist.GetUserByCode(Convert.ToInt32(reader["userCode"]));
            item.recipePreparationTime = Convert.ToInt32(reader["recipePreparationTime"]);
            item.recipeSarvingAmount = Convert.ToInt32(reader["recipeSarvingAmount"]);
            item.recipeComments = reader["recipeComments"].ToString();
            item.recipePicture = reader["recipePicture"].ToString();
            item.recipeNotes = reader["recipeNotes"].ToString();
            item.recipeStatus = Convert.ToBoolean(reader["recipeStatus"]);
            item.folderCode = MyDB.folderlist.GetFolderByCode(Convert.ToInt32(reader["folderCode"]));
            item.recipeDescription = reader["recipeDescription"].ToString();
           

            return item;

        }
        public override int GetNextKey()
        {
            List<Recipes> list = MyDB.recipeslist.GetList();
            if (list.Count() == 0)
                return 1;
            else
                return (list.Max(x => x.recipeCode) + 1);
        }
    }
}
