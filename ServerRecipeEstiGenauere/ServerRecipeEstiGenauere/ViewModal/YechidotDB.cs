using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModal
{
    public class YechidotDB : BaseDB
    {
        public YechidotDB() : base("Yechidot")
        { }
        public Yechidot GetYechidotByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.codeYechidot == code);
        }
        public List<Yechidot> GetList()
        {
            Select();
            return base.list.Cast<Yechidot>().ToList();


        }

        public override BaseEntity CreateModel()
        {
            Yechidot item = new Yechidot();
            item.codeYechidot = Convert.ToInt32(reader["codeYechidot"]);
            item.nameYechidot = reader["nameYechidot"].ToString();
            item.statusYechidot = Convert.ToBoolean(reader["statusYechidot"]);
            return item;
        }
        public override int GetNextKey()
        {
            List<Yechidot> list = MyDB.yechidotlist.GetList();
            if (list.Count() == 0)
                return 1;
            else
                return (list.Max(x => x.codeYechidot) + 1);
        }

    }
}
