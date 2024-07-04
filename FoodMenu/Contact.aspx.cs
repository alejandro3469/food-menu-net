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

        public void GetDishes()
        {

            var dish_id = Request.QueryString["dish_id"]; //https://localhost:44320/Contact?dish_id=1
            try
            {
                if (Request.QueryString["dish_id"] != null)
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                    var connection = new SqlConnection(connectionString);
                    var command = new SqlCommand("SELECT dish_id, dish_name, " +
                        $"dish_description, dish_price, dish_availability, dish_cat_category_id FROM dishes WHERE dish_id = {dish_id.ToString()};", connection);

                    var da = new SqlDataAdapter(command);
                    var ds = new DataSet();
                    da.Fill(ds);

                    var dishName = ds.Tables[0].Rows[0];
                    txtDishName.Text = dishName[1].ToString();
                    txtDescription.Text = dishName[2].ToString();
                    txtPrice.Text = dishName[3].ToString();
                    cbAvailability.Checked = dishName[4].ToString() == "1" ? true : false;
                    ddlCatCategories.SelectedValue = dishName[5].ToString();

                    var dishpPrice = txtPrice.Text.ToString();
                    var availability = cbAvailability.Checked ? 1 : 0;
                    var dishCategory = ddlCatCategories.SelectedValue.ToString();  //https://localhost:44320/Contact?dish_id=1
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", string.Format("Error" + ex.Message, true));
            }
        }

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
            var availability = cbAvailability.Checked ? 1 : 0;
            var dishCategory = ddlCatCategories.SelectedValue.ToString();


            try
            {
                var command = new SqlCommand($"INSERT INTO dishes (dish_id, dish_name, " +
                    $"dish_description, dish_price, dish_availability, dish_cat_category_id) " +
                    $"VALUES (COALESCE((SELECT MAX(dish_id) FROM dishes) + 1, 1), " +
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
            string dish_id = Request.QueryString["dish_id"];
            string button_text = dish_id != null ? "UPDATE" : "SEND (INSERT)";

            if (dish_id != null) { DeleteDishButton.Visible = true; } else { DeleteDishButton.Visible = false; }
            

            SendDishData.Text = button_text; //https://localhost:44320/Contact?dish_id=1

            if (!IsPostBack)
            {
                GetCategories();
                GetDishes();
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