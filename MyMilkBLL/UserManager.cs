using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMilkDAL;
using MyMilkModels;

namespace MyMilkBLL
{
    public static partial class UserManager
    {
        public static void AddUser(string LoginId, string LoginPwd, string Name, string Address, string Phone, string Mail)
        {
            Users user = new Users();
            user.LoginId = LoginId;
            user.LoginPwd = LoginPwd;
            user.Name = Name;
            user.Address = Address;
            user.Phone = Phone;
            user.Mail = Mail;
            UserService.AddUser(user);
        }


        public static bool LoginIdExists(string loginId)
        {
            return UserService.LoginIdExists(loginId);
        }


        public static bool AdminLogin(string loginId, string loginPwd, out Users validUser)
        {
            Users user = UserService.GetAdminUserByLoginId(loginId);

            if (user == null)
            {
                //用户名不存在 
                validUser = null;
                return false;
            }

            if (user.LoginPwd == loginPwd)
            {
                validUser = user;
                return true;
            }
            else
            {
                //密码错误
                validUser = null;
                return false;
            }
        }
        public static IList<Users> GetAllUsers()
        {
            return UserService.GetAllUsers();
        }
    }
}
