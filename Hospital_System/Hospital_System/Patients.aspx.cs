using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hospital_System
{
    public partial class Patients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadGrid();
        }

        void Msg(string text, bool ok)
        {
            lblMsg.Text = text;
            lblMsg.CssClass = ok ? "text-success" : "text-danger";
        }

        void LoadGrid()
        {
            try
            {
                gvPatients.DataSource = DB.Table("SELECT patient_no, full_name, gender, date_of_birth, phone, address, next_of_kin FROM patients ORDER BY id DESC");
                gvPatients.DataBind();
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        void ClearBoxes()
        {
            txtName.Text = ""; txtDob.Text = ""; txtPhone.Text = "";
            txtAddress.Text = ""; txtKin.Text = "";
            ddlGender.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "" || txtPhone.Text.Trim() == "")
                { Msg("Name and phone are required.", false); return; }

                DateTime dob;
                if (!DateTime.TryParse(txtDob.Text, out dob))
                { Msg("Enter the date of birth as yyyy-mm-dd.", false); return; }

                object exists = DB.Scalar("SELECT COUNT(*) FROM patients WHERE phone=@p",
                    new MySqlParameter("@p", txtPhone.Text.Trim()));
                if (Convert.ToInt32(exists) > 0)
                { Msg("A patient with this phone already exists.", false); return; }

                long id = DB.Insert(
                    "INSERT INTO patients (full_name, gender, date_of_birth, phone, address, next_of_kin, date_registered) " +
                    "VALUES (@n, @g, @d, @p, @a, @k, NOW())",
                    new MySqlParameter("@n", txtName.Text.Trim()),
                    new MySqlParameter("@g", ddlGender.SelectedValue),
                    new MySqlParameter("@d", dob.ToString("yyyy-MM-dd")),
                    new MySqlParameter("@p", txtPhone.Text.Trim()),
                    new MySqlParameter("@a", txtAddress.Text.Trim()),
                    new MySqlParameter("@k", txtKin.Text.Trim()));

                DB.Run("UPDATE patients SET patient_no=@no WHERE id=@id",
                    new MySqlParameter("@no", "P" + id.ToString("D4")),
                    new MySqlParameter("@id", id));

                Msg("Patient saved.", true);
                ClearBoxes();
                LoadGrid();
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DB.Table("SELECT * FROM patients WHERE phone=@p",
                    new MySqlParameter("@p", txtPhone.Text.Trim()));
                if (dt.Rows.Count == 0) { Msg("No patient found with that phone.", false); return; }

                DataRow r = dt.Rows[0];
                txtName.Text = r["full_name"].ToString();
                ddlGender.SelectedValue = r["gender"].ToString();
                txtDob.Text = r["date_of_birth"] == DBNull.Value ? "" : ((DateTime)r["date_of_birth"]).ToString("yyyy-MM-dd");
                txtAddress.Text = r["address"].ToString();
                txtKin.Text = r["next_of_kin"].ToString();
                Msg("Patient found.", true);
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            lblMsg.Text = "";
        }
    }
}