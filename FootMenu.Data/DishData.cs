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
                var command = new SqlCommand("spGetDishes", connection);
                command.CommandType = CommandType.StoredProcedure;

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
        public DataTable GetCategories()
        {
            try
            {
                var connection = new SqlConnection(ConnectionString);
                var command = new SqlCommand("spGetCategories", connection);
                command.CommandType = CommandType.StoredProcedure;

                var da = new SqlDataAdapter(command);
                var ds = new DataSet();
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error to get categories: {ex.Message}");
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
        public void CreateDish(string dishNme, string dishDescription, int dishPrice, bool dishAvailability, int dishCatCategoryId, string dishImage, DateTime dishCreatedAt)
        {
            try
            {
                var connection = new SqlConnection(ConnectionString);
                var command = new SqlCommand("spCreateDish", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_name", DbType = DbType.String, Value = dishNme });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_description", DbType = DbType.String, Value = dishDescription });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_price", DbType = DbType.Int32, Value = dishPrice });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_availability", DbType = DbType.Boolean, Value = dishAvailability });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_cat_category_id", DbType = DbType.Int32, Value = dishCatCategoryId });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_image", DbType = DbType.String, Value = dishImage });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_created_at", DbType = DbType.DateTime, Value = dishCreatedAt });

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                var script = $"alert('The dish {dishNme} was added successfully')";
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error to add dish, id: : {ex.Message}");
            }
        }

        public void UpdateDish(int dishID, string dishNme, string dishDescription, int dishPrice, bool dishAvailability, int dishCatCategoryId, DateTime dishCreatedAt, string dishImage)
        {
            try
            {           
                var connection = new SqlConnection(ConnectionString);
                var command = new SqlCommand("spUpdateDish", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_ID", DbType = DbType.String, Value = dishID });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_name", DbType = DbType.String, Value = dishNme });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_description", DbType = DbType.String, Value = dishDescription });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_price", DbType = DbType.Int32, Value = dishPrice });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_availability", DbType = DbType.Boolean, Value = dishAvailability ? 1 : 0 });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_cat_category_id", DbType = DbType.Int32, Value = dishCatCategoryId });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_image", DbType = DbType.String, Value = dishImage });
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_created_at", DbType = DbType.DateTime, Value = dishCreatedAt });

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                var script = $"alert('The dish {dishNme} was added successfully')";
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error to add dish, id: : {ex.Message}");
            }
        }
        public void DeleteDish(int dishID)
        {
            try
            {
                var connection = new SqlConnection(ConnectionString);
                var command = new SqlCommand("spDeleteDish", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { ParameterName = "dish_ID", DbType = DbType.String, Value = dishID });

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                var script = $"alert('The dish {dishID} was DELETED successfully')";
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error to add dish, id: : {ex.Message}");
            }
        }

        public DataTable GetCategory(int catgoryId)
        {
            try
            {
                var connection = new SqlConnection(ConnectionString);
                var command = new SqlCommand("spGetCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { ParameterName = "category_id", DbType = DbType.Int32, Value = catgoryId });

                var da = new SqlDataAdapter(command);
                var ds = new DataSet();
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error to get dish, id: {catgoryId}: {ex.Message}");
            }
        }
    }
}
