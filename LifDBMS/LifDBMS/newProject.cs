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
    public partial class newProject : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private DataTable dt;

        Koneksi Konn = new Koneksi();
        public newProject()
        {
            InitializeComponent();
        }

        private void saveMoMFile(string filePath, string alias)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                var file = new FileInfo(filePath);
                string extn = file.Extension;
                string name = file.Name;
                string query = "INSERT INTO MoM VALUES ('" + textBox14.Text + "', '" + textBox11.Text + "', '" + textBox13.Text + "', (SELECT * FROM OPENROWSET(BULK N'" + filePath + "', SINGLE_BLOB) AS " + alias + "), '" + txtFilePath.Text + "', '" + alias + "', '" + name + "', '" + extn + "', '" + textBox8.Text + "');";
                using (SqlConnection cn = Konn.GetConn())
                {
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@data", SqlDbType.VarBinary).Value = buffer;
                    cmd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        private void saveProject_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("INSERT INTO Project VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox12.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    loadData();


                    cmd = new SqlCommand("INSERT INTO Meeting VALUES ('" + textBox11.Text + "', '" + textBox1.Text + "', '" + textBox10.Text + "', '" + textBox9.Text + "', '" + textBox7.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    loadData();


                    saveMoMFile(txtFilePath.Text, aliasFile.Text);
                    loadData();

                    conn.Close();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }

            MessageBox.Show("Project Has Been Saved");
        }
        private void loadData()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM Project", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Project");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Project";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable GetData(string sqlCommand)
        {

            SqlConnection conn = Konn.GetConn();

            SqlCommand command = new SqlCommand(sqlCommand, conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            return table;
        }
        private BindingSource bindingSource1 = new BindingSource();
        private void newProject_Load(object sender, EventArgs e)
        {
            loadData();
            bindingSource1.DataSource = GetData("SELECT * FROM Company");
            dataGridView2.DataSource = bindingSource1;

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox22.Text = row.Cells["ComID"].Value.ToString();
                textBox2.Text = row.Cells["ComID"].Value.ToString();
                textBox21.Text = row.Cells["CompanyName"].Value.ToString();
                textBox20.Text = row.Cells["EmployeeAmount"].Value.ToString();
                textBox19.Text = row.Cells["Email"].Value.ToString();
                textBox16.Text = row.Cells["Phone"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void DeleteComp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data Company dengan kode: " + textBox22.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Company WHERE ComID = '" + textBox22.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Data Berhasil");
                    bindingSource1.DataSource = GetData("SELECT * FROM Company");
                    dataGridView2.DataSource = bindingSource1;
                    textBox22.Text = "";
                    textBox21.Text = "";
                    textBox20.Text = "";
                    textBox19.Text = "";
                    textBox16.Text = "";
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("UPDATE Company SET CompanyName ='" + textBox21.Text + "', EmployeeAmount ='" + textBox20.Text + "', Email ='" + textBox19.Text + "',  Phone ='" + textBox16.Text + "' WHERE ComID = '" + textBox22.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Data Berhasil");
                    bindingSource1.DataSource = GetData("SELECT * FROM Company");
                    dataGridView2.DataSource = bindingSource1;
                    textBox22.Text = "";
                    textBox21.Text = "";
                    textBox20.Text = "";
                    textBox19.Text = "";
                    textBox16.Text = "";
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("INSERT INTO Company VALUES ('" + textBox22.Text + "', '" + textBox21.Text + "', '" + textBox20.Text + "', '" + textBox19.Text + "', '" + textBox16.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert Data Berhasil");
                    bindingSource1.DataSource = GetData("SELECT * FROM Company");
                    dataGridView2.DataSource = bindingSource1;
                    textBox22.Text = "";
                    textBox21.Text = "";
                    textBox20.Text = "";
                    textBox19.Text = "";
                    textBox16.Text = "";

                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox22.Text = "";
            textBox21.Text = "";
            textBox20.Text = "";
            textBox19.Text = "";
            textBox16.Text = "";
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM Company WHERE ComID = '" + textBox6.Text + "'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                //dataGridView1.DataMember = "Project";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void refBtnSearch_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = GetData("SELECT * FROM Project");
            dataGridView2.DataSource = bindingSource1;
        }

        private void meRefresh_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox7.Text = "";
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void moRefresh_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            textBox13.Text = "";
            aliasFile.Text = "";
            txtFilePath.Text = "";
            textBox8.Text = "";
        }

        private void MoMBrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txtFilePath.Text = dlg.FileName;
        }
    }
}
