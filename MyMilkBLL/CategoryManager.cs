using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMilkModels;
using MyMilkDAL;

namespace MyMilkBLL
{
   public  class CategoryManager
    {
       public static IList<Categories> GetAllCategories()
       {
           return CategoryService.GetAllCategories();
       }
    }
}
