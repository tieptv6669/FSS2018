namespace FormDesignFSS2.GUI
{
    partial class SuaGN
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.cmbSPTD = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtKyHan = new System.Windows.Forms.TextBox();
            this.txtLaiSuat = new System.Windows.Forms.TextBox();
            this.txtNguon = new System.Windows.Forms.TextBox();
            this.txtSoTienGN = new System.Windows.Forms.TextBox();
            this.txtSoTKLK = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLaiSuatQH = new System.Windows.Forms.TextBox();
            this.dateNgayGN = new System.Windows.Forms.DateTimePicker();
            this.dateNgayDH = new System.Windows.Forms.DateTimePicker();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.Location = new System.Drawing.Point(87, -33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 20);
            this.textBox1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, -32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Số TKLK:";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnHuy.Image = global::FormDesignFSS2.Properties.Resources._168;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(312, 369);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(86, 39);
            this.btnHuy.TabIndex = 44;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnXacNhan.Image = global::FormDesignFSS2.Properties.Resources._155;
            this.btnXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.Location = new System.Drawing.Point(220, 369);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(86, 39);
            this.btnXacNhan.TabIndex = 43;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // cmbSPTD
            // 
            this.cmbSPTD.BackColor = System.Drawing.SystemColors.Window;
            this.cmbSPTD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSPTD.FormattingEnabled = true;
            this.cmbSPTD.Items.AddRange(new object[] {
            "Cho vay mua nhà"});
            this.cmbSPTD.Location = new System.Drawing.Point(95, 61);
            this.cmbSPTD.Name = "cmbSPTD";
            this.cmbSPTD.Size = new System.Drawing.Size(302, 21);
            this.cmbSPTD.TabIndex = 64;
            this.cmbSPTD.SelectedIndexChanged += new System.EventHandler(this.cmbSPTD_SelectedIndexChanged);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.SystemColors.Window;
            this.txtGhiChu.Location = new System.Drawing.Point(96, 254);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(302, 81);
            this.txtGhiChu.TabIndex = 63;
            // 
            // txtKyHan
            // 
            this.txtKyHan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtKyHan.Enabled = false;
            this.txtKyHan.Location = new System.Drawing.Point(94, 172);
            this.txtKyHan.Name = "txtKyHan";
            this.txtKyHan.Size = new System.Drawing.Size(303, 20);
            this.txtKyHan.TabIndex = 60;
            // 
            // txtLaiSuat
            // 
            this.txtLaiSuat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtLaiSuat.Enabled = false;
            this.txtLaiSuat.Location = new System.Drawing.Point(94, 114);
            this.txtLaiSuat.Name = "txtLaiSuat";
            this.txtLaiSuat.Size = new System.Drawing.Size(303, 20);
            this.txtLaiSuat.TabIndex = 59;
            // 
            // txtNguon
            // 
            this.txtNguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNguon.Enabled = false;
            this.txtNguon.Location = new System.Drawing.Point(94, 88);
            this.txtNguon.Name = "txtNguon";
            this.txtNguon.Size = new System.Drawing.Size(303, 20);
            this.txtNguon.TabIndex = 58;
            // 
            // txtSoTienGN
            // 
            this.txtSoTienGN.BackColor = System.Drawing.SystemColors.Window;
            this.txtSoTienGN.Location = new System.Drawing.Point(94, 35);
            this.txtSoTienGN.Name = "txtSoTienGN";
            this.txtSoTienGN.Size = new System.Drawing.Size(303, 20);
            this.txtSoTienGN.TabIndex = 57;
            // 
            // txtSoTKLK
            // 
            this.txtSoTKLK.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSoTKLK.Enabled = false;
            this.txtSoTKLK.Location = new System.Drawing.Point(94, 8);
            this.txtSoTKLK.Name = "txtSoTKLK";
            this.txtSoTKLK.Size = new System.Drawing.Size(303, 20);
            this.txtSoTKLK.TabIndex = 55;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 54;
            this.label10.Text = "Ghi chú:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(29, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 53;
            this.label9.Text = "Ngày ĐH:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 52;
            this.label8.Text = "Ngày GN:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-1, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 15);
            this.label7.TabIndex = 51;
            this.label7.Text = "Kỳ hạn (tháng):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 50;
            this.label6.Text = "Lãi suất (%):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 49;
            this.label5.Text = "Nguồn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 48;
            this.label4.Text = "SP Tín Dụng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 47;
            this.label3.Text = "Số tiền GN:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(30, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 15);
            this.label11.TabIndex = 45;
            this.label11.Text = "Số TKLK:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 65;
            this.label2.Text = "Lãi suất QH:";
            // 
            // txtLaiSuatQH
            // 
            this.txtLaiSuatQH.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtLaiSuatQH.Enabled = false;
            this.txtLaiSuatQH.Location = new System.Drawing.Point(94, 142);
            this.txtLaiSuatQH.Name = "txtLaiSuatQH";
            this.txtLaiSuatQH.Size = new System.Drawing.Size(303, 20);
            this.txtLaiSuatQH.TabIndex = 66;
            // 
            // dateNgayGN
            // 
            this.dateNgayGN.Enabled = false;
            this.dateNgayGN.Location = new System.Drawing.Point(95, 199);
            this.dateNgayGN.Name = "dateNgayGN";
            this.dateNgayGN.Size = new System.Drawing.Size(303, 20);
            this.dateNgayGN.TabIndex = 67;
            // 
            // dateNgayDH
            // 
            this.dateNgayDH.Enabled = false;
            this.dateNgayDH.Location = new System.Drawing.Point(96, 225);
            this.dateNgayDH.Name = "dateNgayDH";
            this.dateNgayDH.Size = new System.Drawing.Size(303, 20);
            this.dateNgayDH.TabIndex = 68;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(93, 348);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 69;
            // 
            // SuaGN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 413);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.dateNgayDH);
            this.Controls.Add(this.dateNgayGN);
            this.Controls.Add(this.txtLaiSuatQH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSPTD);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtKyHan);
            this.Controls.Add(this.txtLaiSuat);
            this.Controls.Add(this.txtNguon);
            this.Controls.Add(this.txtSoTienGN);
            this.Controls.Add(this.txtSoTKLK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "SuaGN";
            this.Text = "Sửa giải ngân";
            this.Load += new System.EventHandler(this.SuaGN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.ComboBox cmbSPTD;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtKyHan;
        private System.Windows.Forms.TextBox txtLaiSuat;
        private System.Windows.Forms.TextBox txtNguon;
        private System.Windows.Forms.TextBox txtSoTienGN;
        private System.Windows.Forms.TextBox txtSoTKLK;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLaiSuatQH;
        private System.Windows.Forms.DateTimePicker dateNgayGN;
        private System.Windows.Forms.DateTimePicker dateNgayDH;
        private System.Windows.Forms.Label lblError;
    }
}