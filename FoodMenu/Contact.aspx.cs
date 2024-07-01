using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodMenu
{
    public partial class Contact : Page
    {

        public void GetCategories()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                var connection = new SqlConnection(connectionString);
                var command = new SqlCommand("SELECT category_id, category_name FROM cat_categories;", connection);

                var da = new SqlDataAdapter(command);
                var ds = new DataSet();
                da.Fill(ds);

                ddlCatCategories.DataSource = ds.Tables[0];
                ddlCatCategories.DataTextField = "category_name";
                ddlCatCategories.DataValueField = "category_id";
                ddlCatCategories.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", string.Format("Error" + ex.Message, true));
            }
        }

        public void SendData()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            var connection = new SqlConnection(connectionString);

            var dishName = txtDishName.Text.ToString();
            var dishDescription = txtDescription.Text.ToString();
            var dishpPrice = txtPrice.Text.ToString();
            var availability = 1;
            if (cbAvailability.Checked)
            {
                availability = 1;
            } else
            {
                availability = 0;
            }
            var dishCategory = ddlCatCategories.SelectedValue.ToString();


            try
            {
                var command = new SqlCommand($"INSERT INTO dishes (dish_id, dish_name, " +
                    $"dish_description, dish_price, dish_availability, dish_cat_category_id) " +
                    $"VALUES (COALESCE((SELECT MAX(dish_id) FROM dishes) + 1, 0), " +
                    $"'{dishName}', '{dishDescription}', {dishpPrice}, {availability}, {dishCategory});", connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", string.Format("Error" + ex.Message, true));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();
            }
        }

        protected void imbDishImageFile_Load(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }



        protected void SendDishData_Click(object sender, EventArgs e)
        {
            SendData();
        }
    }
}