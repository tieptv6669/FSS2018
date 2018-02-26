namespace FormDesignFSS2.GUI
{
    partial class ThemNguon
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
            this.lblMaNguon = new System.Windows.Forms.Label();
            this.txtMaNguon = new System.Windows.Forms.TextBox();
            this.lblTenNguon = new System.Windows.Forms.Label();
            this.txtTenNguon = new System.Windows.Forms.TextBox();
            this.lblHanMuc = new System.Windows.Forms.Label();
            this.txtHanMuc = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMaNguon
            // 
            this.lblMaNguon.AutoSize = true;
            this.lblMaNguon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNguon.Location = new System.Drawing.Point(4, 10);
            this.lblMaNguon.Name = "lblMaNguon";
            this.lblMaNguon.Size = new System.Drawing.Size(66, 15);
            this.lblMaNguon.TabIndex = 0;
            this.lblMaNguon.Text = "Mã nguồn:";
            // 
            // txtMaNguon
            // 
            this.txtMaNguon.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtMaNguon.Location = new System.Drawing.Point(76, 9);
            this.txtMaNguon.Name = "txtMaNguon";
            this.txtMaNguon.ReadOnly = true;
            this.txtMaNguon.Size = new System.Drawing.Size(236, 20);
            this.txtMaNguon.TabIndex = 5;
            // 
            // lblTenNguon
            // 
            this.lblTenNguon.AutoSize = true;
            this.lblTenNguon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNguon.Location = new System.Drawing.Point(1, 44);
            this.lblTenNguon.Name = "lblTenNguon";
            this.lblTenNguon.Size = new System.Drawing.Size(69, 15);
            this.lblTenNguon.TabIndex = 2;
            this.lblTenNguon.Text = "Tên nguồn:";
            // 
            // txtTenNguon
            // 
            this.txtTenNguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTenNguon.Location = new System.Drawing.Point(76, 44);
            this.txtTenNguon.Name = "txtTenNguon";
            this.txtTenNguon.Size = new System.Drawing.Size(236, 20);
            this.txtTenNguon.TabIndex = 1;
            // 
            // lblHanMuc
            // 
            this.lblHanMuc.AutoSize = true;
            this.lblHanMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHanMuc.Location = new System.Drawing.Point(10, 79);
            this.lblHanMuc.Name = "lblHanMuc";
            this.lblHanMuc.Size = new System.Drawing.Size(60, 15);
            this.lblHanMuc.TabIndex = 4;
            this.lblHanMuc.Text = "Hạn mức:";
            // 
            // txtHanMuc
            // 
            this.txtHanMuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtHanMuc.Location = new System.Drawing.Point(76, 79);
            this.txtHanMuc.Name = "txtHanMuc";
            this.txtHanMuc.Size = new System.Drawing.Size(236, 20);
            this.txtHanMuc.TabIndex = 2;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnXacNhan.Image = global::FormDesignFSS2.Properties.Resources._155;
            this.btnXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.Location = new System.Drawing.Point(118, 129);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(86, 39);
            this.btnXacNhan.TabIndex = 3;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnHuy.Image = global::FormDesignFSS2.Properties.Resources._168;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(226, 129);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(86, 39);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(115, 109);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 10;
            // 
            // ThemNguon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 172);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtHanMuc);
            this.Controls.Add(this.lblHanMuc);
            this.Controls.Add(this.txtTenNguon);
            this.Controls.Add(this.lblTenNguon);
            this.Controls.Add(this.txtMaNguon);
            this.Controls.Add(this.lblMaNguon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemNguon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm nguồn";
            this.Load += new System.EventHandler(this.ThemNguon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaNguon;
        private System.Windows.Forms.TextBox txtMaNguon;
        private System.Windows.Forms.Label lblTenNguon;
        private System.Windows.Forms.TextBox txtTenNguon;
        private System.Windows.Forms.Label lblHanMuc;
        private System.Windows.Forms.TextBox txtHanMuc;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lblError;
    }
}