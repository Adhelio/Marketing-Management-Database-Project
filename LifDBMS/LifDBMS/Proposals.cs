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
    public partial class Proposals : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        Koneksi Konn = new Koneksi();
        public Proposals()
        {
            InitializeComponent();
        }
        void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            aliasFile.Text = "";
            txtFilePath.Text = "";
            textBox5.Text = "";
        }
        void TampilTabel()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT ProposalID, ProjectID, ProposalDate, FileName, Alias, Path, Extension, Description FROM Proposal", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Proposal");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Proposal";
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

        private void Proposals_Load(object sender, EventArgs e)
        {
            TampilTabel();
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
                string query = "INSERT INTO Proposal VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', (SELECT * FROM OPENROWSET(BULK N'" + filePath + "', SINGLE_BLOB) AS " + alias + "), '" + txtFilePath.Text + "', '" + alias + "', '" + name + "', '" + extn + "', '" + textBox5.Text + "');";
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

        private void button1_Click(object sender, EventArgs e)
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
                    saveProposalFile(txtFilePath.Text, aliasFile.Text);
                    MessageBox.Show("Insert Data Berhasil");
                    Clear();
                    TampilTabel();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txtFilePath.Text = dlg.FileName;
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

        private void openButton_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows;
            foreach (var row in selectedRow)
            {
                string id = (string)((DataGridViewRow)row).Cells[0].Value;
                openProposalFile(id);
            }
        }
        private void searchFeat()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand(" SELECT ProjectID, ProposalID, ProposalDate, FileName, Extension, Description FROM Proposal WHERE ProposalID LIKE '%" + searchBar.Text + "%'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Proposal");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Proposal";
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

        private void button2_Click(object sender, EventArgs e)
        {
            searchFeat();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TampilTabel();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ProposalID"].Value.ToString();
                textBox2.Text = row.Cells["ProjectID"].Value.ToString();
                textBox3.Text = row.Cells["ProposalDate"].Value.ToString();
                aliasFile.Text = row.Cells["Alias"].Value.ToString();
                txtFilePath.Text = row.Cells["Path"].Value.ToString();
                textBox5.Text = row.Cells["Description"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void updateButton_Click(object sender, EventArgs e)
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
                    cmd = new SqlCommand("UPDATE Proposal SET ProjectID = '" + textBox2.Text + "', ProposalDate = '" + textBox3.Text + "', ProposalFile = (SELECT * FROM OPENROWSET(BULK N'" + txtFilePath.Text + "', SINGLE_BLOB) AS " + aliasFile.Text + "), Path = '" + txtFilePath.Text + "', Alias = '" + aliasFile.Text + "', FileName = '" + name + "', Extension = '" + extn + "', Description = '" + textBox5.Text + "' WHERE ProposalID = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Data Berhasil");
                    Clear();
                    TampilTabel();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data proposal dengan kode: " + textBox1.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Proposal WHERE ProposalID = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Data Berhasil");
                    TampilTabel();
                }
            }
        }
    }
}

