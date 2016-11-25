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
                //��֤�ʻ��Ƿ���Ч
                account = AccountService.GetAccountByCustomerId(customerId);
                //�����ʻ������ڣ����طǷ��ʻ�
                if (account == null) return PayResults.InvalidAccount;
                //�����ʻ����벻��ȷ��Ҳ���طǷ��ʻ�
                if (account.CustomerPassword != customerPassword) return PayResults.InvalidAccount;
                //��֤�ʻ�����Ƿ��㹻
                if (account.Balance < amount) return PayResults.NotEnoughMoney;
                //ִ��֧��
                account.Balance -= amount;
                //���֧���ɹ������سɹ����
                if (AccountService.ModifyAccount(account))
                {
                    return PayResults.Success;
                }
                //���δ֧���ɹ�������δ֪����
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
