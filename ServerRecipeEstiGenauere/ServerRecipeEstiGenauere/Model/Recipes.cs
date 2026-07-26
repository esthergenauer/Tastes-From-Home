using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Recipes:BaseEntity
    {
        public int recipeCode { get; set; }//קוד מתכון
        public string recipeName { get; set; }//שם מתכון
        public int recipeDifficulty { get; set; }//רמת קושי מתכון
        public string recipePreparation { get; set; }//אופן ההכנה
        public WebUser userCode { get; set; }//קוד משתמש- ששם את המתכון
        public int recipePreparationTime { get; set; }//זמן הכנת המתכון
        public int recipeSarvingAmount { get; set; }//כמות מנות מהמתכון
        public string recipeComments { get; set; }//הארות על המתכן
        public string recipePicture { get; set; }//תמונת המתכון
        public Folder folderCode { get; set; }//קוד תיקיה
        public string recipeDescription { get; set; }//תיאור המתכון
        public string recipeNotes { get; set; }//

      

        public bool recipeStatus { get; set; }
       
        public override string[] GetKeyFields()
        {
            return new string[] { "recipeCode" };
        }

        public override string GetTableName()
        {
            return "Recipes";
        }

        public override string ToString()
        {
            return this.recipeName;
        }

       
    }
}
