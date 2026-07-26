using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModal
{
   public class FolderDB:BaseDB
    {
       public FolderDB():base("Folder")
        { }
            public Folder GetFolderByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.folderCode == code);
        }
        public List<Folder> GetList()
        {
            Select();
            return base.list.Cast<Folder>().ToList();

        }

        public override BaseEntity CreateModel()
        {
            Folder item = new Folder();
            item.folderCode = Convert.ToInt32(reader["folderCode"]);
            item.folderName = reader["folderName"].ToString();
            item.folderPicture= reader["folderPicture"].ToString();
            return item;

        }

        public override int GetNextKey()
        {
            List<Folder> list = MyDB.folderlist.GetList();
            if (list.Count() == 0)
                return 1;
            else
                return (list.Max(x => x.folderCode) + 1);
        }
    }

}



