namespace QuanLyBanHang
{
    partial class frmHoaDonTheoSanPham
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
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongSoHD = new System.Windows.Forms.TextBox();
            this.pnlThongTinKH = new System.Windows.Forms.Panel();
            this.cbMaSP = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLapHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhanHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnlThongTinKH.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.TenSP,
            this.MaKH,
            this.MaNV,
            this.NgayLapHD,
            this.NgayNhanHang});
            this.dgvHoaDon.Location = new System.Drawing.Point(13, 62);
            this.dgvHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 62;
            this.dgvHoaDon.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.Size = new System.Drawing.Size(955, 250);
            this.dgvHoaDon.TabIndex = 16;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(868, 329);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 28);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Trở về";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(728, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tổng số HĐ:";
            // 
            // txtTongSoHD
            // 
            this.txtTongSoHD.Location = new System.Drawing.Point(821, 7);
            this.txtTongSoHD.Margin = new System.Windows.Forms.Padding(4);
            this.txtTongSoHD.Name = "txtTongSoHD";
            this.txtTongSoHD.Size = new System.Drawing.Size(109, 22);
            this.txtTongSoHD.TabIndex = 7;
            // 
            // pnlThongTinKH
            // 
            this.pnlThongTinKH.Controls.Add(this.cbMaSP);
            this.pnlThongTinKH.Controls.Add(this.btnOK);
            this.pnlThongTinKH.Controls.Add(this.label4);
            this.pnlThongTinKH.Controls.Add(this.label5);
            this.pnlThongTinKH.Controls.Add(this.txtTongSoHD);
            this.pnlThongTinKH.Location = new System.Drawing.Point(13, 13);
            this.pnlThongTinKH.Margin = new System.Windows.Forms.Padding(4);
            this.pnlThongTinKH.Name = "pnlThongTinKH";
            this.pnlThongTinKH.Size = new System.Drawing.Size(955, 36);
            this.pnlThongTinKH.TabIndex = 17;
            // 
            // cbMaSP
            // 
            this.cbMaSP.FormattingEnabled = true;
            this.cbMaSP.Location = new System.Drawing.Point(164, 6);
            this.cbMaSP.Margin = new System.Windows.Forms.Padding(4);
            this.cbMaSP.Name = "cbMaSP";
            this.cbMaSP.Size = new System.Drawing.Size(402, 24);
            this.cbMaSP.TabIndex = 20;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(574, 5);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 28);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Chọn Sản phẩm:";
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "Mã Hóa Đơn";
            this.MaHD.MinimumWidth = 8;
            this.MaHD.Name = "MaHD";
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên Sản Phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "Khách Hàng";
            this.MaKH.MinimumWidth = 8;
            this.MaKH.Name = "MaKH";
            this.MaKH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Nhân Viên";
            this.MaNV.MinimumWidth = 8;
            this.MaNV.Name = "MaNV";
            this.MaNV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // NgayLapHD
            // 
            this.NgayLapHD.DataPropertyName = "NgayLapHD";
            this.NgayLapHD.HeaderText = "Ngày Lập HĐ";
            this.NgayLapHD.MinimumWidth = 8;
            this.NgayLapHD.Name = "NgayLapHD";
            // 
            // NgayNhanHang
            // 
            this.NgayNhanHang.DataPropertyName = "NgayNhanHang";
            this.NgayNhanHang.HeaderText = "Ngày Nhận Hàng";
            this.NgayNhanHang.MinimumWidth = 8;
            this.NgayNhanHang.Name = "NgayNhanHang";
            // 
            // frmHoaDonTheoSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 369);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.pnlThongTinKH);
            this.Name = "frmHoaDonTheoSanPham";
            this.Text = "Quản Lý Hóa Đơn Theo Sản Phẩm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHoaDonTheoSanPham_FormClosing);
            this.Load += new System.EventHandler(this.frmHoaDonTheoSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnlThongTinKH.ResumeLayout(false);
            this.pnlThongTinKH.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTongSoHD;
        private System.Windows.Forms.Panel pnlThongTinKH;
        private System.Windows.Forms.ComboBox cbMaSP;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLapHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhanHang;
    }
}