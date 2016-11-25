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
    public class MilkService
    {
        public static IList<Milk> GetAllMilk()
        {
            string sqlAll = "SELECT * FROM Milk";
            return GetMilkBySql(sqlAll);
        }


        private static IList<Milk> GetMilkBySql(string safeSql)
        {
            List<Milk> list = new List<Milk>();

            try
            {
                DataTable table = DBHelper.GetDataSet(safeSql);

                foreach (DataRow row in table.Rows)
                {
                    Milk milk = new Milk();

                    milk.Id = (int)row["Id"];
                    milk.Name = (string)row["Name"];
                    milk.CountryOfOrigin = (string)row["CountryOfOrigin"];
                    milk.Brand = (string)row["brand"];
                    milk.ContentDescription = (string)row["ContentDescription"];
                    milk.UnitPrice = (decimal)row["UnitPrice"];
                    milk.DateOfManufacture = (DateTime)row["DateOfManufacture"];
                    milk.Category = CategoryService.GetCategoryById((int)row["CategoryId"]);
                    list.Add(milk);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }


        public static void DeleteMilkById(int id)
        {
            string sql = "DELETE Milk WHERE Id = @Id";

            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", id)
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }


        public static Milk GetMilkById(int id)
        {
            string sql = "SELECT * FROM Milk WHERE Id = @Id";

            int categoryId;
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    Milk milk = new Milk();

                    milk.Id = (int)reader["Id"];
                    milk.Name = (string)reader["Name"];
                    milk.CountryOfOrigin = (string)reader["CountryOfOrigin"];
                    milk.Brand = (string)reader["brand"];
                    milk.ContentDescription = (string)reader["ContentDescription"];
                    milk.UnitPrice = (decimal)reader["UnitPrice"];
                    milk.DateOfManufacture = (DateTime)reader["DateOfManufacture"];
                    categoryId = (int)reader["CategoryId"];
                    reader.Close();

                    milk.Category = CategoryService.GetCategoryById(categoryId);


                    return milk;
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


        public static void ModifyMilk(Milk milk)
        {
            string sql =
                "UPDATE Milk " +
                "SET " +
                    "CategoryId = @CategoryId, " + //FK
                     "Name = @Name, " +
                    "CountryOfOrigin= @CountryOfOrigin, " +
                    "brand = @brand, " +
                    "UnitPrice = @UnitPrice, " +
                    "ContentDescription = @ContentDescription, " +
                     "DateOfManufacture = @DateOfManufacture  " +
                " WHERE Id = @Id";


            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", milk.Id),
					new SqlParameter("@CategoryId", milk.Category.Id), //FK
					new SqlParameter("@Name", milk.Name),
                    new SqlParameter("@brand", milk.Brand),
					new SqlParameter("@CountryOfOrigin", milk.CountryOfOrigin),
					new SqlParameter("@UnitPrice", milk.UnitPrice),
					new SqlParameter("@ContentDescription", milk.ContentDescription),
					new SqlParameter("@DateOfManufacture", milk.DateOfManufacture),
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }
        public static IList<Milk> GetSmallMilk(int categoryId, string order)
        {
            return GetMilk("Id,Name, CountryOfOrigin, brand, UnitPrice,SubString(ContentDescription,0,200) as ShortContent,DateOfManufacture", categoryId, order);
        }
        /// <summary>
        /// 为增加访问灵活性增加的方法
        /// </summary>
        /// <param name="field"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IList<Milk> GetMilk(string field, int categoryId, string order)
        {
            //组合的条件语句
            string condition = "";
            if (categoryId > 0)
                condition = " WHERE CategoryId = " + categoryId;
            if (order.Trim().Length > 0)
                condition = " order by " + order;
            return GetSmallMilkBySql("SELECT " + field + " FROM Milk " + condition);
        }
        /// <summary>
        /// 返回不完整字段的图书
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        private static IList<Milk> GetSmallMilkBySql(string safeSql)
        {
            List<Milk> list = new List<Milk>();
            DataTable table = DBHelper.GetDataSet(safeSql);
            foreach (DataRow row in table.Rows)
            {
                Milk milk = new Milk();
                milk.Id = (int)row["Id"];
                milk.Name = (string)row["Name"];
                milk.CountryOfOrigin = (string)row["CountryOfOrigin"];
                milk.Brand = (string)row["brand"];
                milk.ContentDescription = (string)row["ShortContent"];
                milk.UnitPrice = (decimal)row["UnitPrice"];
                milk.DateOfManufacture = (DateTime)row["DateOfManufacture"];
                if (table.Columns.Contains("CategoryId"))
                milk.Category = CategoryService.GetCategoryById((int)row["CategoryId"]);
                list.Add(milk);
            }
            return list;
        }

        public static IList<Milk> GetMilkByCategoryId(int categoryId)
        {
            string sql = "select top 3 *from Milk where CategoryId=" + categoryId + " Order by id desc";
            return GetMilkBySql(sql);
        }
        public static string[] GetMilkHotSearchKeywords(string keyword, int displaycount)
        {
            IList<Milk> keywords = new List<Milk>();
            List<string> results = new List<string>(displaycount);
            string sqlHot = "select top 3 * from Milk where Name like '" + keyword + "%' order by Id desc";
            keywords = GetMilkSearchKeywordsBySql(sqlHot);
            foreach (Milk item in keywords)
            {
                results.Add(item.Name);
            }
            return results.ToArray();
        }
        private static IList<Milk> GetMilkSearchKeywordsBySql(string safeSql)
        {
            List<Milk> list = new List<Milk>();

            try
            {
                DataTable table = DBHelper.GetDataSet(safeSql);

                foreach (DataRow row in table.Rows)
                {

                    Milk milk = new Milk();
                    milk.Id = (int)row["Id"];
                    milk.Name = (string)row["Name"];
                    milk.CountryOfOrigin = (string)row["CountryOfOrigin"];
                    milk.Brand = (string)row["brand"];
                    milk.ContentDescription = (string)row["ContentDescription"];
                    milk.UnitPrice = (decimal)row["UnitPrice"];
                    milk.DateOfManufacture = (DateTime)row["DateOfManufacture"];
                     milk.Category = CategoryService.GetCategoryById((int)row["CategoryId"]);
                    list.Add(milk);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public static Milk GetMilkByName(string name)
        {
            string sql = "SELECT * FROM Milk WHERE Name = @Name";
            int categoryId;
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Name", name));
                if (reader.Read())
                {
                    Milk milk = new Milk();

                    milk.Id = (int)reader["Id"];
                    milk.Name = (string)reader["Name"];
                    milk.CountryOfOrigin = (string)reader["CountryOfOrigin"];
                    milk.Brand = (string)reader["brand"];
                    milk.ContentDescription = (string)reader["ContentDescription"];
                    milk.UnitPrice = (decimal)reader["UnitPrice"];
                    milk.DateOfManufacture = (DateTime)reader["DateOfManufacture"];
                    categoryId = (int)reader["CategoryId"];
                    reader.Close();

                    milk.Category = CategoryService.GetCategoryById(categoryId);


                    return milk;
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
		
    }
}
