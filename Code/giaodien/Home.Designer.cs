namespace giaodien
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.button1_DangXuat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDuongDan = new System.Windows.Forms.TextBox();
            this.rbMaHoa = new System.Windows.Forms.RadioButton();
            this.rbGiaiMa = new System.Windows.Forms.RadioButton();
            this.tbMatKhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btTim = new System.Windows.Forms.Button();
            this.btThucHien = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lable = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_mahoa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_giaima = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1_DangXuat
            // 
            this.button1_DangXuat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1_DangXuat.Font = new System.Drawing.Font("Times", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_DangXuat.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1_DangXuat.Location = new System.Drawing.Point(412, 323);
            this.button1_DangXuat.Name = "button1_DangXuat";
            this.button1_DangXuat.Size = new System.Drawing.Size(168, 41);
            this.button1_DangXuat.TabIndex = 0;
            this.button1_DangXuat.Text = "Đăng xuất";
            this.button1_DangXuat.UseVisualStyleBackColor = false;
            this.button1_DangXuat.Click += new System.EventHandler(this.button1_DangXuat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(23, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn tệp tin";
            // 
            // tbDuongDan
            // 
            this.tbDuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDuongDan.Location = new System.Drawing.Point(152, 101);
            this.tbDuongDan.Name = "tbDuongDan";
            this.tbDuongDan.Size = new System.Drawing.Size(365, 27);
            this.tbDuongDan.TabIndex = 3;
            // 
            // rbMaHoa
            // 
            this.rbMaHoa.AutoSize = true;
            this.rbMaHoa.Font = new System.Drawing.Font("Times", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMaHoa.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rbMaHoa.Location = new System.Drawing.Point(152, 268);
            this.rbMaHoa.Name = "rbMaHoa";
            this.rbMaHoa.Size = new System.Drawing.Size(96, 27);
            this.rbMaHoa.TabIndex = 6;
            this.rbMaHoa.TabStop = true;
            this.rbMaHoa.Text = "Mã Hoá";
            this.rbMaHoa.UseVisualStyleBackColor = true;
            this.rbMaHoa.CheckedChanged += new System.EventHandler(this.rbMaHoa_CheckedChanged);
            // 
            // rbGiaiMa
            // 
            this.rbGiaiMa.AutoSize = true;
            this.rbGiaiMa.Font = new System.Drawing.Font("Times", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGiaiMa.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rbGiaiMa.Location = new System.Drawing.Point(396, 268);
            this.rbGiaiMa.Name = "rbGiaiMa";
            this.rbGiaiMa.Size = new System.Drawing.Size(98, 27);
            this.rbGiaiMa.TabIndex = 7;
            this.rbGiaiMa.TabStop = true;
            this.rbGiaiMa.Text = "Giải Mã";
            this.rbGiaiMa.UseVisualStyleBackColor = true;
            this.rbGiaiMa.CheckedChanged += new System.EventHandler(this.rbGiaiMa_CheckedChanged);
            // 
            // tbMatKhau
            // 
            this.tbMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatKhau.Location = new System.Drawing.Point(152, 199);
            this.tbMatKhau.Name = "tbMatKhau";
            this.tbMatKhau.PasswordChar = '*';
            this.tbMatKhau.Size = new System.Drawing.Size(215, 27);
            this.tbMatKhau.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(25, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mật Khẩu";
            // 
            // btTim
            // 
            this.btTim.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btTim.Font = new System.Drawing.Font("Times", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTim.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btTim.Location = new System.Drawing.Point(554, 97);
            this.btTim.Name = "btTim";
            this.btTim.Size = new System.Drawing.Size(79, 33);
            this.btTim.TabIndex = 11;
            this.btTim.Text = "Tìm";
            this.btTim.UseVisualStyleBackColor = false;
            this.btTim.Click += new System.EventHandler(this.btTim_Click);
            // 
            // btThucHien
            // 
            this.btThucHien.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btThucHien.Font = new System.Drawing.Font("Times", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThucHien.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btThucHien.Location = new System.Drawing.Point(107, 323);
            this.btThucHien.Name = "btThucHien";
            this.btThucHien.Size = new System.Drawing.Size(120, 41);
            this.btThucHien.TabIndex = 12;
            this.btThucHien.Text = "Thực hiện";
            this.btThucHien.UseVisualStyleBackColor = false;
            this.btThucHien.Click += new System.EventHandler(this.btThucHien_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("ParkAvenue", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(21, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 43);
            this.label3.TabIndex = 13;
            this.label3.Text = "Group_4";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.ForeColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(12, 411);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(59, 10);
            this.progressBar1.TabIndex = 14;
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(152, 149);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(365, 27);
            this.tbEmail.TabIndex = 16;
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Font = new System.Drawing.Font("Times", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lable.Location = new System.Drawing.Point(25, 151);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(58, 23);
            this.lable.TabIndex = 15;
            this.lable.Text = "Email";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_mahoa,
            this.toolStripMenuItem_giaima});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 52);
            // 
            // toolStripMenuItem_mahoa
            // 
            this.toolStripMenuItem_mahoa.Name = "toolStripMenuItem_mahoa";
            this.toolStripMenuItem_mahoa.Size = new System.Drawing.Size(131, 24);
            this.toolStripMenuItem_mahoa.Text = "Mã Hoá";
            // 
            // toolStripMenuItem_giaima
            // 
            this.toolStripMenuItem_giaima.Name = "toolStripMenuItem_giaima";
            this.toolStripMenuItem_giaima.Size = new System.Drawing.Size(131, 24);
            this.toolStripMenuItem_giaima.Text = "Giải Mã";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(675, 446);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lable);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btThucHien);
            this.Controls.Add(this.btTim);
            this.Controls.Add(this.tbMatKhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbGiaiMa);
            this.Controls.Add(this.rbMaHoa);
            this.Controls.Add(this.tbDuongDan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1_DangXuat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1_DangXuat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDuongDan;
        private System.Windows.Forms.RadioButton rbMaHoa;
        private System.Windows.Forms.RadioButton rbGiaiMa;
        private System.Windows.Forms.TextBox tbMatKhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btTim;
        private System.Windows.Forms.Button btThucHien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_mahoa;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_giaima;
    }
}