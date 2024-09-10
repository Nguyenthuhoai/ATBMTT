namespace ClientBTN
{
    partial class WorkList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTrangThaiCV = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXoaCV = new System.Windows.Forms.Button();
            this.btnLuuCV = new System.Windows.Forms.Button();
            this.lbNameCongViec = new System.Windows.Forms.Label();
            this.dgvTTCV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbMucDoCVC = new System.Windows.Forms.TextBox();
            this.lsbDsTepTin = new System.Windows.Forms.ListBox();
            this.pcdinhKemTep = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTrangThaiCVC = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXoaCVC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLuuCVC = new System.Windows.Forms.Button();
            this.dgvDanhsachCVC = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTCV)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcdinhKemTep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhsachCVC)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.cbTrangThaiCV);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnXoaCV);
            this.panel1.Controls.Add(this.btnLuuCV);
            this.panel1.Controls.Add(this.lbNameCongViec);
            this.panel1.Controls.Add(this.dgvTTCV);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 200);
            this.panel1.TabIndex = 0;
            // 
            // cbTrangThaiCV
            // 
            this.cbTrangThaiCV.FormattingEnabled = true;
            this.cbTrangThaiCV.Items.AddRange(new object[] {
            "Hoàn thành",
            "Đang thực hiện"});
            this.cbTrangThaiCV.Location = new System.Drawing.Point(756, 116);
            this.cbTrangThaiCV.Name = "cbTrangThaiCV";
            this.cbTrangThaiCV.Size = new System.Drawing.Size(167, 24);
            this.cbTrangThaiCV.TabIndex = 11;
            this.cbTrangThaiCV.SelectedIndexChanged += new System.EventHandler(this.cbTrangThaiCV_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(753, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Trạng thái";
            // 
            // btnXoaCV
            // 
            this.btnXoaCV.BackColor = System.Drawing.Color.White;
            this.btnXoaCV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCV.Font = new System.Drawing.Font("Times", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCV.ForeColor = System.Drawing.Color.Black;
            this.btnXoaCV.Location = new System.Drawing.Point(767, 45);
            this.btnXoaCV.Name = "btnXoaCV";
            this.btnXoaCV.Size = new System.Drawing.Size(75, 33);
            this.btnXoaCV.TabIndex = 8;
            this.btnXoaCV.Text = "Xoá";
            this.btnXoaCV.UseVisualStyleBackColor = false;
            this.btnXoaCV.Click += new System.EventHandler(this.btnXoaCV_Click);
            // 
            // btnLuuCV
            // 
            this.btnLuuCV.BackColor = System.Drawing.Color.White;
            this.btnLuuCV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuCV.Font = new System.Drawing.Font("Times", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuCV.ForeColor = System.Drawing.Color.Black;
            this.btnLuuCV.Location = new System.Drawing.Point(848, 45);
            this.btnLuuCV.Name = "btnLuuCV";
            this.btnLuuCV.Size = new System.Drawing.Size(75, 33);
            this.btnLuuCV.TabIndex = 7;
            this.btnLuuCV.Text = "Lưu";
            this.btnLuuCV.UseVisualStyleBackColor = false;
            this.btnLuuCV.Click += new System.EventHandler(this.btnLuuCV_Click_1);
            // 
            // lbNameCongViec
            // 
            this.lbNameCongViec.AutoSize = true;
            this.lbNameCongViec.Font = new System.Drawing.Font("Jupiter", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameCongViec.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbNameCongViec.Location = new System.Drawing.Point(265, 0);
            this.lbNameCongViec.Name = "lbNameCongViec";
            this.lbNameCongViec.Size = new System.Drawing.Size(185, 26);
            this.lbNameCongViec.TabIndex = 2;
            this.lbNameCongViec.Text = "DANH SÁCH CÔNG VIỆC";
            // 
            // dgvTTCV
            // 
            this.dgvTTCV.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTTCV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTCV.Location = new System.Drawing.Point(9, 29);
            this.dgvTTCV.Name = "dgvTTCV";
            this.dgvTTCV.RowHeadersWidth = 51;
            this.dgvTTCV.RowTemplate.Height = 24;
            this.dgvTTCV.Size = new System.Drawing.Size(726, 156);
            this.dgvTTCV.TabIndex = 0;
            this.dgvTTCV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvTTCV_CellBeginEdit);
            this.dgvTTCV.SelectionChanged += new System.EventHandler(this.dgvTTCV_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.tbMucDoCVC);
            this.panel2.Controls.Add(this.lsbDsTepTin);
            this.panel2.Controls.Add(this.pcdinhKemTep);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbTrangThaiCVC);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnXoaCVC);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnLuuCVC);
            this.panel2.Controls.Add(this.dgvDanhsachCVC);
            this.panel2.Location = new System.Drawing.Point(3, 209);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(934, 368);
            this.panel2.TabIndex = 1;
            // 
            // tbMucDoCVC
            // 
            this.tbMucDoCVC.Location = new System.Drawing.Point(756, 164);
            this.tbMucDoCVC.Name = "tbMucDoCVC";
            this.tbMucDoCVC.Size = new System.Drawing.Size(167, 22);
            this.tbMucDoCVC.TabIndex = 16;
            // 
            // lsbDsTepTin
            // 
            this.lsbDsTepTin.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbDsTepTin.FormattingEnabled = true;
            this.lsbDsTepTin.ItemHeight = 20;
            this.lsbDsTepTin.Location = new System.Drawing.Point(57, 258);
            this.lsbDsTepTin.Name = "lsbDsTepTin";
            this.lsbDsTepTin.Size = new System.Drawing.Size(828, 84);
            this.lsbDsTepTin.TabIndex = 15;
            // 
            // pcdinhKemTep
            // 
            this.pcdinhKemTep.Image = global::ClientBTN.Properties.Resources.đính_kèm;
            this.pcdinhKemTep.Location = new System.Drawing.Point(9, 218);
            this.pcdinhKemTep.Name = "pcdinhKemTep";
            this.pcdinhKemTep.Size = new System.Drawing.Size(46, 38);
            this.pcdinhKemTep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcdinhKemTep.TabIndex = 14;
            this.pcdinhKemTep.TabStop = false;
            this.pcdinhKemTep.Click += new System.EventHandler(this.pcdinhKemTep_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("UTM Alpine KT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(50, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 37);
            this.label6.TabIndex = 13;
            this.label6.Text = "Đính kèm tệp tin ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(753, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Mức độ";
            // 
            // cbTrangThaiCVC
            // 
            this.cbTrangThaiCVC.FormattingEnabled = true;
            this.cbTrangThaiCVC.Items.AddRange(new object[] {
            "Hoàn thành ",
            "Đang thực hiện"});
            this.cbTrangThaiCVC.Location = new System.Drawing.Point(756, 109);
            this.cbTrangThaiCVC.Name = "cbTrangThaiCVC";
            this.cbTrangThaiCVC.Size = new System.Drawing.Size(167, 24);
            this.cbTrangThaiCVC.TabIndex = 13;
            this.cbTrangThaiCVC.SelectedIndexChanged += new System.EventHandler(this.cbTrangThaiCVC_SelectedIndexChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(753, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Trạng thái";
            // 
            // btnXoaCVC
            // 
            this.btnXoaCVC.BackColor = System.Drawing.Color.White;
            this.btnXoaCVC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCVC.Font = new System.Drawing.Font("Times", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCVC.ForeColor = System.Drawing.Color.Black;
            this.btnXoaCVC.Location = new System.Drawing.Point(767, 24);
            this.btnXoaCVC.Name = "btnXoaCVC";
            this.btnXoaCVC.Size = new System.Drawing.Size(75, 33);
            this.btnXoaCVC.TabIndex = 10;
            this.btnXoaCVC.Text = "Xoá";
            this.btnXoaCVC.UseVisualStyleBackColor = false;
            this.btnXoaCVC.Click += new System.EventHandler(this.btnXoaCVC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Jupiter", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(237, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh sách các công việc con";
            // 
            // btnLuuCVC
            // 
            this.btnLuuCVC.BackColor = System.Drawing.Color.White;
            this.btnLuuCVC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuCVC.Font = new System.Drawing.Font("Times", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuCVC.ForeColor = System.Drawing.Color.Black;
            this.btnLuuCVC.Location = new System.Drawing.Point(848, 24);
            this.btnLuuCVC.Name = "btnLuuCVC";
            this.btnLuuCVC.Size = new System.Drawing.Size(75, 33);
            this.btnLuuCVC.TabIndex = 9;
            this.btnLuuCVC.Text = "Lưu";
            this.btnLuuCVC.UseVisualStyleBackColor = false;
            this.btnLuuCVC.Click += new System.EventHandler(this.btnLuuCVC_Click);
            // 
            // dgvDanhsachCVC
            // 
            this.dgvDanhsachCVC.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDanhsachCVC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhsachCVC.Location = new System.Drawing.Point(9, 26);
            this.dgvDanhsachCVC.Name = "dgvDanhsachCVC";
            this.dgvDanhsachCVC.RowHeadersWidth = 51;
            this.dgvDanhsachCVC.RowTemplate.Height = 24;
            this.dgvDanhsachCVC.Size = new System.Drawing.Size(726, 186);
            this.dgvDanhsachCVC.TabIndex = 0;
            this.dgvDanhsachCVC.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDanhsachCVC_CellBeginEdit);
            this.dgvDanhsachCVC.SelectionChanged += new System.EventHandler(this.dgvDanhsachCVC_SelectionChanged);
            // 
            // WorkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 579);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WorkList";
            this.Text = "WorkList";
            this.Load += new System.EventHandler(this.WorkList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTCV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcdinhKemTep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhsachCVC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTTCV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDanhsachCVC;
        private System.Windows.Forms.Label lbNameCongViec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoaCV;
        private System.Windows.Forms.Button btnLuuCV;
        private System.Windows.Forms.Button btnXoaCVC;
        private System.Windows.Forms.Button btnLuuCVC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTrangThaiCV;
        private System.Windows.Forms.ComboBox cbTrangThaiCVC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pcdinhKemTep;
        private System.Windows.Forms.ListBox lsbDsTepTin;
        private System.Windows.Forms.TextBox tbMucDoCVC;
    }
}