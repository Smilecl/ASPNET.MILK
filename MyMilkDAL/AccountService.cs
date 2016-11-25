using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyMilkModels;


namespace MyMilkDAL
{
    public static partial class AccountService
    {
       //根据帐户ID获得帐户基本信息
        public static Account GetAccountByCustomerId(string customerId)
        {
            string sql = "select * from Accounts where CustomerId = @CustomerId";
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@CustomerId", customerId));
                if (reader.Read())
                {
                    Account account = new Account();
                    account.Id = (int)reader["Id"];
                    account.CustomerId = (string)reader["CustomerId"];
                    account.CustomerPassword = (string)reader["CustomerPassword"];
                    account.Balance = (decimal)reader["Balance"];
                    reader.Close();
                    return account;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }            
        }

        //支付完成后，修改帐户信息
        public static bool ModifyAccount(Account account)
        {
            string sql = "update Accounts set CustomerId = @CustomerId, CustomerPassword = @CustomerPassword, Balance = @Balance where Id = @Id";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id", account.Id),
                new SqlParameter("@CustomerId", account.CustomerId),
                new SqlParameter("@CustomerPassword", account.CustomerPassword),
                new SqlParameter("@Balance", account.Balance)
            };
            try
            {
                DBHelper.ExecuteCommand(sql, para);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }		
    }
}
