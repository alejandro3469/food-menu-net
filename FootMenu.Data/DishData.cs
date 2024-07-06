using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMenu.Data
{
    public class DishData
    {
        private readonly string ConnectionString;
        public DishData()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public DataTable GetDishes()
        {
            try
            {
                var connection = new SqlConnection(ConnectionString);
                var command = new SqlCommand("SELECT dish_id, dish_name, " +
                    $"dish_description, dish_price, dish_availability, dish_cat_category_id, dish_image, dish_created_at FROM dishes;", connection);

                var da = new SqlDataAdapter(command);
                var ds = new DataSet();
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error to get dishes: {ex.Message}");
            }
        }

        public DataTable GetDish(int dishId)
        {
            try
            {
                var connection = new SqlConnection(ConnectionString);
                var command = new SqlCommand("spGetDish", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_id", DbType = DbType.Int32, Value = dishId });

                var da = new SqlDataAdapter(command);
                var ds = new DataSet();
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error to get dish, id: {dishId}: {ex.Message}");
            }
        }
    }
}
