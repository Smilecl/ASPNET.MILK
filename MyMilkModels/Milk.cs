using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkModels
{
   public class Milk
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string countryOfOrigin;

        public string CountryOfOrigin
        {
            get { return countryOfOrigin; }
            set { countryOfOrigin = value; }
        }
        private string brand;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        private decimal unitPrice;

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        private string contentDescription;

        public string ContentDescription
        {
            get { return contentDescription; }
            set { contentDescription = value; }
        }
        private Categories category;

        public Categories Category
        {
            get { return category; }
            set { category = value; }
        }
        private DateTime dateOfManufacture;

        public DateTime DateOfManufacture
        {
            get { return dateOfManufacture; }
            set { dateOfManufacture = value; }
        }
    }
}
