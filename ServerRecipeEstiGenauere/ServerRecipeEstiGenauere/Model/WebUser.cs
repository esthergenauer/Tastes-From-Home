using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class WebUser:BaseEntity
    {
        public int userCode { get; set; }//קוד משתמש
        public string userName { get; set; }//שם משתמש
        public string userEmail { get; set; }//מייל משתמש
        public string userPasscode { get; set; }//קוד אישי משתמש
        public bool userStatus { get; set; }//סטטוס משתמש פעיל/לא פעיל
        public override string[] GetKeyFields()
        {
            return new string[] { "userCode" };
        }

        public override string GetTableName()
        {
            return "WebUser";
        }

        public override string ToString()
        {
            return this.userName;
        }
    }
}

