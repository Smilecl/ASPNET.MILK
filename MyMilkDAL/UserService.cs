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
    public static partial class UserService
    {
        public static bool LoginIdExists(string loginId)
        {
            if (GetUserByLoginId(loginId) == null)
            { return true; }
            else
            { return false; }

        }


        public static Users GetUserByLoginId(string loginId)
        {
            string sql = "SELECT * FROM Users WHERE LoginId = @LoginId";
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@LoginId", loginId));
                if (reader.Read())
                {
                    Users user = new Users();
                    user.Id = (int)reader["Id"];
                    user.LoginId = (string)reader["LoginId"];
                    user.LoginPwd = (string)reader["LoginPwd"];
                    user.Name = (string)reader["Name"];
                    user.Address = (string)reader["Address"];
                    user.Phone = (string)reader["Phone"];
                    user.Mail = (string)reader["Mail"];
                    reader.Close();

                    return user;
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
                return null;
            }
        }
        public static void AddUser(Users user)
        {
            string sql =
                "INSERT Users (LoginId, LoginPwd, Name, Address, Phone, Mail)" +
                "VALUES (@LoginId, @LoginPwd, @Name, @Address, @Phone, @Mail)";

            sql += " ; SELECT @@IDENTITY";

            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@LoginId", user.LoginId),
					new SqlParameter("@LoginPwd", user.LoginPwd),
					new SqlParameter("@Name", user.Name),
					new SqlParameter("@Address", user.Address),
					new SqlParameter("@Phone", user.Phone),
					new SqlParameter("@Mail", user.Mail)
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Users GetAdminUserById(int Id)
        {
            string sql = "SELECT * FROM Users WHERE Id = @Id";


            SqlParameter[] para = new SqlParameter[]
            {
				new SqlParameter("@Id", Id), 
			};
            using (SqlDataReader reader = DBHelper.GetReader(sql, para))
            {
                if (reader.Read())
                {
                    Users user = new Users();
                    user.Id = (int)reader["Id"];
                    user.LoginId = (string)reader["LoginId"];
                    user.LoginPwd = (string)reader["LoginPwd"];
                    user.Name = (string)reader["Name"];
                    user.Address = (string)reader["Address"];
                    user.Phone = (string)reader["Phone"];
                    user.Mail = (string)reader["Mail"];
                    reader.Close();
                    return user;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        public static Users GetAdminUserByLoginId(string loginId)
        {
            string sql = "SELECT * FROM Users WHERE LoginId = @LoginId";


            SqlParameter[] para = new SqlParameter[]
            {
				new SqlParameter("@LoginId", loginId), 
			};
            using (SqlDataReader reader = DBHelper.GetReader(sql, para))
            {
                if (reader.Read())
                {
                    Users user = new Users();
                    user.Id = (int)reader["Id"];
                    user.LoginId = (string)reader["LoginId"];
                    user.LoginPwd = (string)reader["LoginPwd"];
                    user.Name = (string)reader["Name"];
                    user.Address = (string)reader["Address"];
                    user.Phone = (string)reader["Phone"];
                    user.Mail = (string)reader["Mail"];
                    reader.Close();
                    return user;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }

        public static IList<Users> GetAllUsers()
        {
            string sqlAll = "SELECT * FROM Users";
            return GetUsersBySql(sqlAll);
        }
        private static IList<Users> GetUsersBySql(string safeSql)
        {
            List<Users> list = new List<Users>();

            try
            {
                DataTable table = DBHelper.GetDataSet(safeSql);

                foreach (DataRow row in table.Rows)
                {
                    Users user = new Users();

                    user.Id = (int)row["Id"];
                    user.LoginId = (string)row["LoginId"];
                    user.LoginPwd = (string)row["LoginPwd"];
                    user.Name = (string)row["Name"];
                    user.Address = (string)row["Address"];
                    user.Phone = (string)row["Phone"];
                    user.Mail = (string)row["Mail"];

                    list.Add(user);
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
