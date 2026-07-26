using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ingredients:BaseEntity
    {
        public int ingredientsCode { get; set; }//קוד מרכיבים
        public string ingredientName { get; set; }//שם מרכיב
        public bool ingredientsStatus { get; set; }//סטטוס מרכיב
        public bool containsGluten { get; set; }//האם מכיל גלוטן
        public bool containsSesame { get; set; }//האם מכיל שומשום
        public bool containsMilk { get; set; }//האם מכיל חלב
        public bool containsNuts { get; set; }//האם מכיל אגוזים
        public bool containsSuger { get; set; }//האם מכיל סוכר
        public bool containsSoy { get; set; }//האם מכיל סויה
        public bool containsEggs { get; set; }//האם מכיל ביצים
   
    public override string[] GetKeyFields()
        {
            return new string[] { "ingredientsCode" };
        }

        public override string GetTableName()
        {
            return "Ingredients";
        }

        public override string ToString()
        {
            return this.ingredientName;
        }

    }
}
