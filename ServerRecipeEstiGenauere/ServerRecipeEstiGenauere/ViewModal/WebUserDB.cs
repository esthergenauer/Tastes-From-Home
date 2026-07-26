using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModal
{
   public class WebUserDB : BaseDB
    {
        public WebUserDB() : base("WebUser")
        { }
        public WebUser GetUserByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.userCode == code);
        }
        public List<WebUser> GetList()
        {
            
            
            
            Select();
            return base.list.Cast<WebUser>().ToList();


        }

        public override BaseEntity CreateModel()
        {
            WebUser item = new WebUser();
            
            item.userCode = Convert.ToInt32(reader["userCode"]);
            item.userName = reader["userName"].ToString();
            item.userEmail = reader["userEmail"].ToString();
            item.userPasscode = reader["userPasscode"].ToString();
            item.userStatus = Convert.ToBoolean(reader["userStatus"]);
            return item;

        }
        public override int GetNextKey()
        {
            List<WebUser> list = MyDB.userlist.GetList();
            if (list.Count() == 0)
                return 1;
            else
                return (list.Max(x => x.userCode) + 1);
        }
    }
}

