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
    public partial class Transactions : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private DataTable dt;

        Koneksi Konn = new Koneksi();
        public Transactions()
        {
            InitializeComponent();
        }
        private void loadTrans()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM [Transaction]", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "[Transaction]");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "[Transaction]";
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

        private void loadPayment()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT PaymentID, TransactionID, PaymentMethod, AmountPaid, PaymentDate, FileName, Alias, Path, Extension FROM Payment", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Payment");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Payment";
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void loadAll()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT a.TransactionID, ProjectID, StartDate, DueDate, AgreedPrice, Status, PaymentID, PaymentMethod, AmountPaid, PaymentDate, [FileName], Alias, Path, Extension FROM [Transaction] a JOIN Payment b ON a.TransactionID = b.TransactionID", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                //dataGridView1.DataMember = "Project";
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void loadMaster()
        {
            loadAll();
            loadPayment();
            loadTrans();
        }
        private void Transactions_Load(object sender, EventArgs e)
        {
            loadAll();
            loadPayment();
            loadTrans();
        }

        private void transSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("INSERT INTO [Transaction] VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert Data Berhasil");
                    loadMaster();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void transDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data: " + textBox1.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE [Transaction] WHERE TransactionID = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Data Berhasil");
                    loadMaster();
                }
            }
        }

        private void transUpdate_Click(object sender, EventArgs e)
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
                    cmd = new SqlCommand("UPDATE [Transaction] SET ProjectID ='" + textBox2.Text + "', StartDate ='" + textBox3.Text + "', DueDate ='" + textBox4.Text + "',  AgreedPrice ='" + textBox5.Text + "' , Status = '" + textBox6.Text + "' WHERE TransactionID= '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Data Berhasil");
                    loadMaster();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void transClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void savePaymentProof(string filePath, string alias)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                var file = new FileInfo(filePath);
                string extn = file.Extension;
                string name = file.Name;
                string query = "INSERT INTO Payment VALUES ('" + textBox12.Text + "', '" + textBox11.Text + "', '" + textBox10.Text + "', '" + textBox9.Text + ", (SELECT * FROM OPENROWSET(BULK N'" + filePath + "', SINGLE_BLOB) AS " + alias + "), '" + txtFilePath.Text + "', '" + alias + "', '" + name + "', '" + extn + "');";
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

        private void paymentSave_Click(object sender, EventArgs e)
        {
            if (textBox12.Text.Trim() == "" || textBox11.Text.Trim() == "" || textBox10.Text.Trim() == "" || txtFilePath.Text.Trim() == "" || textBox9.Text.Trim() == "" || textBox8.Text.Trim() == "" || aliasFile.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    savePaymentProof(txtFilePath.Text, aliasFile.Text);
                    MessageBox.Show("Insert Data Berhasil");
                    loadMaster();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void paymentDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data payment dengan kode: " + textBox12.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Payment WHERE PaymentID = '" + textBox12.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Data Berhasil");
                    textBox12.Text = "";
                    textBox11.Text = "";
                    aliasFile.Text = "";
                    txtFilePath.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox8.Text = "";
                    loadMaster();
                }
            }
        }

        private void paymentUpdate_Click(object sender, EventArgs e)
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
                    cmd = new SqlCommand("UPDATE Payment SET TransactionID = '" + textBox11.Text + "', PaymentMethod = '" + textBox10.Text + "', AmountPaid = '" + textBox9.Text + "', PaymentDate = '" + textBox8.Text + "', PaymentProof = (SELECT * FROM OPENROWSET(BULK N'" + txtFilePath.Text + "', SINGLE_BLOB) AS " + aliasFile.Text + "), Path = '" + txtFilePath.Text + "', Alias = '" + aliasFile.Text + "', FileName = '" + name + "', Extension = '" + extn + "' WHERE PaymentID = '" + textBox12.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Data Berhasil");
                    loadMaster();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());

                }
            }
        }

        private void paymentClear_Click(object sender, EventArgs e)
        {
            textBox12.Text = "";
            textBox11.Text = "";
            aliasFile.Text = "";
            txtFilePath.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txtFilePath.Text = dlg.FileName;
        }
        private void openPayment(string id)
        {
            using (SqlConnection cn = Konn.GetConn())
            {
                String query = "SELECT PaymentProof, FileName, Extension FROM Payment WHERE PaymentID = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("PaymentID", SqlDbType.VarChar).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["FileName"].ToString();
                    var data = (byte[])reader["PaymentProof"];
                    var extn = reader["Extension"].ToString();
                    var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                    File.WriteAllBytes(newFileName, data);
                    System.Diagnostics.Process.Start(new ProcessStartInfo(newFileName) { UseShellExecute = true });
                }
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView2.SelectedRows;
            foreach (var row in selectedRow)
            {
                //string id = (string)((DataGridViewRow)row).Cells[0].Value;
                string id = textBox12.Text;
                openPayment(id);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["TransactionID"].Value.ToString();
            textBox2.Text = row.Cells["ProjectID"].Value.ToString();
            textBox3.Text = row.Cells["StartDate"].Value.ToString();
            textBox4.Text = row.Cells["DueDate"].Value.ToString();
            textBox5.Text = row.Cells["AgreedPrice"].Value.ToString();
            textBox6.Text = row.Cells["Status"].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            textBox12.Text = row.Cells["PaymentID"].Value.ToString();
            textBox11.Text = row.Cells["TransactionID"].Value.ToString();
            textBox10.Text = row.Cells["PaymentMethod"].Value.ToString();
            textBox9.Text = row.Cells["AmountPaid"].Value.ToString();
            textBox8.Text = row.Cells["PaymentDate"].Value.ToString();
            txtFilePath.Text = row.Cells["Path"].Value.ToString();
            aliasFile.Text = row.Cells["Alias"].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
            textBox1.Text = row.Cells["TransactionID"].Value.ToString();
            textBox2.Text = row.Cells["ProjectID"].Value.ToString();
            textBox3.Text = row.Cells["StartDate"].Value.ToString();
            textBox4.Text = row.Cells["DueDate"].Value.ToString();
            textBox5.Text = row.Cells["AgreedPrice"].Value.ToString();
            textBox6.Text = row.Cells["Status"].Value.ToString();
            textBox12.Text = row.Cells["PaymentID"].Value.ToString();
            textBox11.Text = row.Cells["TransactionID"].Value.ToString();
            textBox10.Text = row.Cells["PaymentMethod"].Value.ToString();
            textBox9.Text = row.Cells["AmountPaid"].Value.ToString();
            textBox8.Text = row.Cells["PaymentDate"].Value.ToString();
            txtFilePath.Text = row.Cells["Path"].Value.ToString();
            aliasFile.Text = row.Cells["Alias"].Value.ToString();
        }
    }
}
