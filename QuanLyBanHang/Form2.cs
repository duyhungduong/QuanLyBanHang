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
    public partial class Form2 : Form
    {
        private string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=SSPI";
        public Form2()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form2_KeyDown;
            this.txtUser.KeyDown += TxtFields_KeyDown;
            this.txtPass.KeyDown += TxtFields_KeyDown;
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (ValidateLogin(username, password))
            {
                // MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không đúng tên người dùng / mật khẩu !!!", "Thông báo");
                this.txtUser.Focus();
            }
        }

        private bool ValidateLogin(string username, string password)
        {
            // Validate input before querying the database
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                try
                {
                    conn.Open();

                    // SQL query to check for username and password
                    string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Returns true if a matching record is found
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi");
                    return false;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Chắc không?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void TxtFields_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangnhap_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangnhap_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // Sua loi dang nhap cua chuong trinh "Nhan X hoaac ALtF4 se thoat chuong trinh"
        public bool ClosedByXButtonOrAltF4 { get; private set; }
        private const int SC_CLOSE = 0xF060;
        private const int WM_SYSCOMMAND = 0x0112;

        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SYSCOMMAND && msg.WParam.ToInt32() == SC_CLOSE)
                ClosedByXButtonOrAltF4 = true;
            base.WndProc(ref msg);
        }
        protected override void OnShown(EventArgs e)
        {
            ClosedByXButtonOrAltF4 = false;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (ClosedByXButtonOrAltF4)
                // MessageBox.Show("Closed by X or Alt+F4");
                Application.Exit();
            //else
            //    MessageBox.Show("Closed by calling Close()");
        }

    }
}
