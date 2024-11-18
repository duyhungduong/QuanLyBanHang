using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmHoaDonTheoHoaDon : Form
    {
        //Chuỗi kết nối
        //string strConnectionString = @"Server=.\SQLEXPRESS;Database=QuanLyBanHang;Integrated Security=True";
        //or
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=SSPI";

        //Đối tượng kết nối
        SqlConnection conn = null;
        //Đối tượng đưa dữ liệu vào DataTable dtHoaDon = null;
        SqlDataAdapter daHoaDon = null;
        //Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;

        //Đối tượng đưa dữ liệu vào DataTable dtChiTiet = null;
        SqlDataAdapter daChiTiet = null;
        //Đối tượng hiển thị dữ liệu lên Form
        DataTable dtChiTiet = null;

        public frmHoaDonTheoHoaDon()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadData()
        {
            try
            {
                //Khởi động kết nối
                conn = new SqlConnection(strConnectionString);

                //Vận chuyển dữ liệu lên DataTable dtHoaDon
                daHoaDon = new SqlDataAdapter("SELECT MaHD, MaHD AS DisplayedMaHD FROM HoaDon", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);

                //Xóa các đối tượng trong Panel
                //Đưa dữ liệu lên ComboBox
                DataRow newRow = dtHoaDon.NewRow();
                newRow["MaHD"] = DBNull.Value;  // Giá trị NULL hoặc giá trị đặc biệt cho "Chọn hóa đơn"
                newRow["DisplayedMaHD"] = "Chọn hóa đơn";  // Cột hiển thị
                dtHoaDon.Rows.InsertAt(newRow, 0); // Thêm vào vị trí đầu tiên

                this.cbMaHD.DataSource = dtHoaDon;
                this.cbMaHD.DisplayMember = "DisplayedMaHD";
                this.cbMaHD.ValueMember = "MaHD";

                // Gán tổng sản phẩm trong hóa đơn ban đầu txtTongSP = 0
                this.txtTongSoSP.Text = "0";

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung. Lỗi rồi!!!");
            }
        }

        private void LoadDataByOrder()
        {
            try
            {
                // Chọn hóa đơn không hợp lệ
                if (cbMaHD.SelectedValue == null || cbMaHD.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn hợp lệ!");
                    return;
                }

                //Khởi động kết nối
                conn = new SqlConnection(strConnectionString);

                //Vận chuyển dữ liệu lên DataTable dtKhachHang
                daChiTiet = new SqlDataAdapter("SELECT HoaDon.MaHD, SanPham.TenSP, SanPham.DonGia, ChiTietHoaDon.SoLuong, SanPham.DonViTinh, (ChiTietHoaDon.SoLuong * SanPham.DonGia) AS ThanhTien, HoaDon.NgayLapHD, HoaDon.NgayNhanHang, Khachhang.TenCty AS MaKH, (NhanVien.Ho + ' ' + NhanVien.Ten) AS MaNV FROM HoaDon JOIN ChiTietHoaDon ON HoaDon.MaHD = ChiTietHoaDon.MaHD JOIN SanPham ON ChiTietHoaDon.MaSP = SanPham.MaSP JOIN NhanVien ON HoaDon.MaNV = NhanVien.MaNV JOIN Khachhang ON HoaDon.MaKH = Khachhang.MaKH WHERE HoaDon.MaHD = '" + this.cbMaHD.SelectedValue.ToString() + "'", conn);
                dtChiTiet = new DataTable();
                dtChiTiet.Clear();
                daChiTiet.Fill(dtChiTiet);

                //Đưa dữ liệu lên DataGridView
                this.dgvHoaDon.DataSource = dtChiTiet;
                //Thay đổi độ rộng cột
                dgvHoaDon.AutoResizeColumns();

                //Đếm số dòng trong datatable dtHoaDon
                //int soKH dtHoaDon.Rows.Count();
                int soHD = Convert.ToInt32(dtChiTiet.Compute("COUNT(MAHD)", string.Empty));
                //MessageBox.Show(soKH.ToString(), "Số dòng");
                this.txtTongSoSP.Text = soHD.ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung. Lỗi rồi!!!");
            }
        }

        private void frmHoaDonTheoHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmHoaDonTheoHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Giải phóng tài nguyên
            dtHoaDon.Dispose();
            dtHoaDon = null;

            if (dtChiTiet != null)
            {
                dtChiTiet.Dispose();
                dtChiTiet = null;
            }    

            //hủy kết nối
            conn = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadDataByOrder();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            if (dtChiTiet != null)
            {
                // Đặt combobox về mặc định
                this.cbMaHD.SelectedIndex = 0;

                // Clear DataTable và đưa lên DataGridView
                dtChiTiet.Clear();
                this.dgvHoaDon.DataSource = dtChiTiet;

                // Gán số lượng sản phẩm của đơn hàng lại bằng 0
                this.txtTongSoSP.Text = "0";
            }
        }
    }
}
