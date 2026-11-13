using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hospital_System
{
    public partial class Doctors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartments();
                LoadGrid();
            }
        }

        void Msg(string text, bool ok)
        {
            lblMsg.Text = text;
            lblMsg.CssClass = ok ? "text-success" : "text-danger";
        }

        void LoadDepartments()
        {
            try
            {
                ddlDept.DataSource = DB.Table("SELECT id, dept_name FROM departments ORDER BY dept_name");
                ddlDept.DataTextField = "dept_name";
                ddlDept.DataValueField = "id";
                ddlDept.DataBind();
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        void LoadGrid()
        {
            try
            {
                gvDoctors.DataSource = DB.Table(
                    "SELECT d.full_name, d.specialization, d.phone, dp.dept_name AS department " +
                    "FROM doctors d LEFT JOIN departments dp ON dp.id = d.department_id ORDER BY d.id DESC");
                gvDoctors.DataBind();
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "" || txtPhone.Text.Trim() == "")
                { Msg("Name and phone are required.", false); return; }
                if (ddlDept.Items.Count == 0)
                { Msg("Add a department first.", false); return; }

                object exists = DB.Scalar("SELECT COUNT(*) FROM doctors WHERE phone=@p",
                    new MySqlParameter("@p", txtPhone.Text.Trim()));
                if (Convert.ToInt32(exists) > 0)
                { Msg("A doctor with this phone already exists.", false); return; }

                DB.Run("INSERT INTO doctors (full_name, specialization, phone, department_id) VALUES (@n, @s, @p, @d)",
                    new MySqlParameter("@n", txtName.Text.Trim()),
                    new MySqlParameter("@s", txtSpec.Text.Trim()),
                    new MySqlParameter("@p", txtPhone.Text.Trim()),
                    new MySqlParameter("@d", ddlDept.SelectedValue));

                Msg("Doctor saved.", true);
                txtName.Text = ""; txtSpec.Text = ""; txtPhone.Text = "";
                LoadGrid();
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = ""; txtSpec.Text = ""; txtPhone.Text = "";
            lblMsg.Text = "";
        }
    }
}