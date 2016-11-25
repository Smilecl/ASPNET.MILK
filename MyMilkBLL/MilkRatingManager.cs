using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMilkDAL;
using MyMilkModels;

namespace MyMilkBLL
{
   public  class MilkRatingManager
    {
        public static IList<MilkRatings> GetMilkRatingsInfo(int milkId)
        {
            return MilkRatingService.GetMilkRatingsInfo(milkId);
        }

        public static bool AddMilkRating(MilkRatings milkrating)
        {
            return MilkRatingService.AddBookRating(milkrating);
        }
    }
}
