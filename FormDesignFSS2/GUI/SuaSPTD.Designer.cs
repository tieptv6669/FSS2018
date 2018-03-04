namespace FormDesignFSS2.GUI
{
    partial class SuaSPTD
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
            this.txtLaiSuatQuaHan = new System.Windows.Forms.TextBox();
            this.lblLaiSuatQuaHan = new System.Windows.Forms.Label();
            this.txtMaSPTD = new System.Windows.Forms.TextBox();
            this.lblMaSPTD = new System.Windows.Forms.Label();
            this.lblNguon = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.txtLaiSuat = new System.Windows.Forms.TextBox();
            this.lblLaiSuat = new System.Windows.Forms.Label();
            this.txtThoiHanVay = new System.Windows.Forms.TextBox();
            this.lblThoiHanVay = new System.Windows.Forms.Label();
            this.txtTenSPTD = new System.Windows.Forms.TextBox();
            this.lblTenSPTD = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.txtNguon = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLaiSuatQuaHan
            // 
            this.txtLaiSuatQuaHan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtLaiSuatQuaHan.Location = new System.Drawing.Point(153, 128);
            this.txtLaiSuatQuaHan.Name = "txtLaiSuatQuaHan";
            this.txtLaiSuatQuaHan.Size = new System.Drawing.Size(241, 20);
            this.txtLaiSuatQuaHan.TabIndex = 4;
            // 
            // lblLaiSuatQuaHan
            // 
            this.lblLaiSuatQuaHan.AutoSize = true;
            this.lblLaiSuatQuaHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaiSuatQuaHan.Location = new System.Drawing.Point(24, 128);
            this.lblLaiSuatQuaHan.Name = "lblLaiSuatQuaHan";
            this.lblLaiSuatQuaHan.Size = new System.Drawing.Size(123, 15);
            this.lblLaiSuatQuaHan.TabIndex = 38;
            this.lblLaiSuatQuaHan.Text = "Lãi suất quá hạn (%):";
            // 
            // txtMaSPTD
            // 
            this.txtMaSPTD.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtMaSPTD.Location = new System.Drawing.Point(153, 8);
            this.txtMaSPTD.Name = "txtMaSPTD";
            this.txtMaSPTD.ReadOnly = true;
            this.txtMaSPTD.Size = new System.Drawing.Size(241, 20);
            this.txtMaSPTD.TabIndex = 37;
            this.txtMaSPTD.TabStop = false;
            // 
            // lblMaSPTD
            // 
            this.lblMaSPTD.AutoSize = true;
            this.lblMaSPTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSPTD.Location = new System.Drawing.Point(14, 8);
            this.lblMaSPTD.Name = "lblMaSPTD";
            this.lblMaSPTD.Size = new System.Drawing.Size(133, 15);
            this.lblMaSPTD.TabIndex = 36;
            this.lblMaSPTD.Text = "Mã sản phẩm tín dụng:";
            // 
            // lblNguon
            // 
            this.lblNguon.AutoSize = true;
            this.lblNguon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguon.Location = new System.Drawing.Point(100, 157);
            this.lblNguon.Name = "lblNguon";
            this.lblNguon.Size = new System.Drawing.Size(47, 15);
            this.lblNguon.TabIndex = 34;
            this.lblNguon.Text = "Nguồn:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Hoạt động",
            "Ngừng hoạt động"});
            this.cboTrangThai.Location = new System.Drawing.Point(153, 187);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(241, 21);
            this.cboTrangThai.TabIndex = 6;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(83, 189);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(65, 15);
            this.lblTrangThai.TabIndex = 32;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHuy.Image = global::FormDesignFSS2.Properties.Resources._168;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(310, 239);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(86, 39);
            this.btnHuy.TabIndex = 31;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnXacNhan.Image = global::FormDesignFSS2.Properties.Resources._155;
            this.btnXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.Location = new System.Drawing.Point(218, 239);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(86, 39);
            this.btnXacNhan.TabIndex = 30;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtLaiSuat
            // 
            this.txtLaiSuat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtLaiSuat.Location = new System.Drawing.Point(153, 97);
            this.txtLaiSuat.Name = "txtLaiSuat";
            this.txtLaiSuat.Size = new System.Drawing.Size(241, 20);
            this.txtLaiSuat.TabIndex = 3;
            // 
            // lblLaiSuat
            // 
            this.lblLaiSuat.AutoSize = true;
            this.lblLaiSuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaiSuat.Location = new System.Drawing.Point(72, 97);
            this.lblLaiSuat.Name = "lblLaiSuat";
            this.lblLaiSuat.Size = new System.Drawing.Size(75, 15);
            this.lblLaiSuat.TabIndex = 28;
            this.lblLaiSuat.Text = "Lãi suất (%):";
            // 
            // txtThoiHanVay
            // 
            this.txtThoiHanVay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtThoiHanVay.Location = new System.Drawing.Point(153, 71);
            this.txtThoiHanVay.Name = "txtThoiHanVay";
            this.txtThoiHanVay.Size = new System.Drawing.Size(241, 20);
            this.txtThoiHanVay.TabIndex = 2;
            // 
            // lblThoiHanVay
            // 
            this.lblThoiHanVay.AutoSize = true;
            this.lblThoiHanVay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiHanVay.Location = new System.Drawing.Point(28, 71);
            this.lblThoiHanVay.Name = "lblThoiHanVay";
            this.lblThoiHanVay.Size = new System.Drawing.Size(120, 15);
            this.lblThoiHanVay.TabIndex = 26;
            this.lblThoiHanVay.Text = "Thời hạn vay (tháng):";
            // 
            // txtTenSPTD
            // 
            this.txtTenSPTD.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTenSPTD.Location = new System.Drawing.Point(153, 40);
            this.txtTenSPTD.Name = "txtTenSPTD";
            this.txtTenSPTD.Size = new System.Drawing.Size(241, 20);
            this.txtTenSPTD.TabIndex = 1;
            // 
            // lblTenSPTD
            // 
            this.lblTenSPTD.AutoSize = true;
            this.lblTenSPTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSPTD.Location = new System.Drawing.Point(11, 41);
            this.lblTenSPTD.Name = "lblTenSPTD";
            this.lblTenSPTD.Size = new System.Drawing.Size(136, 15);
            this.lblTenSPTD.TabIndex = 24;
            this.lblTenSPTD.Text = "Tên sản phẩm tín dụng:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(218, 219);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 40;
            // 
            // txtNguon
            // 
            this.txtNguon.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNguon.Location = new System.Drawing.Point(153, 157);
            this.txtNguon.Name = "txtNguon";
            this.txtNguon.ReadOnly = true;
            this.txtNguon.Size = new System.Drawing.Size(241, 20);
            this.txtNguon.TabIndex = 41;
            this.txtNguon.TabStop = false;
            // 
            // SuaSPTD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 281);
            this.Controls.Add(this.txtNguon);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtLaiSuatQuaHan);
            this.Controls.Add(this.lblLaiSuatQuaHan);
            this.Controls.Add(this.txtMaSPTD);
            this.Controls.Add(this.lblMaSPTD);
            this.Controls.Add(this.lblNguon);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtLaiSuat);
            this.Controls.Add(this.lblLaiSuat);
            this.Controls.Add(this.txtThoiHanVay);
            this.Controls.Add(this.lblThoiHanVay);
            this.Controls.Add(this.txtTenSPTD);
            this.Controls.Add(this.lblTenSPTD);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuaSPTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thay đổi thông tin sản phẩm tín dụng";
            this.Load += new System.EventHandler(this.SuaSPTD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLaiSuatQuaHan;
        private System.Windows.Forms.Label lblLaiSuatQuaHan;
        private System.Windows.Forms.TextBox txtMaSPTD;
        private System.Windows.Forms.Label lblMaSPTD;
        private System.Windows.Forms.Label lblNguon;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.TextBox txtLaiSuat;
        private System.Windows.Forms.Label lblLaiSuat;
        private System.Windows.Forms.TextBox txtThoiHanVay;
        private System.Windows.Forms.Label lblThoiHanVay;
        private System.Windows.Forms.TextBox txtTenSPTD;
        private System.Windows.Forms.Label lblTenSPTD;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtNguon;
    }
}