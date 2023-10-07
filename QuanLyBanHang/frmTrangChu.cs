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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }
        private void Clear_panel()
        {
            main.Controls.Clear();
        }
        private void btnhang_Click(object sender, EventArgs e)
        {
            Clear_panel();
            frmHang form = new frmHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            main.Controls.Add(form);
            form.Show();
        }

        private void btnloai_Click(object sender, EventArgs e)
        {
           Clear_panel();
           frmLoaiHang form = new frmLoaiHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
           main.Controls.Add(form);
           form.Show();
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            Clear_panel();
            frmNhanVien form = new frmNhanVien() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            main.Controls.Add(form);
            form.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            Clear_panel();
            frmTaiKhoan form = new frmTaiKhoan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            main.Controls.Add(form);
            form.Show();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            Clear_panel();
            frmNhaCungCap form = new frmNhaCungCap() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            main.Controls.Add(form);
            form.Show();
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            Clear_panel();
            frmNhap form = new frmNhap() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            main.Controls.Add(form);
            form.Show();
        }

        private void btnPhieuXuat_Click(object sender, EventArgs e)
        {
            Clear_panel();
            frmXuat form = new frmXuat() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            main.Controls.Add(form);
            form.Show();
        }

        private void btnHangTon_Click(object sender, EventArgs e)
        {
            Clear_panel();
            frmThongKeHangTon form = new frmThongKeHangTon() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            main.Controls.Add(form);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất tài khoản", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                frmDangNhap dangNhap = new frmDangNhap();
                dangNhap.Show();
                this.Close();
            }
        }
    }
}
