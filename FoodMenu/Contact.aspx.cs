using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodMenu.Bussines;
using System.IO;

namespace FoodMenu
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dish_id = Request.QueryString["dish_id"];
            string button_text = dish_id != null ? "UPDATE" : "SEND (INSERT)";

            // Error de escritura de codigo
            // if (dish_id != null)
            // {
            //     DeleteDishButton.Visible = true;
            // }
            // else
            // {
            //     DeleteDishButton.Visible = false;
            // }

            DeleteDishButton.Visible = dish_id != null;


            SendDishData.Text = button_text; //https://localhost:44320/Contact?dish_id=1
            GetCategories();
            if (!IsPostBack)
            {
                GetDish();
            }
        }
        public void GetDish()
        {

            var dish_id = Request.QueryString["dish_id"]; //https://localhost:44320/Contact?dish_id=1
            try
            {
                if (!string.IsNullOrEmpty(dish_id))
                {
                    var dish = new DishBusiness().GetDish(Convert.ToInt32(dish_id));

                    txtDishName.Text = dish.Name;
                    txtDescription.Text = dish.Description;
                    txtPrice.Text = dish.Price.ToString();
                    cbAvailability.Checked = dish.Availability;
                    ddlCatCategories.SelectedValue = dish.Category.ToString();
                    //https://localhost:44320/Contact?dish_id=1
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
                var categories = new DishBusiness().GetCategories();

                ddlCatCategories.DataSource = categories;
                ddlCatCategories.DataTextField = "Name";
                ddlCatCategories.DataValueField = "Id";
                ddlCatCategories.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", string.Format("Error" + ex.Message, true));
            }
        }

        public void SendData()
        {
            /*if (string.IsNullOrEmpty(hfImage.Value) && !imbDishImageFile.HasFile)
            {
                throw new ApplicationException("No se ha cargado ninguna imagen");
            }
            else if (imbDishImageFile.HasFile)
            {
                SaveFile(imbDishImageFile.PostedFile);
            }*/

            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            var connection = new SqlConnection(connectionString);

            var dishName = txtDishName.Text.ToString();
            var dishDescription = txtDescription.Text.ToString();
            var dishpPrice = Convert.ToInt32(txtPrice.Text);
            var availability = cbAvailability.Checked;
            var dishCategory = Convert.ToInt32(ddlCatCategories.SelectedValue.ToString());
            var image = hfImage.Value;
            try
            {

                string dish_id = Request.QueryString["dish_id"];
                var command = new SqlCommand("");

                if (dish_id == null)
                {
                    var categories = new DishBusiness();
                    categories.AddDish(dishName, dishDescription, dishpPrice, availability, dishCategory, image, DateTime.Now);
                }
                else
                {
                    var categories = new DishBusiness();
                    categories.UpdateDish(Convert.ToInt32(dish_id), dishName, dishDescription, dishpPrice, availability, dishCategory, image, DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                var script = $"alert(Error: {ex.Message.Replace("'", "")})";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", script, true);
            }
        }

        private void SaveFile(HttpPostedFile file)
        {
            string savePath = Server.MapPath("/img/dishes/");
            string fileName = imbDishImageFile.FileName;
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }

                fileName = tempfileName;

                // Notify the user that the file name was changed.
                lblMessage.Text = "A file with the same name already exists. <br />Your file was saved as " + fileName;
            }
            else
            {
                // Notify the user that the file was saved successfully.
                lblMessage.Text = "Your file was uploaded successfully.";
            }

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            imbDishImageFile.SaveAs(savePath);

            imgImage.ImageUrl = "img/dishes/" + fileName;
            hfImage.Value = imgImage.ImageUrl;
        }


        protected void SendDishData_Click(object sender, EventArgs e)
        {
            SendData();
        }

        protected void DeleteDishButton_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            var connection = new SqlConnection(connectionString);

            try
            {
                var dish_id = Request.QueryString["dish_id"]; //https://localhost:44320/Contact?dish_id=1

                var command = new SqlCommand($"DELETE FROM dishes WHERE dish_id = {dish_id.ToString()};", connection);


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

        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            if (imbDishImageFile.HasFile)
            {
                if (!string.IsNullOrEmpty(hfImage.Value))
                {
                    File.Delete(Server.MapPath(hfImage.Value));
                }

                SaveFile(imbDishImageFile.PostedFile);
            }
            else
            {
                imgImage.ImageUrl = "img/dishes/sin_imagen.jpg";
            }

        }
    }
}