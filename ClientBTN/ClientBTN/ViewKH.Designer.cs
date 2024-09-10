namespace ClientBTN
{
    partial class ViewKH
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
            this.dgvDSKHFull = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvDsNhomCV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnXoaTV = new System.Windows.Forms.Button();
            this.dgvDsTVN = new System.Windows.Forms.DataGridView();
            this.btnLuuTV = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKHFull)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsNhomCV)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsTVN)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSKHFull
            // 
            this.dgvDSKHFull.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDSKHFull.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKHFull.Location = new System.Drawing.Point(89, 29);
            this.dgvDSKHFull.Name = "dgvDSKHFull";
            this.dgvDSKHFull.RowHeadersWidth = 51;
            this.dgvDSKHFull.RowTemplate.Height = 24;
            this.dgvDSKHFull.Size = new System.Drawing.Size(704, 101);
            this.dgvDSKHFull.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvDSKHFull);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 142);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Jupiter", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(312, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thông tin chi tiết của kế hoạch";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnChiTiet);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.dgvDsNhomCV);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(5, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 281);
            this.panel2.TabIndex = 2;
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.BackColor = System.Drawing.Color.White;
            this.btnChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiTiet.Font = new System.Drawing.Font("Times", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTiet.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChiTiet.Location = new System.Drawing.Point(169, 191);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(89, 33);
            this.btnChiTiet.TabIndex = 4;
            this.btnChiTiet.Text = "Chi Tiết";
            this.btnChiTiet.UseVisualStyleBackColor = false;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Times", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnXoa.Location = new System.Drawing.Point(88, 191);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 33);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.White;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Times", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLuu.Location = new System.Drawing.Point(7, 191);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 33);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvDsNhomCV
            // 
            this.dgvDsNhomCV.BackgroundColor = System.Drawing.Color.White;
            this.dgvDsNhomCV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDsNhomCV.Location = new System.Drawing.Point(7, 29);
            this.dgvDsNhomCV.Name = "dgvDsNhomCV";
            this.dgvDsNhomCV.RowHeadersWidth = 51;
            this.dgvDsNhomCV.RowTemplate.Height = 24;
            this.dgvDsNhomCV.Size = new System.Drawing.Size(484, 156);
            this.dgvDsNhomCV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Jupiter", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(164, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đầu mục công việc";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnXoaTV);
            this.panel3.Controls.Add(this.dgvDsTVN);
            this.panel3.Controls.Add(this.btnLuuTV);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(522, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(387, 280);
            this.panel3.TabIndex = 3;
            // 
            // btnXoaTV
            // 
            this.btnXoaTV.BackColor = System.Drawing.Color.White;
            this.btnXoaTV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTV.Font = new System.Drawing.Font("Times", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaTV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnXoaTV.Location = new System.Drawing.Point(84, 186);
            this.btnXoaTV.Name = "btnXoaTV";
            this.btnXoaTV.Size = new System.Drawing.Size(75, 33);
            this.btnXoaTV.TabIndex = 6;
            this.btnXoaTV.Text = "Xoá";
            this.btnXoaTV.UseVisualStyleBackColor = false;
            this.btnXoaTV.Click += new System.EventHandler(this.btnXoaTV_Click);
            // 
            // dgvDsTVN
            // 
            this.dgvDsTVN.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDsTVN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDsTVN.Location = new System.Drawing.Point(3, 30);
            this.dgvDsTVN.Name = "dgvDsTVN";
            this.dgvDsTVN.RowHeadersWidth = 51;
            this.dgvDsTVN.RowTemplate.Height = 24;
            this.dgvDsTVN.Size = new System.Drawing.Size(381, 150);
            this.dgvDsTVN.TabIndex = 5;
            // 
            // btnLuuTV
            // 
            this.btnLuuTV.BackColor = System.Drawing.Color.White;
            this.btnLuuTV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuTV.Font = new System.Drawing.Font("Times", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuTV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLuuTV.Location = new System.Drawing.Point(3, 186);
            this.btnLuuTV.Name = "btnLuuTV";
            this.btnLuuTV.Size = new System.Drawing.Size(75, 33);
            this.btnLuuTV.TabIndex = 5;
            this.btnLuuTV.Text = "Lưu";
            this.btnLuuTV.UseVisualStyleBackColor = false;
            this.btnLuuTV.Click += new System.EventHandler(this.btnLuuTV_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Jupiter", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(118, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thành viên nhóm";
            // 
            // ViewKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 438);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ViewKH";
            this.Text = "ViewKH";
            this.Load += new System.EventHandler(this.ViewKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKHFull)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsNhomCV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsTVN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSKHFull;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDsNhomCV;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnChiTiet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDsTVN;
        private System.Windows.Forms.Button btnXoaTV;
        private System.Windows.Forms.Button btnLuuTV;
    }
}