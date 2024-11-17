using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmDanhMucSanPham : Form
    {
        //Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        // Khai báo biến lưu trữ đường dẫn hình ảnh
        string filePath = null;
        //Chuỗi kết nối
        //string strConnectionString = @"Server=.\SQLEXPRESS;Database=QuanLyBanHang;Integrated Security=True";
        //or
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=SSPI";

        //Đối tượng kết nối
        SqlConnection conn = null;
        //Đối tượng đưa dữ liệu vào DataTable dtSanPham = null;
        SqlDataAdapter daSanPham = null;
        //Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;

        public frmDanhMucSanPham()
        {
            InitializeComponent();
            this.numberDonGia.Maximum = decimal.MaxValue;
        }

        void LoadData()
        {
            try
            {
                //Khởi động kết nối
                conn = new SqlConnection(strConnectionString);

                //Vận chuyển dữ liệu lên DataTable dtHoaDon
                daSanPham = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                //Đưa dữ liệu lên DataGridView
                this.dgvSanPham.DataSource = dtSanPham;

                //Xóa các đối tượng trong Panel
                this.txtMaSP.ResetText();
                this.txtTenSP.ResetText();
                this.txtDonViTinh.ResetText();
                this.numberDonGia.Value = 0;
                this.pictureBoxSP.Image = null;
                this.btnUpload.Enabled = false;
                filePath = null;
                
                //Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.pnlThongTinSP.Enabled = false;
                //Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;

                // Không chọn row nào trên bảng
                this.dgvSanPham.ClearSelection();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung Sản Phẩm. Lỗi rồi!!!");
            }
        }

        private void frmDanhMucSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmDanhMucSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Giải phóng tài nguyên
            dtSanPham.Dispose();
            dtSanPham = null;
            //hủy kết nối
            conn = null;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName; // Đường dẫn file ảnh
                pictureBoxSP.Image = Image.FromFile(path); // Hiển thị ảnh lên PictureBox
                filePath = path;
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kích hoạt biến Them
            Them = true;
            //Xóa trống các đối tượng trong Panel
            this.txtMaSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtDonViTinh.ResetText();
            this.numberDonGia.Value = 0;
            this.pictureBoxSP.Image = null;
            filePath = null;

            //Cho thao tác trên các nút Lưu / Hủy / Panel / Tải ảnh
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.pnlThongTinSP.Enabled = true;
            this.btnUpload.Enabled = true;
            //Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;

            //Đưa con trỏ đến TextField txtMaSP
            this.txtMaSP.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kích hoạt biến Sửa
            Them = false;

            //Cho phép thao tác trên Panel
            this.pnlThongTinSP.Enabled = true;
            //Thứ tự dòng hiện hành
            int r = dgvSanPham.CurrentCell.RowIndex;
            //Chuyển thông tin lên panel
            this.txtMaSP.Text = dgvSanPham.Rows[r].Cells[0].Value.ToString();
            this.txtTenSP.Text = dgvSanPham.Rows[r].Cells[1].Value.ToString();
            this.txtDonViTinh.Text = dgvSanPham.Rows[r].Cells[2].Value.ToString();
            this.numberDonGia.Value = Convert.ToDecimal(dgvSanPham.Rows[r].Cells[3].Value);

            // Lấy dữ liệu byte[] từ cột ảnh trong DataGridView
            if (dgvSanPham.Rows[r].Cells[4].Value != DBNull.Value)
            {
                byte[] imageBytes = (byte[])dgvSanPham.Rows[r].Cells[4].Value;

                // Kiểm tra nếu dữ liệu ảnh không rỗng
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    // Chuyển đổi byte[] thành đối tượng Image
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        this.pictureBoxSP.Image = Image.FromStream(ms);  // Gán ảnh vào PictureBox
                    }
                }
                else
                {
                    // Nếu không có ảnh (null hoặc kích thước bằng 0), bạn có thể hiển thị ảnh mặc định
                    this.pictureBoxSP.Image = null;  // Hoặc ảnh mặc định nếu cần
                }
            }
            else
            {
                // Nếu dữ liệu trong cột là DBNull (không có ảnh), bạn có thể hiển thị ảnh mặc định
                this.pictureBoxSP.Image = null;  // Hoặc một ảnh mặc định nào đó
            }

            //Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.pnlThongTinSP.Enabled = true;
            this.btnUpload.Enabled = true;
            //Không cho thao tác trên các nút thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Không cho phép sửa MaSP
            this.txtMaSP.Enabled = false;
            //Đưa con trỏ đến TextField txtMaKH
            this.txtTenSP.Focus();
        }

        private bool validateData(string MaSP, string TenSP, string DonViTinh, float DonGia)
        {
            if (string.IsNullOrWhiteSpace(MaSP))
            {
                MessageBox.Show("Mã sản phẩm không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMaSP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TenSP))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtTenSP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(DonViTinh))
            {
                MessageBox.Show("Đơn vị tính không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDonViTinh.Focus();
                return false;
            }

            if (DonGia <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.numberDonGia.Focus();
                return false;
            }

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form
            string MaSP = this.txtMaSP.Text.ToString();
            string TenSP = this.txtTenSP.Text.ToString();
            string DonViTinh = this.txtDonViTinh.Text.ToString();
            float DonGia = (float)this.numberDonGia.Value;

            if (!validateData(MaSP, TenSP, DonViTinh, DonGia))
            {
                return;
            }

            //Mở kết nối
            conn.Open();
            if (Them)
            {
                try
                {
                    //Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    //Lệnh Insert InTo
                    cmd.CommandText = "INSERT INTO SanPham (MaSP, TenSP, DonViTinh, DonGia, Hinh) VALUES (@MaSP, @TenSP, @DonViTinh, @DonGia, @Hinh)";
                    cmd.Parameters.AddWithValue("@MaSP", MaSP);
                    cmd.Parameters.AddWithValue("@TenSP", TenSP);
                    cmd.Parameters.AddWithValue("@DonViTinh", DonViTinh);
                    cmd.Parameters.AddWithValue("@DonGia", DonGia);

                    // Nếu có ảnh mới, thêm ảnh vào câu lệnh
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        byte[] image = File.ReadAllBytes(filePath);
                        cmd.Parameters.AddWithValue("@Hinh", image);
                    } 
                    else
                    {
                        // Thêm giá trị DBNull.Value khi không có ảnh
                        cmd.Parameters.Add("@Hinh", SqlDbType.VarBinary).Value = DBNull.Value;
                    }

                    cmd.ExecuteNonQuery();
                    //Load lại dữ liệu trên DataGridView
                    LoadData();
                    //Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }//if

            //for updating data
            if (!Them)
            {
                try
                {
                    //Thứ tự dòng hiện hành
                    int r = dgvSanPham.CurrentCell.RowIndex;
                    string currentMaSP = dgvSanPham.Rows[r].Cells[0].Value.ToString();
                    string query = "UPDATE SanPham SET TenSP = @TenSP, DonViTinh = @DonViTinh, DonGia = @DonGia WHERE MaSP = @MaSP";

                    // Nếu có ảnh mới, thêm tham số ảnh vào câu lệnh
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        query = "UPDATE SanPham SET TenSP = @TenSP, DonViTinh = @DonViTinh, DonGia = @DonGia, Hinh = @Hinh WHERE MaSP = @MaSP";
                    }

                    //Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    // Thêm tham số để tránh SQL Injection
                    cmd.Parameters.AddWithValue("@TenSP", TenSP);
                    cmd.Parameters.AddWithValue("@DonViTinh", DonViTinh);
                    cmd.Parameters.AddWithValue("@DonGia", DonGia);
                    cmd.Parameters.AddWithValue("@MaSP", currentMaSP);

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        byte[] image = File.ReadAllBytes(filePath);
                        cmd.Parameters.AddWithValue("@Hinh", image);
                    }

                    // Thực hiện câu lệnh
                    cmd.ExecuteNonQuery();

                    //Load lại dữ liệu lên trên DataGridView
                    LoadData();
                    //Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            //Đóng kết nối
            conn.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //Xóa trống các đối tượng trong panel
            this.txtMaSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtDonViTinh.ResetText();
            this.numberDonGia.Value = 0;
            this.pictureBoxSP.Image = null;
            filePath = null;

            //Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            //Không cho thao tác trên các nút Lưu / Hủy / Panel / Tải ảnh
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.pnlThongTinSP.Enabled = false;
            this.btnUpload.Enabled = false;

            // Không chọn row nào trên bảng
            this.dgvSanPham.ClearSelection();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Mở kết nối
            conn.Open();
            try
            {
                //Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                //Lấy thứ tự record hiện hành
                int r = dgvSanPham.CurrentCell.RowIndex;
                //Lấy MaKH của record hiện hành
                string strMASP = dgvSanPham.Rows[r].Cells[0].Value.ToString();
                //Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete from SanPham where MaSP='" + strMASP + "'");
                //cmd.CommandType = CommandType.Text;
                //Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                //Cập nhật lại DataGridView
                LoadData();
                //Thông báo
                MessageBox.Show("Đã xóa xong!");

            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
            //Đóng kết nối
            conn.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
