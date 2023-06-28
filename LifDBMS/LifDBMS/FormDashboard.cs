using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LifDBMS
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private DataTable dt;

        Koneksi Konn = new Koneksi();

        FormLogin frmLogIn = new FormLogin();
        Project frm = new Project() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        Transactions frm2 = new Transactions() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        Meetings frm3 = new Meetings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        Proposals frm4 = new Proposals() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        moms frm5 = new moms() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        Dashboard frm6 = new Dashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        private void projectBtn_Click(object sender, EventArgs e)
        {
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pContainer2.Controls.Add(frm);
            frm.Show();
            frm2.Hide();
            frm3.Hide();
            frm4.Hide();
            frm5.Hide();
            frm6.Hide();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            frmLogIn.Show();
            this.Close();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            string user = FormLogin.SenduserName;

            SqlConnection conn;

            using (conn = Konn.GetConn())
            using (SqlCommand cmd = new SqlCommand("SELECT Name FROM Employee a JOIN EmployeeProfile b ON a.LifID = b.LifID WHERE b.Username = '" + user + "'", conn))
            {
                cmd.Parameters.AddWithValue("Name", user);
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (Convert.IsDBNull(result))
                {
                    usernamelbl.Text = string.Empty;
                }
                else
                {
                    usernamelbl.Text = Convert.ToString(result);
                }
            }
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            frm6.FormBorderStyle = FormBorderStyle.None;
            this.pContainer2.Controls.Add(frm6);
            frm.Hide();
            frm2.Hide();
            frm3.Hide();
            frm4.Hide();
            frm5.Hide();
            frm6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm3.FormBorderStyle = FormBorderStyle.None;
            this.pContainer2.Controls.Add(frm3);
            frm2.Hide();
            frm.Hide();
            frm3.Show();
            frm4.Hide();
            frm5.Hide();
            frm6.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm5.FormBorderStyle = FormBorderStyle.None;
            this.pContainer2.Controls.Add(frm5);
            frm.Hide();
            frm2.Hide();
            frm3.Hide();
            frm4.Hide();
            frm5.Show();
            frm6.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm4.FormBorderStyle = FormBorderStyle.None;
            this.pContainer2.Controls.Add(frm4);
            frm.Hide();
            frm2.Hide();
            frm3.Hide();
            frm4.Show();
            frm5.Hide();
            frm6.Hide();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            frm2.FormBorderStyle = FormBorderStyle.None;
            this.pContainer2.Controls.Add(frm2);
            frm2.Show();
            frm.Hide();
            frm3.Hide();
            frm4.Hide();
            frm5.Hide();
            frm6.Hide();
        }
    }
}