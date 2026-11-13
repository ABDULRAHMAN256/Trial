using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Hospital_System
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["hospital"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(cs))
                {
                    con.Open();
                    lblMessage.Text = "Connected successfully";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message + "<br />" + ex.StackTrace;
            }
        }
    }
}