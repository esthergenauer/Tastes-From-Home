using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModal
{
    public class RatingDB : BaseDB
    {
        public RatingDB() : base("Rating")
        { }
        public Rating GetRatingByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.ratingCode == code);
        }
        public List<Rating> GetList()
        {
            Select();
            return base.list.Cast<Rating>().ToList();
        }

        public override BaseEntity CreateModel()
        {
            Rating item = new Rating();
            item.ratingCode = Convert.ToInt32(reader["ratingCode"]);
            item.rateValue = Convert.ToInt32(reader["rateValue"]);
            item.userCode = MyDB.userlist.GetUserByCode(Convert.ToInt32(reader["userCode"]));
            item.recipeCode = MyDB.recipeslist.GetRecipesByCode(Convert.ToInt32(reader["recipeCode"]));
            item.ratingStatus = Convert.ToBoolean(reader["ratingStatus"]);
            return item;
        }

       
        public override int GetNextKey()
        {
            List<Rating> list = MyDB.ratinglist.GetList();
            if (list.Count() == 0)
                return 1;
            else
                return (list.Max(x => x.ratingCode) + 1);
        }


    }
}
