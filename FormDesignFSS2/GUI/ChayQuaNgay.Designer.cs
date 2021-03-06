﻿namespace FormDesignFSS2.GUI
{
    partial class ChayQuaNgay
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
            this.lblNgayLamViecHienTai = new System.Windows.Forms.Label();
            this.txtNgayLVHienTai = new System.Windows.Forms.TextBox();
            this.lblNgayLamViecTiepTheo = new System.Windows.Forms.Label();
            this.dateTPNgayLamViecTiepTheo = new System.Windows.Forms.DateTimePicker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.processPercent = new System.Windows.Forms.Label();
            this.timerXuLyCuoiNgay = new System.Windows.Forms.Timer(this.components);
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNgayLamViecHienTai
            // 
            this.lblNgayLamViecHienTai.AutoSize = true;
            this.lblNgayLamViecHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayLamViecHienTai.Location = new System.Drawing.Point(12, 9);
            this.lblNgayLamViecHienTai.Name = "lblNgayLamViecHienTai";
            this.lblNgayLamViecHienTai.Size = new System.Drawing.Size(129, 15);
            this.lblNgayLamViecHienTai.TabIndex = 0;
            this.lblNgayLamViecHienTai.Text = "Ngày làm việc hiện tại:";
            // 
            // txtNgayLVHienTai
            // 
            this.txtNgayLVHienTai.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNgayLVHienTai.Location = new System.Drawing.Point(147, 8);
            this.txtNgayLVHienTai.Name = "txtNgayLVHienTai";
            this.txtNgayLVHienTai.ReadOnly = true;
            this.txtNgayLVHienTai.Size = new System.Drawing.Size(187, 20);
            this.txtNgayLVHienTai.TabIndex = 1;
            this.txtNgayLVHienTai.TabStop = false;
            this.txtNgayLVHienTai.Text = "04/02/2018";
            // 
            // lblNgayLamViecTiepTheo
            // 
            this.lblNgayLamViecTiepTheo.AutoSize = true;
            this.lblNgayLamViecTiepTheo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayLamViecTiepTheo.Location = new System.Drawing.Point(5, 44);
            this.lblNgayLamViecTiepTheo.Name = "lblNgayLamViecTiepTheo";
            this.lblNgayLamViecTiepTheo.Size = new System.Drawing.Size(136, 15);
            this.lblNgayLamViecTiepTheo.TabIndex = 2;
            this.lblNgayLamViecTiepTheo.Text = "Ngày làm việc tiếp theo:";
            // 
            // dateTPNgayLamViecTiepTheo
            // 
            this.dateTPNgayLamViecTiepTheo.Location = new System.Drawing.Point(147, 44);
            this.dateTPNgayLamViecTiepTheo.Name = "dateTPNgayLamViecTiepTheo";
            this.dateTPNgayLamViecTiepTheo.Size = new System.Drawing.Size(187, 20);
            this.dateTPNgayLamViecTiepTheo.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(8, 100);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(326, 23);
            this.progressBar.TabIndex = 4;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::FormDesignFSS2.Properties.Resources._114;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(184, 138);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(96, 40);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDau.Image = global::FormDesignFSS2.Properties.Resources._10;
            this.btnBatDau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatDau.Location = new System.Drawing.Point(64, 138);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(96, 40);
            this.btnBatDau.TabIndex = 2;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // processPercent
            // 
            this.processPercent.AutoSize = true;
            this.processPercent.Location = new System.Drawing.Point(164, 77);
            this.processPercent.Name = "processPercent";
            this.processPercent.Size = new System.Drawing.Size(0, 13);
            this.processPercent.TabIndex = 7;
            // 
            // timerXuLyCuoiNgay
            // 
            this.timerXuLyCuoiNgay.Tick += new System.EventHandler(this.timerXuLyCuoiNgay_Tick);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(50, 77);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 8;
            // 
            // ChayQuaNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 182);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.processPercent);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.dateTPNgayLamViecTiepTheo);
            this.Controls.Add(this.lblNgayLamViecTiepTheo);
            this.Controls.Add(this.txtNgayLVHienTai);
            this.Controls.Add(this.lblNgayLamViecHienTai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChayQuaNgay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xử lý cuối ngày";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChayQuaNgay_FormClosing);
            this.Load += new System.EventHandler(this.ChayQuaNgay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNgayLamViecHienTai;
        private System.Windows.Forms.TextBox txtNgayLVHienTai;
        private System.Windows.Forms.Label lblNgayLamViecTiepTheo;
        private System.Windows.Forms.DateTimePicker dateTPNgayLamViecTiepTheo;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label processPercent;
        private System.Windows.Forms.Timer timerXuLyCuoiNgay;
        private System.Windows.Forms.Label lblError;
    }
}