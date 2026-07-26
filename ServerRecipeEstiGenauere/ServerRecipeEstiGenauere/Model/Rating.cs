using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rating:BaseEntity
    {
        public int ratingCode { get; set; }//קוד דירוג
        public int rateValue { get; set; }//ערך הדירוג
        public WebUser userCode { get; set; }//קוד משתמש
        public Recipes recipeCode { get; set; }//קוד מתכון
        public bool ratingStatus { get; set; }// סטטוס דירוג
        public override string[] GetKeyFields()
        {
            return new string[] { "ratingCode" };
        }

        public override string GetTableName()
        {
            return "Rating";
        }

        public override string ToString()
        {
            return this.ratingCode.ToString();
        }

    }
}
