using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Yechidot : BaseEntity
    {
        public int codeYechidot { get; set; }//קוד יחידות
        public string nameYechidot { get; set; }//שם יחידות 
        public bool statusYechidot { get; set; }//פעיל-לא פעיל
        public override string[] GetKeyFields()
        {
            return new string[] { "codeYechidot" };
        }

        public override string GetTableName()
        {
            return "Yechidot";
        }

        public override string ToString()
        {
            return this.nameYechidot;
        }

    }
}
