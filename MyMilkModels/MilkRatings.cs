using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkModels
{
   public  class MilkRatings
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int milkId;

        public int MilkId
        {
            get { return milkId; }
            set { milkId = value; }
        }
        private Users user;

        public Users User
        {
            get { return user; }
            set { user = value; }
        }
        private int rating;

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
