using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenu.Bussines.Models
{
    public class DishModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool Availability { get; set; }
        public string Image { get; set; }
        public int Category { get; set; }
        public DateTime Created_at { get; set; }
    }
}
