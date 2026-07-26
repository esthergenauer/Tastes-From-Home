using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModal
{
    public class IngredientsBD : BaseDB
    {

        public IngredientsBD() : base("Ingredients")
        { }
        public Ingredients GetIngredientsByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.ingredientsCode == code);
        }
        public List<Ingredients> GetList()
        {
            Select();
            return base.list.Cast<Ingredients>().ToList();
        }
        public override BaseEntity CreateModel()
        {
            Ingredients item = new Ingredients();
            item.ingredientsCode = Convert.ToInt32(reader["ingredientsCode"]);
            item.ingredientName = reader["ingredientName"].ToString();
            item.containsSesame = Convert.ToBoolean(reader["containsSesame"]);
            item.containsGluten = Convert.ToBoolean(reader["containsGluten"]);
            item.containsMilk = Convert.ToBoolean(reader["containsMilk"]);
            item.containsSuger = Convert.ToBoolean(reader["containsSuger"]);
            item.containsSoy = Convert.ToBoolean(reader["containsSoy"]);
            item.containsEggs= Convert.ToBoolean(reader["containsEggs"]);
            item.containsNuts= Convert.ToBoolean(reader["containsNuts"]);
            item.ingredientsStatus = Convert.ToBoolean(reader["ingredientsStatus"]);
            return item;

        }
        public override int GetNextKey()
        {
            List<Ingredients> list = MyDB.ingredientslist.GetList();
            if (list.Count() == 0)
                return 1;
            else
                return (list.Max(x => x.ingredientsCode) + 1);
        }
    }
}
