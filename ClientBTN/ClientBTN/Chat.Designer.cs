namespace ClientBTN
{
    partial class Chat
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
            this.tbLichSu = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbNoiDung = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGui = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.tbLichSu);
            this.panel1.Location = new System.Drawing.Point(11, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 268);
            this.panel1.TabIndex = 0;
            // 
            // tbLichSu
            // 
            this.tbLichSu.Location = new System.Drawing.Point(3, 3);
            this.tbLichSu.Multiline = true;
            this.tbLichSu.Name = "tbLichSu";
            this.tbLichSu.Size = new System.Drawing.Size(474, 262);
            this.tbLichSu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.tbNoiDung);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(11, 278);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 87);
            this.panel2.TabIndex = 1;
            // 
            // tbNoiDung
            // 
            this.tbNoiDung.Location = new System.Drawing.Point(3, 25);
            this.tbNoiDung.Multiline = true;
            this.tbNoiDung.Name = "tbNoiDung";
            this.tbNoiDung.Size = new System.Drawing.Size(474, 57);
            this.tbNoiDung.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nội dung";
            // 
            // btnGui
            // 
            this.btnGui.Location = new System.Drawing.Point(497, 289);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(52, 31);
            this.btnGui.TabIndex = 2;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "To: ";
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(500, 28);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(126, 22);
            this.tbFrom.TabIndex = 5;
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(500, 82);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(126, 22);
            this.tbTo.TabIndex = 6;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoad.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnLoad.Location = new System.Drawing.Point(607, 351);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(28, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 375);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tbTo);
            this.Controls.Add(this.tbFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Chat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNoiDung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.TextBox tbLichSu;
        private System.Windows.Forms.Button btnLoad;
    }
}