namespace FormDesignFSS2.GUI
{
    partial class DangKyMoiSPTD
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
            this.lblSoTKLK = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblSPTD = new System.Windows.Forms.Label();
            this.txtSoTKLK = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.cboSPTD = new System.Windows.Forms.ComboBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblNguon = new System.Windows.Forms.Label();
            this.txtNguon = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSoTKLK
            // 
            this.lblSoTKLK.AutoSize = true;
            this.lblSoTKLK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTKLK.Location = new System.Drawing.Point(59, 9);
            this.lblSoTKLK.Name = "lblSoTKLK";
            this.lblSoTKLK.Size = new System.Drawing.Size(58, 15);
            this.lblSoTKLK.TabIndex = 0;
            this.lblSoTKLK.Text = "Số TKLK:";
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKH.Location = new System.Drawing.Point(65, 35);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(51, 15);
            this.lblTenKH.TabIndex = 1;
            this.lblTenKH.Text = "Tên KH:";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(68, 61);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(48, 15);
            this.lblDiaChi.TabIndex = 2;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // lblSPTD
            // 
            this.lblSPTD.AutoSize = true;
            this.lblSPTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPTD.Location = new System.Drawing.Point(2, 87);
            this.lblSPTD.Name = "lblSPTD";
            this.lblSPTD.Size = new System.Drawing.Size(114, 15);
            this.lblSPTD.TabIndex = 4;
            this.lblSPTD.Text = "Sản phẩm tín dụng:";
            // 
            // txtSoTKLK
            // 
            this.txtSoTKLK.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSoTKLK.Location = new System.Drawing.Point(123, 7);
            this.txtSoTKLK.Name = "txtSoTKLK";
            this.txtSoTKLK.Size = new System.Drawing.Size(237, 20);
            this.txtSoTKLK.TabIndex = 1;
            this.txtSoTKLK.Leave += new System.EventHandler(this.txtSoTKLK_Leave);
            // 
            // txtTenKH
            // 
            this.txtTenKH.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTenKH.Location = new System.Drawing.Point(123, 35);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.ReadOnly = true;
            this.txtTenKH.Size = new System.Drawing.Size(237, 20);
            this.txtTenKH.TabIndex = 6;
            this.txtTenKH.TabStop = false;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDiaChi.Location = new System.Drawing.Point(123, 61);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(237, 20);
            this.txtDiaChi.TabIndex = 7;
            this.txtDiaChi.TabStop = false;
            // 
            // cboSPTD
            // 
            this.cboSPTD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSPTD.FormattingEnabled = true;
            this.cboSPTD.Location = new System.Drawing.Point(124, 87);
            this.cboSPTD.Name = "cboSPTD";
            this.cboSPTD.Size = new System.Drawing.Size(237, 21);
            this.cboSPTD.TabIndex = 2;
            this.cboSPTD.SelectedIndexChanged += new System.EventHandler(this.cboSPTD_SelectedIndexChanged);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Image = global::FormDesignFSS2.Properties.Resources._155;
            this.btnXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.Location = new System.Drawing.Point(183, 165);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(86, 39);
            this.btnXacNhan.TabIndex = 10;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = global::FormDesignFSS2.Properties.Resources._168;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(275, 165);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(86, 39);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lblNguon
            // 
            this.lblNguon.AutoSize = true;
            this.lblNguon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguon.Location = new System.Drawing.Point(71, 116);
            this.lblNguon.Name = "lblNguon";
            this.lblNguon.Size = new System.Drawing.Size(47, 15);
            this.lblNguon.TabIndex = 12;
            this.lblNguon.Text = "Nguồn:";
            // 
            // txtNguon
            // 
            this.txtNguon.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNguon.Location = new System.Drawing.Point(123, 116);
            this.txtNguon.Name = "txtNguon";
            this.txtNguon.ReadOnly = true;
            this.txtNguon.Size = new System.Drawing.Size(237, 20);
            this.txtNguon.TabIndex = 13;
            this.txtNguon.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(183, 144);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 14;
            // 
            // DangKyMoiSPTD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 209);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtNguon);
            this.Controls.Add(this.lblNguon);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.cboSPTD);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.txtSoTKLK);
            this.Controls.Add(this.lblSPTD);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblTenKH);
            this.Controls.Add(this.lblSoTKLK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangKyMoiSPTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký sản phẩm tín dụng";
            this.Load += new System.EventHandler(this.DangKyMoiSPTD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoTKLK;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblSPTD;
        private System.Windows.Forms.TextBox txtSoTKLK;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.ComboBox cboSPTD;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lblNguon;
        private System.Windows.Forms.TextBox txtNguon;
        private System.Windows.Forms.Label lblError;
    }
}