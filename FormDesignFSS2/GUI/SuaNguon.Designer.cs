namespace FormDesignFSS2.GUI
{
    partial class SuaNguon
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
            this.txtTienCoTheChoVay = new System.Windows.Forms.TextBox();
            this.lblTienCoTheChoVay = new System.Windows.Forms.Label();
            this.txtHanMuc = new System.Windows.Forms.TextBox();
            this.lblHanMuc = new System.Windows.Forms.Label();
            this.txtTenNguon = new System.Windows.Forms.TextBox();
            this.lblTenNguon = new System.Windows.Forms.Label();
            this.txtMaNguon = new System.Windows.Forms.TextBox();
            this.lblMaNguon = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblTienDaChoVay = new System.Windows.Forms.Label();
            this.txtTienDaChoVay = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTienCoTheChoVay
            // 
            this.txtTienCoTheChoVay.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTienCoTheChoVay.Location = new System.Drawing.Point(136, 155);
            this.txtTienCoTheChoVay.Name = "txtTienCoTheChoVay";
            this.txtTienCoTheChoVay.ReadOnly = true;
            this.txtTienCoTheChoVay.Size = new System.Drawing.Size(236, 20);
            this.txtTienCoTheChoVay.TabIndex = 17;
            this.txtTienCoTheChoVay.TabStop = false;
            // 
            // lblTienCoTheChoVay
            // 
            this.lblTienCoTheChoVay.AutoSize = true;
            this.lblTienCoTheChoVay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienCoTheChoVay.Location = new System.Drawing.Point(3, 156);
            this.lblTienCoTheChoVay.Name = "lblTienCoTheChoVay";
            this.lblTienCoTheChoVay.Size = new System.Drawing.Size(127, 15);
            this.lblTienCoTheChoVay.TabIndex = 16;
            this.lblTienCoTheChoVay.Text = "Số tiền có thể cho vay:";
            // 
            // txtHanMuc
            // 
            this.txtHanMuc.Location = new System.Drawing.Point(136, 82);
            this.txtHanMuc.Name = "txtHanMuc";
            this.txtHanMuc.Size = new System.Drawing.Size(236, 20);
            this.txtHanMuc.TabIndex = 1;
            // 
            // lblHanMuc
            // 
            this.lblHanMuc.AutoSize = true;
            this.lblHanMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHanMuc.Location = new System.Drawing.Point(70, 82);
            this.lblHanMuc.Name = "lblHanMuc";
            this.lblHanMuc.Size = new System.Drawing.Size(60, 15);
            this.lblHanMuc.TabIndex = 14;
            this.lblHanMuc.Text = "Hạn mức:";
            // 
            // txtTenNguon
            // 
            this.txtTenNguon.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTenNguon.Location = new System.Drawing.Point(136, 46);
            this.txtTenNguon.Name = "txtTenNguon";
            this.txtTenNguon.ReadOnly = true;
            this.txtTenNguon.Size = new System.Drawing.Size(236, 20);
            this.txtTenNguon.TabIndex = 13;
            this.txtTenNguon.TabStop = false;
            // 
            // lblTenNguon
            // 
            this.lblTenNguon.AutoSize = true;
            this.lblTenNguon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNguon.Location = new System.Drawing.Point(61, 46);
            this.lblTenNguon.Name = "lblTenNguon";
            this.lblTenNguon.Size = new System.Drawing.Size(69, 15);
            this.lblTenNguon.TabIndex = 12;
            this.lblTenNguon.Text = "Tên nguồn:";
            // 
            // txtMaNguon
            // 
            this.txtMaNguon.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtMaNguon.Location = new System.Drawing.Point(136, 11);
            this.txtMaNguon.Name = "txtMaNguon";
            this.txtMaNguon.ReadOnly = true;
            this.txtMaNguon.Size = new System.Drawing.Size(236, 20);
            this.txtMaNguon.TabIndex = 11;
            this.txtMaNguon.TabStop = false;
            // 
            // lblMaNguon
            // 
            this.lblMaNguon.AutoSize = true;
            this.lblMaNguon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNguon.Location = new System.Drawing.Point(64, 12);
            this.lblMaNguon.Name = "lblMaNguon";
            this.lblMaNguon.Size = new System.Drawing.Size(66, 15);
            this.lblMaNguon.TabIndex = 10;
            this.lblMaNguon.Text = "Mã nguồn:";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnHuy.Image = global::FormDesignFSS2.Properties.Resources._168;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(286, 208);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(86, 39);
            this.btnHuy.TabIndex = 3;
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
            this.btnXacNhan.Location = new System.Drawing.Point(178, 208);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(86, 39);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // lblTienDaChoVay
            // 
            this.lblTienDaChoVay.AutoSize = true;
            this.lblTienDaChoVay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDaChoVay.Location = new System.Drawing.Point(22, 118);
            this.lblTienDaChoVay.Name = "lblTienDaChoVay";
            this.lblTienDaChoVay.Size = new System.Drawing.Size(108, 15);
            this.lblTienDaChoVay.TabIndex = 20;
            this.lblTienDaChoVay.Text = "Số tiền đã cho vay:";
            // 
            // txtTienDaChoVay
            // 
            this.txtTienDaChoVay.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTienDaChoVay.Location = new System.Drawing.Point(136, 118);
            this.txtTienDaChoVay.Name = "txtTienDaChoVay";
            this.txtTienDaChoVay.ReadOnly = true;
            this.txtTienDaChoVay.Size = new System.Drawing.Size(236, 20);
            this.txtTienDaChoVay.TabIndex = 21;
            this.txtTienDaChoVay.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(115, 185);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 22;
            // 
            // SuaNguon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 252);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtTienDaChoVay);
            this.Controls.Add(this.lblTienDaChoVay);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtTienCoTheChoVay);
            this.Controls.Add(this.lblTienCoTheChoVay);
            this.Controls.Add(this.txtHanMuc);
            this.Controls.Add(this.lblHanMuc);
            this.Controls.Add(this.txtTenNguon);
            this.Controls.Add(this.lblTenNguon);
            this.Controls.Add(this.txtMaNguon);
            this.Controls.Add(this.lblMaNguon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuaNguon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa nguồn";
            this.Load += new System.EventHandler(this.SuaNguon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.TextBox txtTienCoTheChoVay;
        private System.Windows.Forms.Label lblTienCoTheChoVay;
        private System.Windows.Forms.TextBox txtHanMuc;
        private System.Windows.Forms.Label lblHanMuc;
        private System.Windows.Forms.TextBox txtTenNguon;
        private System.Windows.Forms.Label lblTenNguon;
        private System.Windows.Forms.TextBox txtMaNguon;
        private System.Windows.Forms.Label lblMaNguon;
        private System.Windows.Forms.Label lblTienDaChoVay;
        private System.Windows.Forms.TextBox txtTienDaChoVay;
        private System.Windows.Forms.Label lblError;
    }
}