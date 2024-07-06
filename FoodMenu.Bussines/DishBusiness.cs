using FoodMenu.Bussines.Models;
using FootMenu.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace FoodMenu.Bussines
{
    public class DishBusiness
    {
        public List<DishModel> GetDishes()
        {
            try
            {
                var datObject = new DishData();
                var dt = datObject.GetDishes();

                var dishes = new List<DishModel>();

                foreach (DataRow item in dt.Rows)
                {
                    var dish = new DishModel()
                    {
                        Id = Convert.ToInt32(item["dish_id"]),
                        Name = item["dish_name"].ToString(),
                        Description = item["dish_description"] is DBNull ? string.Empty : item["dish_description"].ToString(),
                        Availability = Convert.ToBoolean(item["dish_availability"]),
                        Price = Convert.ToDouble(item["dish_price"]),
                        Image = item["dish_image"] is DBNull ? "/img/dishes/sin_imagen.jpg" : item["dish_image"].ToString(),
                        Created_at = item["dish_created_at"] is DBNull ? DateTime.Now : Convert.ToDateTime(item["dish_created_at"]),
                    };

                    dishes.Add(dish);
                }

                return dishes;
            }
            catch (ApplicationException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error to convert dishes: {ex.Message}");
            }
        }

        public DishModel GetDish(int dishId)
        {
            try
            {
                var datObject = new DishData();
                var dt = datObject.GetDish(dishId);

                var dish = new DishModel()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["dish_id"]),
                    Name = dt.Rows[0]["dish_name"].ToString(),
                    Description = dt.Rows[0]["dish_description"] is DBNull ? string.Empty : dt.Rows[0]["dish_description"].ToString(),
                    Availability = Convert.ToBoolean(dt.Rows[0]["dish_availability"]),
                    Price = Convert.ToDouble(dt.Rows[0]["dish_price"]),
                    Image = dt.Rows[0]["dish_image"] is DBNull ? "/img/dishes/sin_imagen.jpg" : dt.Rows[0]["dish_image"].ToString(),
                    Created_at = dt.Rows[0]["dish_created_at"] is DBNull ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["dish_created_at"]),
                };

                return dish;
            }
            catch (ApplicationException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error to convert dishes: {ex.Message}");
            }
        }
    }
}
