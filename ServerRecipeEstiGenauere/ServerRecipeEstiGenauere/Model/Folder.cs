using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Folder: BaseEntity
    {
        public int folderCode { get; set; }//קוד תיקיה למתכונים  
        public string folderName { get; set; }//שם תיקיה למתכונים  
        public string folderPicture { get; set; }// תמונה תיקית מתכונים

        public override string[] GetKeyFields()
        {
            return new string[] { "folderCode" };
        }

        public override string GetTableName()
        {
            return "Folder";
        }

        public override string ToString()
        {
            return this.folderCode.ToString();
        }

    }
}



