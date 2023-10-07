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
using System.Data.Entity.Migrations;

namespace QuanLyBanHang
{
    public partial class frmLoaiHang : Form
    {
        ContextDB context = new ContextDB();
        public frmLoaiHang()
        {
            InitializeComponent();
        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            try
            {
                List<LoaiSanPham> listLoaihang = context.LoaiSanPhams.ToList();
                BindGrid(listLoaihang);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<LoaiSanPham> listLoaihang)
        {
            dgvLoaihang.Rows.Clear();
            foreach(var item in listLoaihang)
            {
                int index = dgvLoaihang.Rows.Add();
                dgvLoaihang.Rows[index].Cells[0].Value = item.MaLoai;
                dgvLoaihang.Rows[index].Cells[1].Value = item.TenLoai;
            }
        }
        private int GetSelectedRow(string maLoai)
        {
           try {
                for (int i = 0; i < dgvLoaihang.Rows.Count; i++)
                {
                    if(dgvLoaihang.Rows[i].Cells[0].Value != null )
                    {
                        if (dgvLoaihang.Rows[i].Cells[0].Value.ToString() == maLoai)
                        {
                            return i;
                        }
                    }                  
                }
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private bool CheckData()
        {
            if(txtMaloai.Text == "" || txtTenloai.Text == "")
            {
                MessageBox.Show("Vui long nhap day du thong tin", "Thong bao", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void LoadForm()
        {
            txtMaloai.Clear();
            txtTenloai.Clear();
            txtTimkiem.Clear();
        }
        private void LoadDGV()
        {
            List<LoaiSanPham> newListLoaihang = context.LoaiSanPhams.ToList();
            BindGrid(newListLoaihang);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                if(GetSelectedRow(txtMaloai.Text) == -1)
                {
                    LoaiSanPham s = new LoaiSanPham {
                        MaLoai = txtMaloai.Text,
                        TenLoai = txtTenloai.Text
                    };
                   

                    context.LoaiSanPhams.AddOrUpdate(s);
                    context.SaveChanges();
                    LoadDGV();
                    LoadForm();
                    MessageBox.Show("Them moi du lieu thanh cong!", "Thong bao", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Ma loai da ton tai", "Thong bao", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(CheckData())
            {
                LoaiSanPham updL = context.LoaiSanPhams.FirstOrDefault(p => p.MaLoai == txtMaloai.Text);
                if(updL != null)
                {
                    updL.MaLoai = txtMaloai.Text;
                    updL.TenLoai = txtTenloai.Text;

                    context.LoaiSanPhams.AddOrUpdate(updL);
                    context.SaveChanges();
                    LoadDGV();
                    LoadForm();
                    MessageBox.Show("Cap nhat thong tin thanh cong!", "Thong bao", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Khong tim thay loai hang can cap nhat!", "Thong bao", MessageBoxButtons.OK);
                }
          }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            LoaiSanPham d = context.LoaiSanPhams.FirstOrDefault(p => p.MaLoai == txtMaloai.Text);
            if(d != null)
            {
                DialogResult result = MessageBox.Show("Ban co dong y xoa loai hang nay hay khong?", "Thong bao", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    context.LoaiSanPhams.Remove(d);
                    context.SaveChanges();
                    LoadForm();
                    LoadDGV();
                    MessageBox.Show("Xoa thanh cong aaa", "Thong bao", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Khong ton tai loai hang nay!", "Thong bao", MessageBoxButtons.OK);
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {                      
            var searchResults = context.LoaiSanPhams.Where(LoaiSanPham => (string.IsNullOrEmpty(txtTimkiem.Text) || LoaiSanPham.TenLoai.Contains(txtTimkiem.Text))).ToList();
            BindGrid(searchResults);
        }
    }
}
