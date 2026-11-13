using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hospital_System
{
    public partial class Billing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatients();
                LoadGrid();
            }
        }

        void Msg(string text, bool ok)
        {
            lblMsg.Text = text;
            lblMsg.CssClass = ok ? "text-success" : "text-danger";
        }

        void LoadPatients()
        {
            try
            {
                ddlPatient.DataSource = DB.Table("SELECT id, CONCAT(patient_no, ' - ', full_name) AS label FROM patients ORDER BY full_name");
                ddlPatient.DataTextField = "label";
                ddlPatient.DataValueField = "id";
                ddlPatient.DataBind();
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        void LoadGrid()
        {
            try
            {
                gvBilling.DataSource = DB.Table(
                    "SELECT b.id, p.full_name AS patient, b.service, b.amount, b.bill_date, b.paid " +
                    "FROM billing b JOIN patients p ON p.id = b.patient_id ORDER BY b.id DESC");
                gvBilling.DataBind();

                object total = DB.Scalar("SELECT IFNULL(SUM(amount), 0) FROM billing WHERE paid='No'");
                lblUnpaid.Text = Convert.ToDecimal(total).ToString("N2");
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPatient.Items.Count == 0)
                { Msg("Add a patient first.", false); return; }
                if (txtService.Text.Trim() == "")
                { Msg("Enter the service.", false); return; }

                decimal amount;
                if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0)
                { Msg("Enter a valid amount greater than zero.", false); return; }

                DB.Run("INSERT INTO billing (patient_id, service, amount, bill_date, paid) VALUES (@p, @s, @a, NOW(), @pd)",
                    new MySqlParameter("@p", ddlPatient.SelectedValue),
                    new MySqlParameter("@s", txtService.Text.Trim()),
                    new MySqlParameter("@a", amount),
                    new MySqlParameter("@pd", ddlPaid.SelectedValue));

                Msg("Bill saved.", true);
                txtService.Text = ""; txtAmount.Text = "";
                LoadGrid();
            }
            catch (Exception ex) { Msg("Error: " + ex.Message, false); }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtService.Text = ""; txtAmount.Text = "";
            lblMsg.Text = "";
        }
    }
}