using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMilkDAL;
using MyMilkModels;


namespace MyMilkBLL
{
   public  class MilkManager
    {
        public static IList<Milk> GetAllMilk()
        {
            return MilkService.GetAllMilk();
        }

        public static void DeleteMilkById(int id)
        {
            MilkService.DeleteMilkById(id);
        }

        public static Milk GetMilkById(int id) {
            return MilkService.GetMilkById(id);
        }
        public static void ModifyMilk(string Name, string CountryOfOrigin, string brand, decimal UnitPrice, string ContentDescription, DateTime DateOfManufacture, int CategoryId,
       int Id)
        {
            Milk milk = MilkService.GetMilkById(Id);
            milk.Id = Id;
            milk.Name = Name;
            milk.CountryOfOrigin = CountryOfOrigin;
            milk.Brand = brand;
            milk.UnitPrice = UnitPrice;
            milk.ContentDescription = ContentDescription;
            milk.DateOfManufacture = DateOfManufacture;
            milk.Category = CategoryService.GetCategoryById(CategoryId);
            MilkService.ModifyMilk(milk);
        }
        public static IList<Milk> GetOrderedSmallBookByCategoryId(int categoryId, string order)
        {
            return MilkService.GetSmallMilk(categoryId, order);
        }
        public static IList<Milk> GetMilkByCategoryId(int categoryId)
        {
            return MilkService.GetMilkByCategoryId(categoryId);
        }
        public static string[] GetMilkHotSearchKeywords(string keyword, int displaycount)
        {
            return MilkService.GetMilkHotSearchKeywords(keyword, displaycount);
        }
        public static Milk GetMilkByName(string name) {
            return MilkService.GetMilkByName(name);
        }
    }
}
