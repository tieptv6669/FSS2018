namespace FormDesignFSS2.GUI
{
    partial class SuaKH
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
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.radioGTNu = new System.Windows.Forms.RadioButton();
            this.radioGTNam = new System.Windows.Forms.RadioButton();
            this.dateNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cmbLoaiKH = new System.Windows.Forms.ComboBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSoCMND = new System.Windows.Forms.TextBox();
            this.txtNgheNghiep = new System.Windows.Forms.TextBox();
            this.txtHoTenKH = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblSoCMND = new System.Windows.Forms.Label();
            this.lblNgheNghiep = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblLoaiKH = new System.Windows.Forms.Label();
            this.lblHoTenKH = new System.Windows.Forms.Label();
            this.txtNgayMoTK = new System.Windows.Forms.TextBox();
            this.lblNgayMoTK = new System.Windows.Forms.Label();
            this.txtSoTKLK = new System.Windows.Forms.TextBox();
            this.lblsoTKLK = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHuy.Image = global::FormDesignFSS2.Properties.Resources._168;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(310, 389);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(86, 39);
            this.btnHuy.TabIndex = 57;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click_1);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnXacNhan.Image = global::FormDesignFSS2.Properties.Resources._155;
            this.btnXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.Location = new System.Drawing.Point(218, 389);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(86, 39);
            this.btnXacNhan.TabIndex = 56;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // radioGTNu
            // 
            this.radioGTNu.AutoSize = true;
            this.radioGTNu.Location = new System.Drawing.Point(172, 166);
            this.radioGTNu.Name = "radioGTNu";
            this.radioGTNu.Size = new System.Drawing.Size(39, 17);
            this.radioGTNu.TabIndex = 55;
            this.radioGTNu.Text = "Nữ";
            this.radioGTNu.UseVisualStyleBackColor = true;
            // 
            // radioGTNam
            // 
            this.radioGTNam.AutoSize = true;
            this.radioGTNam.Checked = true;
            this.radioGTNam.Location = new System.Drawing.Point(103, 166);
            this.radioGTNam.Name = "radioGTNam";
            this.radioGTNam.Size = new System.Drawing.Size(47, 17);
            this.radioGTNam.TabIndex = 54;
            this.radioGTNam.TabStop = true;
            this.radioGTNam.Text = "Nam";
            this.radioGTNam.UseVisualStyleBackColor = true;
            // 
            // dateNgaySinh
            // 
            this.dateNgaySinh.Location = new System.Drawing.Point(103, 137);
            this.dateNgaySinh.Name = "dateNgaySinh";
            this.dateNgaySinh.Size = new System.Drawing.Size(154, 20);
            this.dateNgaySinh.TabIndex = 53;
            // 
            // cmbLoaiKH
            // 
            this.cmbLoaiKH.DisplayMember = "1,2,3,4";
            this.cmbLoaiKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiKH.FormattingEnabled = true;
            this.cmbLoaiKH.Items.AddRange(new object[] {
            "Classic",
            "Silver",
            "Gold",
            "Diamond"});
            this.cmbLoaiKH.Location = new System.Drawing.Point(103, 107);
            this.cmbLoaiKH.Name = "cmbLoaiKH";
            this.cmbLoaiKH.Size = new System.Drawing.Size(154, 21);
            this.cmbLoaiKH.TabIndex = 52;
            // 
            // txtSDT
            // 
            this.txtSDT.BackColor = System.Drawing.SystemColors.Window;
            this.txtSDT.Location = new System.Drawing.Point(300, 276);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(94, 20);
            this.txtSDT.TabIndex = 51;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.SystemColors.Window;
            this.txtGhiChu.Location = new System.Drawing.Point(103, 304);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(291, 48);
            this.txtGhiChu.TabIndex = 50;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.Location = new System.Drawing.Point(103, 276);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(154, 20);
            this.txtEmail.TabIndex = 49;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.SystemColors.Window;
            this.txtDiaChi.Location = new System.Drawing.Point(103, 250);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(291, 20);
            this.txtDiaChi.TabIndex = 48;
            // 
            // txtSoCMND
            // 
            this.txtSoCMND.BackColor = System.Drawing.SystemColors.Window;
            this.txtSoCMND.Location = new System.Drawing.Point(103, 217);
            this.txtSoCMND.Name = "txtSoCMND";
            this.txtSoCMND.Size = new System.Drawing.Size(154, 20);
            this.txtSoCMND.TabIndex = 47;
            // 
            // txtNgheNghiep
            // 
            this.txtNgheNghiep.BackColor = System.Drawing.SystemColors.Window;
            this.txtNgheNghiep.Location = new System.Drawing.Point(103, 189);
            this.txtNgheNghiep.Name = "txtNgheNghiep";
            this.txtNgheNghiep.Size = new System.Drawing.Size(154, 20);
            this.txtNgheNghiep.TabIndex = 46;
            // 
            // txtHoTenKH
            // 
            this.txtHoTenKH.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtHoTenKH.Location = new System.Drawing.Point(103, 75);
            this.txtHoTenKH.Name = "txtHoTenKH";
            this.txtHoTenKH.Size = new System.Drawing.Size(154, 20);
            this.txtHoTenKH.TabIndex = 45;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.Location = new System.Drawing.Point(45, 304);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(52, 15);
            this.lblGhiChu.TabIndex = 44;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(260, 279);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(34, 15);
            this.lblSDT.TabIndex = 43;
            this.lblSDT.Text = "SĐT:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(55, 279);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 15);
            this.lblEmail.TabIndex = 42;
            this.lblEmail.Text = "Email:";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(49, 251);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(48, 15);
            this.lblDiaChi.TabIndex = 41;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // lblSoCMND
            // 
            this.lblSoCMND.AutoSize = true;
            this.lblSoCMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoCMND.Location = new System.Drawing.Point(32, 222);
            this.lblSoCMND.Name = "lblSoCMND";
            this.lblSoCMND.Size = new System.Drawing.Size(65, 15);
            this.lblSoCMND.TabIndex = 40;
            this.lblSoCMND.Text = "Số CMND:";
            // 
            // lblNgheNghiep
            // 
            this.lblNgheNghiep.AutoSize = true;
            this.lblNgheNghiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgheNghiep.Location = new System.Drawing.Point(16, 194);
            this.lblNgheNghiep.Name = "lblNgheNghiep";
            this.lblNgheNghiep.Size = new System.Drawing.Size(81, 15);
            this.lblNgheNghiep.TabIndex = 39;
            this.lblNgheNghiep.Text = "Nghề nghiệp:";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinh.Location = new System.Drawing.Point(42, 165);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(55, 15);
            this.lblGioiTinh.TabIndex = 38;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(33, 137);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(64, 15);
            this.lblNgaySinh.TabIndex = 37;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblLoaiKH
            // 
            this.lblLoaiKH.AutoSize = true;
            this.lblLoaiKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiKH.Location = new System.Drawing.Point(43, 107);
            this.lblLoaiKH.Name = "lblLoaiKH";
            this.lblLoaiKH.Size = new System.Drawing.Size(54, 15);
            this.lblLoaiKH.TabIndex = 36;
            this.lblLoaiKH.Text = "Loại KH:";
            // 
            // lblHoTenKH
            // 
            this.lblHoTenKH.AutoSize = true;
            this.lblHoTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTenKH.Location = new System.Drawing.Point(51, 75);
            this.lblHoTenKH.Name = "lblHoTenKH";
            this.lblHoTenKH.Size = new System.Drawing.Size(46, 15);
            this.lblHoTenKH.TabIndex = 35;
            this.lblHoTenKH.Text = "Họ tên:";
            // 
            // txtNgayMoTK
            // 
            this.txtNgayMoTK.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNgayMoTK.Enabled = false;
            this.txtNgayMoTK.Location = new System.Drawing.Point(103, 45);
            this.txtNgayMoTK.Name = "txtNgayMoTK";
            this.txtNgayMoTK.Size = new System.Drawing.Size(154, 20);
            this.txtNgayMoTK.TabIndex = 34;
            // 
            // lblNgayMoTK
            // 
            this.lblNgayMoTK.AutoSize = true;
            this.lblNgayMoTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayMoTK.Location = new System.Drawing.Point(20, 45);
            this.lblNgayMoTK.Name = "lblNgayMoTK";
            this.lblNgayMoTK.Size = new System.Drawing.Size(77, 15);
            this.lblNgayMoTK.TabIndex = 33;
            this.lblNgayMoTK.Text = "Ngày mở TK:";
            // 
            // txtSoTKLK
            // 
            this.txtSoTKLK.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSoTKLK.Enabled = false;
            this.txtSoTKLK.Location = new System.Drawing.Point(103, 13);
            this.txtSoTKLK.Name = "txtSoTKLK";
            this.txtSoTKLK.Size = new System.Drawing.Size(154, 20);
            this.txtSoTKLK.TabIndex = 30;
            // 
            // lblsoTKLK
            // 
            this.lblsoTKLK.AutoSize = true;
            this.lblsoTKLK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsoTKLK.Location = new System.Drawing.Point(39, 13);
            this.lblsoTKLK.Name = "lblsoTKLK";
            this.lblsoTKLK.Size = new System.Drawing.Size(58, 15);
            this.lblsoTKLK.TabIndex = 29;
            this.lblsoTKLK.Text = "Số TKLK:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(100, 366);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 58;
            // 
            // SuaKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 436);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.radioGTNu);
            this.Controls.Add(this.radioGTNam);
            this.Controls.Add(this.dateNgaySinh);
            this.Controls.Add(this.cmbLoaiKH);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtSoCMND);
            this.Controls.Add(this.txtNgheNghiep);
            this.Controls.Add(this.txtHoTenKH);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblSoCMND);
            this.Controls.Add(this.lblNgheNghiep);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.lblLoaiKH);
            this.Controls.Add(this.lblHoTenKH);
            this.Controls.Add(this.txtNgayMoTK);
            this.Controls.Add(this.lblNgayMoTK);
            this.Controls.Add(this.txtSoTKLK);
            this.Controls.Add(this.lblsoTKLK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuaKH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa thông tin khách hàng";
            this.Load += new System.EventHandler(this.SuaKH_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.RadioButton radioGTNu;
        private System.Windows.Forms.RadioButton radioGTNam;
        private System.Windows.Forms.DateTimePicker dateNgaySinh;
        private System.Windows.Forms.ComboBox cmbLoaiKH;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSoCMND;
        private System.Windows.Forms.TextBox txtNgheNghiep;
        private System.Windows.Forms.TextBox txtHoTenKH;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblSoCMND;
        private System.Windows.Forms.Label lblNgheNghiep;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblLoaiKH;
        private System.Windows.Forms.Label lblHoTenKH;
        private System.Windows.Forms.TextBox txtNgayMoTK;
        private System.Windows.Forms.Label lblNgayMoTK;
        private System.Windows.Forms.TextBox txtSoTKLK;
        private System.Windows.Forms.Label lblsoTKLK;
        private System.Windows.Forms.Label lblError;
    }
}