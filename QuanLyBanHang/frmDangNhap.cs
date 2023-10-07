using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtMatKhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void btnImageThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnImageThoat_Click(sender, e);
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;

            if (txtTaiKhoan.Text == "")
                MessageBox.Show("Vui lòng nhập tài khoản", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(txtMatKhau.Text == "")
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                using (ContextDB context = new ContextDB())
                {
                    var user = context.DangNhaps.FirstOrDefault(u => u.TaiKhoan == username && u.password == password);

                    if (user != null)
                    {
                        // Đăng nhập thành công, mở form chính
                        frmTrangChu mainForm = new frmTrangChu();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }
    }
}
