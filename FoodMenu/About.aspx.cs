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
    public partial class About : Page
    {

        public void GetDishes()
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}