using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModal
{
    public abstract class BaseDB 
    {

        protected string connectionString;//לאן להתחבר
        protected SqlConnection connection;//קישור לקובץ באקסס
        protected SqlCommand command;//פקודה שרוצים לבצע
        protected SqlDataReader reader;//קורא את המידע שורה שורה

        protected List<BaseEntity> list;//לשמירת רשימת הנתונים

        protected List<BaseEntity> inserted = new List<BaseEntity>();//רשימה שתשמר האובייקטים שהוסיפו
        protected List<BaseEntity> changed = new List<BaseEntity>();//רשימה שתשמר האובייקטים שהשתנו
        protected List<BaseEntity> deleted = new List<BaseEntity>();//רשימה שתשמר האובייקטים שנמחקו

        public BaseDB(string tableName)
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + GetCurrentPath() + "Data\\EstiGenauerRecipesBook.mdf;Integrated Security=True;";

            connection = new SqlConnection(connectionString); // Change to SqlConnection
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from " + tableName;
            list = new List<BaseEntity>();



        }
        public static string GetCurrentPath()
        {// מחזירה את הנתיב כדי להגיע לקובץ אקסס
            string path = System.IO.Directory.GetCurrentDirectory();
            string[] arr = path.Split('\\');
            path = "";
            for (int i = 0; i < arr.Length - 3; i++)
            {
                path += arr[i] + "\\";
            }
            return path;
        }




        public abstract BaseEntity CreateModel();//פעולה שנממש בתת-מחלקות


        protected void Select()
        {
            if (list.Count() == 0)
            {
                //List<BaseEntity> lst = new List<BaseEntity>();
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(CreateModel());
                    }
                }
                catch (Exception ex) { }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }

            }
        }
        public void Add(BaseEntity item)
        {//מוסיפה לרשימה של עצמים שהוסיפו
            if (item != null)
            {
                inserted.Add(item);
                list.Add(item);
            }
        }
        public void Update(BaseEntity item)
        {//מוסיפה לרשימה של עצמים שעודכנו
            if (item != null)
                changed.Add(item);
        }
        public void Delete(BaseEntity item)
        {//מוסיפה לרשימה של עצמים שמחקו
            if (item != null)
                deleted.Add(item);
        }
        public int SaveChanges()
        {//שמירה של שינויים באקסס
            int records = 0;
            try
            {
                command.Connection = connection;
                connection.Open();
                foreach (var item in inserted)
                {
                    command.CommandText = SQLBuilder.InsertSQL(item);
                    records += command.ExecuteNonQuery();

                }
                inserted.Clear();
                foreach (var item in changed)
                {
                    command.CommandText = SQLBuilder.UpdateSQL(item);
                    records += command.ExecuteNonQuery();
                }
                changed.Clear();
                foreach (var item in deleted)
                {
                    command.CommandText = SQLBuilder.DeleteSQL(item);
                    records += command.ExecuteNonQuery();
                    list.Remove(item);
                }
                deleted.Clear();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + "\nDataBase:" + command.CommandText);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return records;
        }


        public virtual int GetNextKey()
        {
            return 1;
        }
    }
}

    
