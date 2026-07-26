using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RecipeMessages:BaseEntity
    {
        public int messageCode { get; set; }//קוד הודעה
        public Recipes recipeCode { get; set; }//קוד מתכון
      
        public string messagesText { get; set; }//הודעות טקסט
        public WebUser userCode { get; set; }//קוד משתמש
        public bool messageStatus { get; set; }//חדש או לא
        public override string[] GetKeyFields()
        {
            return new string[] { "messageCode" };
        }

        public override string GetTableName()
        {
            return "RecipeMessages";
        }

        public override string ToString()
        {
            return this.messagesText;
        }

    }
}
