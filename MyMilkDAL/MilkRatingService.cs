using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMilkModels;
using System.Data;
using System.Data.SqlClient;

namespace MyMilkDAL
{
   public class MilkRatingService
    {
        public static bool AddBookRating(MilkRatings milkrating)
        {
            string sql =
                "INSERT MilkRatings (MilkId,UserId,Rating,Comment)" +
                "VALUES (@MilkId, @UserId, @Rating, @Comment)";

            sql += " ; SELECT @@IDENTITY";

            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@MilkId", milkrating.MilkId), 
					new SqlParameter("@UserId", milkrating.User.Id), 
					new SqlParameter("@Rating", milkrating.Rating),
					new SqlParameter("@Comment",milkrating.Comment)
				};

                int newId = DBHelper.GetScalar(sql, para);
                if (newId > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        //根据书的Id得到其评价信息
        public static IList<MilkRatings> GetMilkRatingsInfo(int milkId)
        {
            string sql = "select * from MilkRatings where Milkid='" + milkId + "'";
            return GetMilkRatings(sql);
        }

        private static IList<MilkRatings> GetMilkRatings(string safeSql)
        {
            List<MilkRatings> list = new List<MilkRatings>();
            try
            {
                DataTable table = DBHelper.GetDataSet(safeSql);

                foreach (DataRow row in table.Rows)
                {
                    MilkRatings mrating = new MilkRatings();
                    mrating.Id = (int)row["Id"];
                    mrating.MilkId = (int)row["MilkId"];
                    mrating.Rating = (int)row["Rating"];
                    int userId = (int)row["UserId"];
                    mrating.User = UserService.GetAdminUserById(userId);
                    mrating.Comment = (string)row["Comment"];

                    list.Add(mrating);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

    }
}
