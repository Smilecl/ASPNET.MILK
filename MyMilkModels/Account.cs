using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkModels
{
   public class Account
    {
       private int id; 
		private string customerId;
		private string customerPassword;
		private decimal balance;

		public Account() { }

		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		public string CustomerId
		{
			get { return this.customerId; }
			set { this.customerId = value; }
		}		
		public string CustomerPassword
		{
			get { return this.customerPassword; }
			set { this.customerPassword = value; }
		}
		public decimal Balance
		{
			get { return this.balance; }
			set { this.balance = value; }
		}		
    }
}
