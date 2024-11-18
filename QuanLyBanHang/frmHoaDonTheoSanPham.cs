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
    public partial class frmHoaDonTheoSanPham : Form
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

        //Đối tượng đưa dữ liệu vào DataTable dtSanPham = null;
        SqlDataAdapter daSanPham = null;
        //Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;

        public frmHoaDonTheoSanPham()
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

                //Vận chuyển dữ liệu lên DataTable dtSanPham
                daSanPham = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);

                //Xóa các đối tượng trong Panel
                //Đưa dữ liệu lên ComboBox
                this.cbMaSP.DataSource = dtSanPham;
                this.cbMaSP.DisplayMember = "TenSP";
                this.cbMaSP.ValueMember = "MaSP";

                //Vận chuyển dữ liệu lên DataTable dtHoaDon
                daHoaDon = new SqlDataAdapter("SELECT HoaDon.MaHD, SanPham.TenSP, Khachhang.TenCty AS MaKH, (NhanVien.Ho + ' ' + NhanVien.Ten) AS MaNV, HoaDon.NgayLapHD, HoaDon.NgayNhanHang FROM HoaDon JOIN ChiTietHoaDon ON HoaDon.MaHD = ChiTietHoaDon.MaHD JOIN SanPham ON ChiTietHoaDon.MaSP = SanPham.MaSP JOIN NhanVien ON HoaDon.MaNV = NhanVien.MaNV JOIN Khachhang ON HoaDon.MaKH = Khachhang.MaKH", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);

                //Đưa dữ liệu lên DataGridView
                this.dgvHoaDon.DataSource = dtHoaDon;
                //Thay đổi độ rộng cột
                dgvHoaDon.AutoResizeColumns();

                //Đếm số dòng trong datatable daHoaDon
                //int soKH daHoaDon.Rows.Count();
                int soHD = Convert.ToInt32(dtHoaDon.Compute("COUNT(MAHD)", string.Empty));
                //MessageBox.Show(soKH.ToString(), "Số dòng");
                this.txtTongSoHD.Text = soHD.ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng Hóa đơn. Lỗi rồi!!!");
            }
        }


        private void LoadDataByCustomer()
        {
            try
            {
                //Khởi động kết nối
                conn = new SqlConnection(strConnectionString);

                //Vận chuyển dữ liệu lên DataTable dtKhachHang
                daHoaDon = new SqlDataAdapter("SELECT HoaDon.MaHD, SanPham.TenSP, Khachhang.TenCty AS MaKH, (NhanVien.Ho + ' ' + NhanVien.Ten) AS MaNV, HoaDon.NgayLapHD, HoaDon.NgayNhanHang FROM HoaDon JOIN ChiTietHoaDon ON HoaDon.MaHD = ChiTietHoaDon.MaHD JOIN SanPham ON ChiTietHoaDon.MaSP = SanPham.MaSP JOIN NhanVien ON HoaDon.MaNV = NhanVien.MaNV JOIN Khachhang ON HoaDon.MaKH = Khachhang.MaKH WHERE SanPham.MaSP = '" + this.cbMaSP.SelectedValue.ToString() + "'", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);

                //Đưa dữ liệu lên DataGridView
                this.dgvHoaDon.DataSource = dtHoaDon;
                //Thay đổi độ rộng cột
                dgvHoaDon.AutoResizeColumns();

                //Đếm số dòng trong datatable dtKhachHang
                //int soKH dtKhachHang.Rows.Count();
                int soHD = Convert.ToInt32(dtHoaDon.Compute("COUNT(MAHD)", string.Empty));
                //MessageBox.Show(soKH.ToString(), "Số dòng");
                this.txtTongSoHD.Text = soHD.ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng Hóa đơn. Lỗi rồi!!!");
            }
        }

        private void frmHoaDonTheoSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmHoaDonTheoSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Giải phóng tài nguyên
            dtHoaDon.Dispose();
            dtHoaDon = null;

            dtSanPham.Dispose();
            dtSanPham = null;

            //hủy kết nối
            conn = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadDataByCustomer();
        }
    }
}
