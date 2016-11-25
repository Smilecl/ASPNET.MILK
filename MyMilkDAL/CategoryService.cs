using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMilkModels;
using System.Data.SqlClient;
using System.Data;

namespace MyMilkDAL
{
   public  class CategoryService
    {
        public static Categories GetCategoryById(int id)
        {
            string sql = "SELECT * FROM Categories WHERE Id = @Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    Categories category = new Categories();

                    category.Id = (int)reader["Id"];
                    category.Name = (string)reader["Name"];

                    reader.Close();

                    return category;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        public static IList<Categories> GetAllCategories()
        {
            string sqlAll = "SELECT * FROM Categories";
            return GetCategoriesBySql(sqlAll);
        }

        private static IList<Categories> GetCategoriesBySql(string safeSql)
        {
            List<Categories> list = new List<Categories>();

            try
            {
                DataTable table = DBHelper.GetDataSet(safeSql);

                foreach (DataRow row in table.Rows)
                {
                    Categories categories = new Categories();

                    categories.Id = (int)row["Id"];
                    categories.Name = (string)row["Name"];

                    list.Add(categories);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
    
    }

}
