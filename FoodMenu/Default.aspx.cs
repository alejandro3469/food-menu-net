using FoodMenu.Bussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodMenu
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGvDishes();
                FillCatCategoriesDDL();
            }
        }

        public void FillGVDishes()
        {
            gvDishes.DataSource = new DishBusiness().GetDishes();
            gvDishes.DataBind();
        }
        public void FillCatCategoriesDDL()
        {
            try
            {
                DropDownList ddlCatCategories = (DropDownList)gvDishes.FooterRow.FindControl("ddlCatCategoriesFT");
                var categories = new DishBusiness().GetCategories();
                ddlCatCategories.DataSource = categories;
                ddlCatCategories.DataTextField = "Name";
                ddlCatCategories.DataValueField = "Id";
                ddlCatCategories.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MostrarMensaje(ex.Message);
            }
        }
        private void MostrarMensaje(string p)
        {
            string alerta = string.Format("alert('{0}')", p.Replace("'", "").Replace("\r", "").Replace("\n", ""));
            ScriptManager.RegisterStartupScript(this, GetType(), "", alerta, true);
        }

        /*private void GetDish()
        {
            var dish = new DishBusiness().GetDish(5);

            lblId.Text = dish.Id.ToString();
            lblName.Text = dish.Name;
            lblDesc.Text = dish.Description;
            chkAvail.Checked = dish.Availability;
            lblPrice.Text = dish.Price.ToString("C");
            imgImage.ImageUrl = dish.Image;
            lblDate.Text = dish.Created_at.ToString("dddd dd \\de MMMM \\del yyyy");
        }*/

        private void FillGvDishes()
        {
            try
            {
                var busObject = new DishBusiness();
                var dishes = busObject.GetDishes();
                gvDishes.DataSource = dishes;
                gvDishes.DataBind();
            }
            catch (Exception ex)
            {
                var script = $"alert('Error: ${ex.Message.Replace("\'", "")}');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", script, true);
            }
        }


        public void gvDishes_RowRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var dish_id = Convert.ToInt32(gvDishes.DataKeys[e.RowIndex].Values["Id"]);
                var dishName = ((TextBox)gvDishes.Rows[e.RowIndex].FindControl("txtNombreEIT")).Text;
                var dishDescription = ((TextBox)gvDishes.Rows[e.RowIndex].FindControl("txtDescriptionEIT")).Text;
                var dishpPrice = Convert.ToInt32(((TextBox)gvDishes.Rows[e.RowIndex].FindControl("txtPriceEIT")).Text);
                var availability = ((CheckBox)gvDishes.Rows[e.RowIndex].FindControl("txtAvailabilityEIT")).Checked;
                var dishCategory = Convert.ToInt32(((DropDownList)gvDishes.Rows[e.RowIndex].FindControl("ddlCatCategoriesEIT")).SelectedValue);
                var image = ((TextBox)gvDishes.Rows[e.RowIndex].FindControl("txtImageEIT")).Text;

                var categories = new DishBusiness();
                categories.UpdateDish(Convert.ToInt32(dish_id), dishName, dishDescription, dishpPrice, availability, dishCategory, image, DateTime.Now);
                Response.Redirect(Request.CurrentExecutionFilePath);
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
        protected void gvDishes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDishes.EditIndex = -1;
            FillGvDishes();
            FillCatCategoriesDDL();
        }
        protected void gvDishes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvDishes.DataKeys[e.RowIndex].Values["Id"]);
                DeleteDish(id);
                Response.Redirect(Request.CurrentExecutionFilePath);
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
        public void DeleteDish(int id)
        {
            var categories = new DishBusiness();
            categories.DeleteDish(Convert.ToInt32(id));
        }
        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var txtDishNameFT = ((TextBox)gvDishes.FooterRow.FindControl("txtDishNameFT")).Text;
                var txtDescriptionFT = ((TextBox)gvDishes.FooterRow.FindControl("txtDescriptionFT")).Text;
                var cbAvailabilityFT = ((CheckBox)gvDishes.FooterRow.FindControl("cbAvailabilityFT")).Checked;
                var txtPriceFT = int.Parse(((TextBox)gvDishes.FooterRow.FindControl("txtPriceFT")).Text);
                var txtImageFT = ((TextBox)gvDishes.FooterRow.FindControl("txtImageFT")).Text;
                var ddlCatCategoriesFT = Convert.ToInt32(((DropDownList)gvDishes.FooterRow.FindControl("ddlCatCategoriesFT")).SelectedValue);

                var categories = new DishBusiness();
                categories.AddDish(txtDishNameFT, txtDescriptionFT, txtPriceFT, cbAvailabilityFT, ddlCatCategoriesFT, txtImageFT, DateTime.Now);


                Response.Redirect(Request.CurrentExecutionFilePath);
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
        public void gvDoctores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvDishes.EditIndex = e.NewEditIndex; // cambiar a modo editar
                FillGVDishes(); //recargar el gv
                DropDownList ddlCatCategoriesEIT = (DropDownList)gvDishes.Rows[e.NewEditIndex].FindControl("ddlCatCategoriesEIT");
                var categories = new DishBusiness().GetCategories();
                ddlCatCategoriesEIT.DataSource = categories;
                ddlCatCategoriesEIT.DataTextField = "Name";
                ddlCatCategoriesEIT.DataValueField = "Id";
                ddlCatCategoriesEIT.DataBind();
                ddlCatCategoriesEIT.SelectedValue = gvDishes.DataKeys[e.NewEditIndex].Values["Category"].ToString();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
    }
}