using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModal
{
    public class RecipeMessagesDB : BaseDB 
    {
        public RecipeMessagesDB() : base("RecipeMessages")
        { }
        public RecipeMessages GetRecipeMessagesByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.messageCode == code);
        }
        public List<RecipeMessages> GetList()
        {
            Select();
            return base.list.Cast<RecipeMessages>().ToList();
        }

        public override BaseEntity CreateModel()
        {
            RecipeMessages item = new RecipeMessages();
            item.messageCode = Convert.ToInt32(reader["messageCode"]);
            item.recipeCode = MyDB.recipeslist.GetRecipesByCode(Convert.ToInt32(reader["recipeCode"]));
           
            item.messagesText = reader["messagesText"].ToString();
            item.userCode = MyDB.userlist.GetUserByCode(Convert.ToInt32(reader["userCode"]));
            item.messageStatus = Convert.ToBoolean(reader["messageStatus"]);
            return item;

            }
        public override int GetNextKey()
        {
            List<RecipeMessages> list = MyDB.recipeMessageslist.GetList();
            if (list.Count() == 0)
                return 1;
            else
                return (list.Max(x => x.messageCode) + 1);
        }

    }
}
