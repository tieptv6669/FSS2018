﻿namespace FormDesignFSS2.GUI
{
    partial class LichSuTraNo
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
            this.lblMaGN = new System.Windows.Forms.Label();
            this.txtMaGN = new System.Windows.Forms.TextBox();
            this.gridLSTN = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblLichSu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridLSTN)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaGN
            // 
            this.lblMaGN.AutoSize = true;
            this.lblMaGN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaGN.Location = new System.Drawing.Point(4, 9);
            this.lblMaGN.Name = "lblMaGN";
            this.lblMaGN.Size = new System.Drawing.Size(82, 15);
            this.lblMaGN.TabIndex = 0;
            this.lblMaGN.Text = "Mã giải ngân:";
            // 
            // txtMaGN
            // 
            this.txtMaGN.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtMaGN.Location = new System.Drawing.Point(92, 8);
            this.txtMaGN.Name = "txtMaGN";
            this.txtMaGN.ReadOnly = true;
            this.txtMaGN.Size = new System.Drawing.Size(181, 20);
            this.txtMaGN.TabIndex = 1;
            this.txtMaGN.TabStop = false;
            // 
            // gridLSTN
            // 
            this.gridLSTN.AllowUserToAddRows = false;
            this.gridLSTN.AllowUserToDeleteRows = false;
            this.gridLSTN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLSTN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.gridLSTN.Location = new System.Drawing.Point(7, 58);
            this.gridLSTN.MultiSelect = false;
            this.gridLSTN.Name = "gridLSTN";
            this.gridLSTN.ReadOnly = true;
            this.gridLSTN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLSTN.Size = new System.Drawing.Size(645, 188);
            this.gridLSTN.TabIndex = 3;
            this.gridLSTN.TabStop = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mã trả nợ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên KH";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Số tiền trả";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Số tiền trả gốc";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Số tiền trả lãi";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Ngày trả nợ";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Image = global::FormDesignFSS2.Properties.Resources._168;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(570, 252);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(83, 46);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // lblLichSu
            // 
            this.lblLichSu.AutoSize = true;
            this.lblLichSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLichSu.Location = new System.Drawing.Point(4, 40);
            this.lblLichSu.Name = "lblLichSu";
            this.lblLichSu.Size = new System.Drawing.Size(83, 15);
            this.lblLichSu.TabIndex = 5;
            this.lblLichSu.Text = "Lịch sử trả nợ:";
            // 
            // LichSuTraNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 302);
            this.Controls.Add(this.lblLichSu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.gridLSTN);
            this.Controls.Add(this.txtMaGN);
            this.Controls.Add(this.lblMaGN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LichSuTraNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lịch sử trả nợ";
            this.Load += new System.EventHandler(this.LichSuTraNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLSTN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaGN;
        private System.Windows.Forms.TextBox txtMaGN;
        private System.Windows.Forms.DataGridView gridLSTN;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblLichSu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}