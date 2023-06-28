
namespace LifDBMS
{
    partial class Transactions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openBtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.paymentClear = new System.Windows.Forms.Button();
            this.paymentUpdate = new System.Windows.Forms.Button();
            this.paymentDel = new System.Windows.Forms.Button();
            this.paymentSave = new System.Windows.Forms.Button();
            this.transClear = new System.Windows.Forms.Button();
            this.transUpdate = new System.Windows.Forms.Button();
            this.transDel = new System.Windows.Forms.Button();
            this.transSave = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aliasFile = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openBtn
            // 
            this.openBtn.BackColor = System.Drawing.Color.LightGreen;
            this.openBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.openBtn.Location = new System.Drawing.Point(1266, 392);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 76;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = false;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.browseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.browseBtn.Location = new System.Drawing.Point(1318, 565);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(23, 23);
            this.browseBtn.TabIndex = 75;
            this.browseBtn.Text = "...";
            this.browseBtn.UseVisualStyleBackColor = false;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(37, 371);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 25;
            this.dataGridView3.Size = new System.Drawing.Size(998, 305);
            this.dataGridView3.TabIndex = 74;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            // 
            // paymentClear
            // 
            this.paymentClear.BackColor = System.Drawing.Color.LightBlue;
            this.paymentClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.paymentClear.Location = new System.Drawing.Point(1266, 624);
            this.paymentClear.Name = "paymentClear";
            this.paymentClear.Size = new System.Drawing.Size(75, 23);
            this.paymentClear.TabIndex = 73;
            this.paymentClear.Text = "Clear";
            this.paymentClear.UseVisualStyleBackColor = false;
            this.paymentClear.Click += new System.EventHandler(this.paymentClear_Click);
            // 
            // paymentUpdate
            // 
            this.paymentUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(151)))), ((int)(((byte)(81)))));
            this.paymentUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.paymentUpdate.Location = new System.Drawing.Point(1064, 624);
            this.paymentUpdate.Name = "paymentUpdate";
            this.paymentUpdate.Size = new System.Drawing.Size(75, 23);
            this.paymentUpdate.TabIndex = 72;
            this.paymentUpdate.Text = "Update";
            this.paymentUpdate.UseVisualStyleBackColor = false;
            this.paymentUpdate.Click += new System.EventHandler(this.paymentUpdate_Click);
            // 
            // paymentDel
            // 
            this.paymentDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.paymentDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentDel.ForeColor = System.Drawing.Color.Maroon;
            this.paymentDel.Location = new System.Drawing.Point(1064, 653);
            this.paymentDel.Name = "paymentDel";
            this.paymentDel.Size = new System.Drawing.Size(75, 23);
            this.paymentDel.TabIndex = 71;
            this.paymentDel.Text = "Delete";
            this.paymentDel.UseVisualStyleBackColor = false;
            this.paymentDel.Click += new System.EventHandler(this.paymentDel_Click);
            // 
            // paymentSave
            // 
            this.paymentSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(193)))));
            this.paymentSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.paymentSave.Location = new System.Drawing.Point(1145, 624);
            this.paymentSave.Name = "paymentSave";
            this.paymentSave.Size = new System.Drawing.Size(75, 52);
            this.paymentSave.TabIndex = 70;
            this.paymentSave.Text = "Save";
            this.paymentSave.UseVisualStyleBackColor = false;
            this.paymentSave.Click += new System.EventHandler(this.paymentSave_Click);
            // 
            // transClear
            // 
            this.transClear.BackColor = System.Drawing.Color.LightBlue;
            this.transClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.transClear.Location = new System.Drawing.Point(1266, 279);
            this.transClear.Name = "transClear";
            this.transClear.Size = new System.Drawing.Size(75, 23);
            this.transClear.TabIndex = 69;
            this.transClear.Text = "Clear";
            this.transClear.UseVisualStyleBackColor = false;
            this.transClear.Click += new System.EventHandler(this.transClear_Click);
            // 
            // transUpdate
            // 
            this.transUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(151)))), ((int)(((byte)(81)))));
            this.transUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.transUpdate.Location = new System.Drawing.Point(1064, 279);
            this.transUpdate.Name = "transUpdate";
            this.transUpdate.Size = new System.Drawing.Size(75, 23);
            this.transUpdate.TabIndex = 68;
            this.transUpdate.Text = "Update";
            this.transUpdate.UseVisualStyleBackColor = false;
            this.transUpdate.Click += new System.EventHandler(this.transUpdate_Click);
            // 
            // transDel
            // 
            this.transDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.transDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transDel.ForeColor = System.Drawing.Color.Maroon;
            this.transDel.Location = new System.Drawing.Point(1064, 308);
            this.transDel.Name = "transDel";
            this.transDel.Size = new System.Drawing.Size(75, 23);
            this.transDel.TabIndex = 67;
            this.transDel.Text = "Delete";
            this.transDel.UseVisualStyleBackColor = false;
            this.transDel.Click += new System.EventHandler(this.transDel_Click);
            // 
            // transSave
            // 
            this.transSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(201)))), ((int)(((byte)(193)))));
            this.transSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.transSave.Location = new System.Drawing.Point(1145, 279);
            this.transSave.Name = "transSave";
            this.transSave.Size = new System.Drawing.Size(75, 52);
            this.transSave.TabIndex = 66;
            this.transSave.Text = "Save";
            this.transSave.UseVisualStyleBackColor = false;
            this.transSave.Click += new System.EventHandler(this.transSave_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(555, 105);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(480, 226);
            this.dataGridView2.TabIndex = 65;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(480, 226);
            this.dataGridView1.TabIndex = 64;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // aliasFile
            // 
            this.aliasFile.Location = new System.Drawing.Point(1064, 595);
            this.aliasFile.Name = "aliasFile";
            this.aliasFile.PlaceholderText = "Alias";
            this.aliasFile.Size = new System.Drawing.Size(277, 23);
            this.aliasFile.TabIndex = 63;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(1064, 566);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.PlaceholderText = "Payment Proof";
            this.txtFilePath.Size = new System.Drawing.Size(248, 23);
            this.txtFilePath.TabIndex = 62;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(1064, 537);
            this.textBox8.Name = "textBox8";
            this.textBox8.PlaceholderText = "Payment Date";
            this.textBox8.Size = new System.Drawing.Size(277, 23);
            this.textBox8.TabIndex = 61;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(1064, 508);
            this.textBox9.Name = "textBox9";
            this.textBox9.PlaceholderText = "Amount Paid";
            this.textBox9.Size = new System.Drawing.Size(277, 23);
            this.textBox9.TabIndex = 60;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(1064, 479);
            this.textBox10.Name = "textBox10";
            this.textBox10.PlaceholderText = "Payment Method";
            this.textBox10.Size = new System.Drawing.Size(277, 23);
            this.textBox10.TabIndex = 59;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(1064, 450);
            this.textBox11.Name = "textBox11";
            this.textBox11.PlaceholderText = "TransactionID";
            this.textBox11.Size = new System.Drawing.Size(277, 23);
            this.textBox11.TabIndex = 58;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(1064, 421);
            this.textBox12.Name = "textBox12";
            this.textBox12.PlaceholderText = "PaymentID";
            this.textBox12.Size = new System.Drawing.Size(277, 23);
            this.textBox12.TabIndex = 57;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1064, 250);
            this.textBox6.Name = "textBox6";
            this.textBox6.PlaceholderText = "Status";
            this.textBox6.Size = new System.Drawing.Size(277, 23);
            this.textBox6.TabIndex = 56;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1064, 221);
            this.textBox5.Name = "textBox5";
            this.textBox5.PlaceholderText = "Agreed Price";
            this.textBox5.Size = new System.Drawing.Size(277, 23);
            this.textBox5.TabIndex = 55;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1064, 192);
            this.textBox4.Name = "textBox4";
            this.textBox4.PlaceholderText = "Due Date";
            this.textBox4.Size = new System.Drawing.Size(277, 23);
            this.textBox4.TabIndex = 54;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1064, 163);
            this.textBox3.Name = "textBox3";
            this.textBox3.PlaceholderText = "Start Date";
            this.textBox3.Size = new System.Drawing.Size(277, 23);
            this.textBox3.TabIndex = 53;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1064, 134);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "ProjectID";
            this.textBox2.Size = new System.Drawing.Size(277, 23);
            this.textBox2.TabIndex = 52;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1064, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "TransactionID";
            this.textBox1.Size = new System.Drawing.Size(277, 23);
            this.textBox1.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 45);
            this.label1.TabIndex = 181;
            this.label1.Text = "Transactions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.label2.Location = new System.Drawing.Point(1058, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 32);
            this.label2.TabIndex = 182;
            this.label2.Text = "Payments";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LifDBMS.Properties.Resources.transactions_card;
            this.pictureBox1.Location = new System.Drawing.Point(4, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1378, 653);
            this.pictureBox1.TabIndex = 183;
            this.pictureBox1.TabStop = false;
            // 
            // Transactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1382, 709);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.paymentClear);
            this.Controls.Add(this.paymentUpdate);
            this.Controls.Add(this.paymentDel);
            this.Controls.Add(this.paymentSave);
            this.Controls.Add(this.transClear);
            this.Controls.Add(this.transUpdate);
            this.Controls.Add(this.transDel);
            this.Controls.Add(this.transSave);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.aliasFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Transactions";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.Transactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button paymentClear;
        private System.Windows.Forms.Button paymentUpdate;
        private System.Windows.Forms.Button paymentDel;
        private System.Windows.Forms.Button paymentSave;
        private System.Windows.Forms.Button transClear;
        private System.Windows.Forms.Button transUpdate;
        private System.Windows.Forms.Button transDel;
        private System.Windows.Forms.Button transSave;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox aliasFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}