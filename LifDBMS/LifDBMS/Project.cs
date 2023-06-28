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
    public partial class Project : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private DataTable dt;

        Koneksi Konn = new Koneksi();
        public Project()
        {
            InitializeComponent();
        }

        private void loadFinish()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT a.ProjectID, a.ComID, a.LifID, a.ProjectName, COUNT(b.MeetingID) as TotalMeetings, COUNT(c.MomID) AS TotalMoMs, d.ProposalID, a.Description, Status " +
                    "FROM Project a JOIN Meeting b " +
                    "ON b.ProjectiD = a.ProjectID " +
                    "JOIN MoM c ON b.MeetingID = c.MeetingID" + " JOIN Proposal d ON d.ProjectID = a.ProjectID " +
                    "GROUP BY  a.ProjectID, a.ComID, a.LifID, a.ProjectName, a.Description, Status, ProposalID", conn);
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
                dataGridView6.DataSource = ds;
                dataGridView6.DataMember = "Project";
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

        private void Project_Load(object sender, EventArgs e)
        {
            loadData();
            loadFinish();
        }

        private BindingSource bindingSource1 = new BindingSource();
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

        private BindingSource bindingSource4 = new BindingSource();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ProjectID"].Value.ToString();
                textBox2.Text = row.Cells["ComID"].Value.ToString();
                textBox3.Text = row.Cells["LifID"].Value.ToString();
                textBox4.Text = row.Cells["ProjectName"].Value.ToString();
                textBox5.Text = row.Cells["Description"].Value.ToString();
                textBox12.Text = row.Cells["Status"].Value.ToString();
                bindingSource1.DataSource = GetData("SELECT MeetingID, MeetingDate, Link, Description FROM Meeting WHERE ProjectID = '" + textBox1.Text + "'");
                dataGridView2.DataSource = bindingSource1;
                bindingSource3.DataSource = GetData("SELECT ProposalID, ProposalDate, FileName, Alias, Path, Extension, Description FROM Proposal WHERE ProjectID = '" + textBox1.Text + "'");
                dataGridView4.DataSource = bindingSource3;
                bindingSource4.DataSource = GetData("SELECT a.ComID, CompanyName, EmployeeAmount, Email, Phone FROM project a JOIN Company b ON a.ComID = b.ComID WHERE ProjectID = '" + textBox1.Text + "'");
                dataGridView5.DataSource = bindingSource4;
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
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
                    cmd = new SqlCommand("UPDATE Project SET  ComID = '" + textBox2.Text + "', LifID ='" + textBox3.Text + "', ProjectName ='" + textBox4.Text + "', Description ='" + textBox5.Text + "',  Status ='" + textBox12.Text + "' WHERE ProjectID = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Data Berhasil");
                    loadData();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private BindingSource bindingSource2 = new BindingSource();
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox11.Text = row.Cells["MeetingID"].Value.ToString();
                textBox10.Text = row.Cells["MeetingDate"].Value.ToString();
                textBox9.Text = row.Cells["Link"].Value.ToString();
                textBox7.Text = row.Cells["Description"].Value.ToString();
                bindingSource2.DataSource = GetData("SELECT MomID, MomDate, FileName, Alias, Path, Extension, Description FROM MoM WHERE MeetingID = '" + textBox11.Text + "'");
                dataGridView3.DataSource = bindingSource2;
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private BindingSource bindingSource3 = new BindingSource();
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                textBox14.Text = row.Cells["MomID"].Value.ToString();
                textBox13.Text = row.Cells["MomDate"].Value.ToString();
                aliasFile.Text = row.Cells["Alias"].Value.ToString();
                txtFilePath.Text = row.Cells["Path"].Value.ToString();
                textBox8.Text = row.Cells["Description"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void meUpdate_Click(object sender, EventArgs e)
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
                    cmd = new SqlCommand("UPDATE Meeting SET ProjectID ='" + textBox1.Text + "', MeetingDate ='" + textBox10.Text + "', Link ='" + textBox9.Text + "',  Description ='" + textBox7.Text + "' WHERE MeetingID= '" + textBox11.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Data Berhasil");
                    bindingSource1.DataSource = GetData("SELECT MeetingID, MeetingDate, Link, Description FROM Meeting WHERE ProjectID = '" + textBox1.Text + "'");
                    dataGridView2.DataSource = bindingSource1;
                    textBox11.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox7.Text = "";
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void meDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data meeting dengan kode: " + textBox11.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Meeting WHERE MeetingID = '" + textBox11.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Data Berhasil");
                    bindingSource1.DataSource = GetData("SELECT MeetingID, MeetingDate, Link, Description FROM Meeting WHERE ProjectID = '" + textBox1.Text + "'");
                    dataGridView2.DataSource = bindingSource1;
                    textBox11.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox7.Text = "";
                }
            }
        }

        private void MoMBrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txtFilePath.Text = dlg.FileName;
        }

        private void MoUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || txtFilePath.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    Stream stream = File.OpenRead(txtFilePath.Text);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    var file = new FileInfo(txtFilePath.Text);
                    string extn = file.Extension;
                    string name = file.Name;
                    cmd = new SqlCommand("UPDATE MoM SET MeetingID = '" + textBox11.Text + "', MomDate = '" + textBox13.Text + "', MomFile = (SELECT * FROM OPENROWSET(BULK N'" + txtFilePath.Text + "', SINGLE_BLOB) AS " + aliasFile.Text + "), Path = '" + txtFilePath.Text + "', Alias = '" + aliasFile.Text + "', FileName = '" + name + "', Extension = '" + extn + "', Description = '" + textBox8.Text + "' WHERE MomID = '" + textBox14.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Data Berhasil");
                    textBox14.Text = "";
                    textBox13.Text = "";
                    aliasFile.Text = "";
                    txtFilePath.Text = "";
                    textBox8.Text = "";
                    bindingSource2.DataSource = GetData("SELECT MomID, MomDate, FileName, Alias, Path, Extension, Description FROM MoM WHERE MeetingID = '" + textBox11.Text + "'");
                    dataGridView3.DataSource = bindingSource2;
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void MoDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data MoM dengan kode: " + textBox14.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE MoM WHERE MoMID = '" + textBox14.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Data Berhasil");
                    textBox14.Text = "";
                    textBox13.Text = "";
                    aliasFile.Text = "";
                    txtFilePath.Text = "";
                    textBox8.Text = "";
                    bindingSource2.DataSource = GetData("SELECT MomID, MomDate, FileName, Alias, Path, Extension, Description FROM MoM WHERE MeetingID = '" + textBox11.Text + "'");
                    dataGridView3.DataSource = bindingSource2;
                }
            }
        }

        private void openMoMFile(string id)
        {
            using (SqlConnection cn = Konn.GetConn())
            {
                String query = "SELECT MomFile, FileName, Extension FROM MoM WHERE MomID = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("MomID", SqlDbType.VarChar).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["FileName"].ToString();
                    var data = (byte[])reader["MomFile"];
                    var extn = reader["Extension"].ToString();
                    var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                    File.WriteAllBytes(newFileName, data);
                    System.Diagnostics.Process.Start(new ProcessStartInfo(newFileName) { UseShellExecute = true });
                }
            }
        }
        private void openMo_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView3.SelectedRows;
            foreach (var row in selectedRow)
            {
                //string id = (string)((DataGridViewRow)row).Cells[0].Value;
                string id = textBox14.Text;
                openMoMFile(id);
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                textBox18.Text = row.Cells["ProposalID"].Value.ToString();
                textBox17.Text = row.Cells["ProposalDate"].Value.ToString();
                aliasFilePro.Text = row.Cells["Alias"].Value.ToString();
                txtFilePathPro.Text = row.Cells["Path"].Value.ToString();
                textBox15.Text = row.Cells["Description"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void proUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || txtFilePath.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    Stream stream = File.OpenRead(txtFilePathPro.Text);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    var file = new FileInfo(txtFilePathPro.Text);
                    string extn = file.Extension;
                    string name = file.Name;
                    cmd = new SqlCommand("UPDATE Proposal SET ProjectID = '" + textBox1.Text + "', ProposalDate = '" + textBox17.Text + "', ProposalFile = (SELECT * FROM OPENROWSET(BULK N'" + txtFilePathPro.Text + "', SINGLE_BLOB) AS " + aliasFilePro.Text + "), Path = '" + txtFilePathPro.Text + "', Alias = '" + aliasFilePro.Text + "', FileName = '" + name + "', Extension = '" + extn + "', Description = '" + textBox15.Text + "' WHERE ProposalID = '" + textBox18.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Data Berhasil");
                    textBox18.Text = "";
                    textBox17.Text = "";
                    aliasFilePro.Text = "";
                    txtFilePathPro.Text = "";
                    textBox15.Text = "";
                    bindingSource3.DataSource = GetData("SELECT ProposalID, ProposalDate, FileName, Alias, Path, Extension, Description FROM Proposal WHERE ProjectID = '" + textBox1.Text + "'");
                    dataGridView4.DataSource = bindingSource3;
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }
        private void openProposalFile(string id)
        {
            using (SqlConnection cn = Konn.GetConn())
            {
                String query = "SELECT ProposalFile, FileName, Extension FROM Proposal WHERE ProposalID = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("ProposalID", SqlDbType.VarChar).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["FileName"].ToString();
                    var data = (byte[])reader["ProposalFile"];
                    var extn = reader["Extension"].ToString();
                    var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                    File.WriteAllBytes(newFileName, data);
                    System.Diagnostics.Process.Start(new ProcessStartInfo(newFileName) { UseShellExecute = true });
                }
            }
        }
        private void openPro_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView4.SelectedRows;
            foreach (var row in selectedRow)
            {
                //string id = (string)((DataGridViewRow)row).Cells[0].Value;
                string id = textBox18.Text;
                openProposalFile(id);
            }
        }

        private void ProBrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txtFilePathPro.Text = dlg.FileName;
        }

        private void meRefresh_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox7.Text = "";
        }

        private void moRefresh_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            textBox13.Text = "";
            aliasFile.Text = "";
            txtFilePath.Text = "";
            textBox8.Text = "";
        }

        private void proRefresh_Click(object sender, EventArgs e)
        {
            textBox18.Text = "";
            textBox17.Text = "";
            aliasFilePro.Text = "";
            txtFilePathPro.Text = "";
            textBox15.Text = "";
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT a.ProjectID, a.ComID, a.LifID, a.ProjectName, COUNT(b.MeetingID) as TotalMeetings, COUNT(c.MomID) AS TotalMoMs, d.ProposalID, a.Description, Status " +
                    "FROM Project a JOIN Meeting b " +
                    "ON b.ProjectiD = a.ProjectID " +
                    "JOIN MoM c ON b.MeetingID = c.MeetingID" + " JOIN Proposal d ON d.ProjectID = a.ProjectID WHERE a.ProjectID = '" + textBox6.Text +
                    "' GROUP BY  a.ProjectID, a.ComID, a.LifID, a.ProjectName, a.Description, Status, ProposalID", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                //dataGridView1.DataMember = "Project";
                dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            loadData();
            loadFinish();
        }

        private void SaveMeBtn_Click(object sender, EventArgs e)
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
                    cmd = new SqlCommand("INSERT INTO Meeting VALUES ('" + textBox11.Text + "', '" + textBox1.Text + "', '" + textBox10.Text + "', '" + textBox9.Text + "', '" + textBox7.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert Data Berhasil");
                    bindingSource1.DataSource = GetData("SELECT MeetingID, MeetingDate, Link, Description FROM Meeting WHERE ProjectID = '" + textBox1.Text + "'");
                    dataGridView2.DataSource = bindingSource1;
                    textBox11.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox7.Text = "";

                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
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
        private void MoSaveBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || txtFilePath.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    saveMoMFile(txtFilePath.Text, aliasFile.Text);
                    MessageBox.Show("Insert Data Berhasil");
                    textBox14.Text = "";
                    textBox13.Text = "";
                    aliasFile.Text = "";
                    txtFilePath.Text = "";
                    textBox8.Text = "";
                    bindingSource2.DataSource = GetData("SELECT MomID, MomDate, FileName, Alias, Path, Extension, Description FROM MoM WHERE MeetingID = '" + textBox11.Text + "'");
                    dataGridView3.DataSource = bindingSource2;
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }
        private void saveProposalFile(string filePath, string alias)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                var file = new FileInfo(filePath);
                string extn = file.Extension;
                string name = file.Name;
                string query = "INSERT INTO Proposal VALUES ('" + textBox18.Text + "', '" + textBox1.Text + "', '" + textBox17.Text + "', (SELECT * FROM OPENROWSET(BULK N'" + filePath + "', SINGLE_BLOB) AS " + alias + "), '" + txtFilePathPro.Text + "', '" + alias + "', '" + name + "', '" + extn + "', '" + textBox15.Text + "');";
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
        private void SaveProBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || txtFilePath.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    saveProposalFile(txtFilePathPro.Text, aliasFilePro.Text);
                    MessageBox.Show("Insert Data Berhasil");
                    textBox18.Text = "";
                    textBox17.Text = "";
                    aliasFilePro.Text = "";
                    txtFilePathPro.Text = "";
                    textBox15.Text = "";
                    bindingSource3.DataSource = GetData("SELECT ProposalID, ProposalDate, FileName, Alias, Path, Extension, Description FROM Proposal WHERE ProjectID = '" + textBox1.Text + "'");
                    dataGridView4.DataSource = bindingSource3;
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void proDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data proposal dengan kode: " + textBox18.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Proposal WHERE ProposalID = '" + textBox18.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Data Berhasil");
                    textBox18.Text = "";
                    textBox17.Text = "";
                    aliasFilePro.Text = "";
                    txtFilePathPro.Text = "";
                    textBox15.Text = "";
                    bindingSource3.DataSource = GetData("SELECT ProposalID, ProposalDate, FileName, Alias, Path, Extension, Description FROM Proposal WHERE ProjectID = '" + textBox1.Text + "'");
                    dataGridView4.DataSource = bindingSource3;
                }
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
                textBox22.Text = row.Cells["ComID"].Value.ToString();
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

        private void saveComp_Click(object sender, EventArgs e)
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
                    cmd = new SqlCommand("INSERT INTO Meeting VALUES ('" + textBox22.Text + "', '" + textBox21.Text + "', '" + textBox20.Text + "', '" + textBox19.Text + "', '" + textBox16.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert Data Berhasil");
                    bindingSource4.DataSource = GetData("SELECT a.ComID, CompanyName, EmployeeAmount, Email, Phone FROM project a JOIN Company b ON a.ComID = b.ComID WHERE ProjectID = '" + textBox1.Text + "'");
                    dataGridView5.DataSource = bindingSource4;
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

        private void updateComp_Click(object sender, EventArgs e)
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
                    bindingSource4.DataSource = GetData("SELECT a.ComID, CompanyName, EmployeeAmount, Email, Phone FROM project a JOIN Company b ON a.ComID = b.ComID WHERE ProjectID = '" + textBox1.Text + "'");
                    dataGridView5.DataSource = bindingSource4;
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
                    bindingSource4.DataSource = GetData("SELECT a.ComID, CompanyName, EmployeeAmount, Email, Phone FROM project a JOIN Company b ON a.ComID = b.ComID WHERE ProjectID = '" + textBox1.Text + "'");
                    dataGridView5.DataSource = bindingSource4;
                    textBox22.Text = "";
                    textBox21.Text = "";
                    textBox20.Text = "";
                    textBox19.Text = "";
                    textBox16.Text = "";
                }
            }
        }

        private void CompRefresh_Click(object sender, EventArgs e)
        {
            textBox22.Text = "";
            textBox21.Text = "";
            textBox20.Text = "";
            textBox19.Text = "";
            textBox16.Text = "";
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            newProject openForm = new newProject();
            openForm.ShowDialog();
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView6.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ProjectID"].Value.ToString();
                textBox2.Text = row.Cells["ComID"].Value.ToString();
                textBox3.Text = row.Cells["LifID"].Value.ToString();
                textBox4.Text = row.Cells["ProjectName"].Value.ToString();
                textBox5.Text = row.Cells["Description"].Value.ToString();
                textBox12.Text = row.Cells["Status"].Value.ToString();
                bindingSource1.DataSource = GetData("SELECT MeetingID, MeetingDate, Link, Description FROM Meeting WHERE ProjectID = '" + textBox1.Text + "'");
                dataGridView2.DataSource = bindingSource1;
                bindingSource3.DataSource = GetData("SELECT ProposalID, ProposalDate, FileName, Alias, Path, Extension, Description FROM Proposal WHERE ProjectID = '" + textBox1.Text + "'");
                dataGridView4.DataSource = bindingSource3;
                bindingSource4.DataSource = GetData("SELECT a.ComID, CompanyName, EmployeeAmount, Email, Phone FROM project a JOIN Company b ON a.ComID = b.ComID WHERE ProjectID = '" + textBox1.Text + "'");
                dataGridView5.DataSource = bindingSource4;
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data project dengan kode: " + textBox1.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Project WHERE ProjectID = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Data Berhasil");
                    loadData();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox12.Text = "";
                }
            }
        }
    }
}