using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkModels
{
   public  class Users
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string loginId;

        public string LoginId
        {
            get { return loginId; }
            set { loginId = value; }
        }
        private string loginPwd;

        public string LoginPwd
        {
            get { return loginPwd; }
            set { loginPwd = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }
}
