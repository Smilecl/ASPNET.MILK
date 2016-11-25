using System;
using System.Collections.Generic;
using System.Text;
using MyMilkModels;
using MyMilkDAL;
using System.Data.SqlClient;

namespace MyMilkBLL
{
    public enum PayResults
    {
        Success, NotEnoughMoney, UnknownError, InvalidAccount
    }

    public static partial class AccountManager
    {
        public static PayResults Pay(string customerId, string customerPassword, int amount)
        {
            Account account;
            try
            {
                //验证帐户是否有效
                account = AccountService.GetAccountByCustomerId(customerId);
                //假如帐户不存在，返回非法帐户
                if (account == null) return PayResults.InvalidAccount;
                //假如帐户密码不正确，也返回非法帐户
                if (account.CustomerPassword != customerPassword) return PayResults.InvalidAccount;
                //验证帐户余额是否足够
                if (account.Balance < amount) return PayResults.NotEnoughMoney;
                //执行支付
                account.Balance -= amount;
                //如果支付成功，返回成功结果
                if (AccountService.ModifyAccount(account))
                {
                    return PayResults.Success;
                }
                //如果未支付成功，返回未知错误
                else
                {
                    return PayResults.UnknownError;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return PayResults.UnknownError;
            }
        }
    }
}
