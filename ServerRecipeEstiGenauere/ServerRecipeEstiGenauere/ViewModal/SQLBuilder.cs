using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModal
{
    public class SQLBuilder
    {
        public static string InsertSQL(BaseEntity entity)
        {
            Type type = entity.GetType();
            string command = "Insert Into " + entity.GetTableName() + " (";
            string values = " Values (";
            foreach (var item in type.GetProperties())
            {
                string n = item.Name;
                var value = item.GetValue(entity);
                if (value is BaseEntity)
                {
                    string k = ((BaseEntity)value).GetKeyFields()[0];
                    value = value.GetType().GetProperty(k).GetValue(value);
                }

                if (value is string)
                {
                    command += n + " ,";
                    values += "N'" + value + "', ";
                }
                if (value is int || value is double || value is bool)
                {
                    command += n + " ,";
                    if (value is bool)
                    {
                        if ((bool)(value) == true)
                            values += 1 + " , ";
                        else
                            values += 0 + " , ";
                    }
                    else
                        values += value + " , ";
                }

                if (value is DateTime)
                {
                    if (value.ToString().IndexOf("00:00:00") < 0)
                    {
                        command += n + " ,";
                        string s = ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
                        values += "CONVERT(DATETIME, '" + s + "' ,111)" + " , ";
                    }
                    else
                    {
                        command += n + " ,";
                        //values += ((DateTime)value).ToString("#yyyy/MM/dd#") + " , ";
                        string s = ((DateTime)value).ToString("yyyy-MM-dd");
                        //values += "CONVERT(DATE, '2015-04-02',111)" + " , ";
                        values += "CONVERT(DATETIME, '" + s + "' ,111)" + " , ";
                    }
                }

            }
            command = command.Substring(0, command.Length - 2) + ")";
            values = values.Substring(0, values.Length - 2) + ")";
            return command + values;
        }

        public static string UpdateSQL(BaseEntity entity)
        {
            Type type = entity.GetType();
            string command = "Update " + entity.GetTableName() + " set ";
            foreach (var item in type.GetProperties())
            {
                string name = item.Name;
                var value = item.GetValue(entity);
                if (value is BaseEntity)
                {

                    string k = ((BaseEntity)value).GetKeyFields()[0];
                    value = value.GetType().GetProperty(k).GetValue(value);
                }




                if (value is string)
                    command += name + " = N'" + value + "', ";
                else
                if (value is int || value is double)
                    command += name + " = " + value + ", ";
                else
                if (value is bool)
                {
                    if ((bool)(value) == true)
                        command += name + " = " + 1 + ", ";
                    else
                        command += name + " = " + 0 + ", ";

                }


                else



                if (value is DateTime)
                    if (value is DateTime)
                        if (value.ToString().IndexOf("00:00:00") < 0)
                        {
                            string s = ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
                            command += name + " = " + "CONVERT(DATETIME, '" + s + "',20)" + " , ";
                        }
                        else
                        {
                            string s = ((DateTime)value).ToString("yyyy-MM-dd");
                            command += name + " = " + "CONVERT(DATETIME, '" + s + " ',111)" + " , ";
                        }

            }
            string where = "";
            foreach (var item in entity.GetKeyFields())
            {
                if (where != "")
                    where += " And ";
                if (entity.GetType().GetProperty(item).GetValue(entity) is string)
                    where += item + " = '" + entity.GetType().GetProperty(item).GetValue(entity) + "' ";
                else
                    where += item + " = " + entity.GetType().GetProperty(item).GetValue(entity);
            }
            command = command.Substring(0, command.Length - 2) + " Where " + where;
            return command;
        }
        public static string DeleteSQL(BaseEntity entity)
        {
            Type type = entity.GetType();
            string command = "Delete From " + entity.GetTableName() + " Where ";

            string where = "";
            foreach (var item in entity.GetKeyFields())
            {
                if (where != "")
                    where += " And ";
                where += item + " = " + entity.GetType().GetProperty(item).GetValue(entity);
            }

            command += where;
            return command;
        }

    }
}
