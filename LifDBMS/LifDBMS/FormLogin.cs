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
using System.IO;
using System.Diagnostics;

namespace LifDBMS
{
    public partial class FormLogin : Form
    {
        public static string userName = "";
        public static string SenduserName = "";
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        Koneksi Konn = new Koneksi();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            userName = userTxt.Text;
            SqlDataReader reader = null;
            SqlConnection conn = Konn.GetConn();
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM EmployeeProfile WHERE Username = '" + userTxt.Text + "' AND Password = '" + passwordTxt.Text + "'", conn);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    SenduserName = getUser(userName);
                    FormDashboard frmDash = new FormDashboard();
                    frmDash.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User Invalid");
                }
            }
        }

        public string getUser(string username)
        {
            string sendUser = username;
            return sendUser;
        }
    }
}
