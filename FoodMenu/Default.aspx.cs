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
                GetDish();
            }
        }

        private void GetDish()
        {
            var dish = new DishBusiness().GetDish(2);

            lblId.Text = dish.Id.ToString();
            lblName.Text = dish.Name;
            lblDesc.Text = dish.Description;
            chkAvail.Checked = dish.Availability;
            lblPrice.Text = dish.Price.ToString("C");
            imgImage.ImageUrl = dish.Image;
            lblDate.Text = dish.Created_at.ToString("dddd dd \\de MMMM \\del yyyy");
        }

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
    }
}