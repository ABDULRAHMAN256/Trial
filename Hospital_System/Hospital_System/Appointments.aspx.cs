using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hospital_System
{
    public partial class Appointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLists();
                LoadGrid();
            }
        }

        void Msg(string text, bool ok)
        {
            lblMsg.Text = text;
            lblMsg.CssClass = ok ? "text-success" : "text-danger";
        }

        void LoadLists()
        {
            try
            {
                ddlPatient.DataSource = DB.Table("SELECT id, CONCAT(patient_no, ' - ', full_name) AS label FROM patients ORDER BY full_name");
                ddlPatient.DataTextField = "label";
                ddlPatient.DataValueField = "id";
                ddlPatient.DataBind();

                ddlDoctor.DataSource = DB.Table("SELECT id, full_name FROM doctors ORDER BY full_name");
                ddlDoctor.DataTextField = "full_name";
                ddlDoctor.DataValueField = "id";
                ddlDoctor.DataBind();
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        void LoadGrid()
        {
            try
            {
                gvAppointments.DataSource = DB.Table(
                    "SELECT a.id, p.full_name AS patient, d.full_name AS doctor, a.appt_date, a.appt_time, a.reason, a.status " +
                    "FROM appointments a JOIN patients p ON p.id = a.patient_id JOIN doctors d ON d.id = a.doctor_id " +
                    "ORDER BY a.appt_date DESC, a.appt_time");
                gvAppointments.DataBind();
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPatient.Items.Count == 0 || ddlDoctor.Items.Count == 0)
                { Msg("Add at least one patient and one doctor first.", false); return; }

                DateTime date;
                if (!DateTime.TryParse(txtDate.Text, out date))
                { Msg("Enter the date as yyyy-mm-dd.", false); return; }
                if (txtTime.Text.Trim() == "")
                { Msg("Enter the time.", false); return; }

                string day = date.ToString("yyyy-MM-dd");

                object clash = DB.Scalar(
                    "SELECT COUNT(*) FROM appointments WHERE doctor_id=@d AND appt_date=@dt AND appt_time=@t AND status<>'Cancelled'",
                    new MySqlParameter("@d", ddlDoctor.SelectedValue),
                    new MySqlParameter("@dt", day),
                    new MySqlParameter("@t", txtTime.Text.Trim()));
                if (Convert.ToInt32(clash) > 0)
                { Msg("This doctor is already booked at that date and time.", false); return; }

                DB.Run("INSERT INTO appointments (patient_id, doctor_id, appt_date, appt_time, reason, status) " +
                       "VALUES (@p, @d, @dt, @t, @r, @s)",
                    new MySqlParameter("@p", ddlPatient.SelectedValue),
                    new MySqlParameter("@d", ddlDoctor.SelectedValue),
                    new MySqlParameter("@dt", day),
                    new MySqlParameter("@t", txtTime.Text.Trim()),
                    new MySqlParameter("@r", txtReason.Text.Trim()),
                    new MySqlParameter("@s", ddlStatus.SelectedValue));

                Msg("Appointment saved.", true);
                txtDate.Text = ""; txtTime.Text = ""; txtReason.Text = "";
                LoadGrid();
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtDate.Text = ""; txtTime.Text = ""; txtReason.Text = "";
            lblMsg.Text = "";
        }
    }
}