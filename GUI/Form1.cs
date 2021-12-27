using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
namespace GUI
{
    public partial class Form1 : Form
    {
        SinhVien_BUS svBUS = new SinhVien_BUS();
        public Form1()
        {
            InitializeComponent();
        }

        private void SinhVien_GUI_Load(object sender, EventArgs e)
        {
            List<SinhVien_DTO> lstSv = svBUS.ReadSinhVien();
            foreach (SinhVien_DTO sv in lstSv)
            {
                dgvsinhvien.Rows.Add(sv.Id, sv.Name, sv.Email, sv.Mobile);
            }
        }
        private void dgvSinhVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            tbId.Text = dgvsinhvien.Rows[idx].Cells[0].Value.ToString();
            tbName.Text = dgvsinhvien.Rows[idx].Cells[1].Value.ToString();
            tbEmail.Text = dgvsinhvien.Rows[idx].Cells[2].Value.ToString();
            tbMobile.Text = dgvsinhvien.Rows[idx].Cells[3].Value.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            if (tbId.Text == "")
                MessageBox.Show("mã nhân viên không được để trống", "Cảnh Báo");
            else if (tbName.Text == "")
                MessageBox.Show("Tên nhân viên không được để trống", "Cảnh Báo");
            else if (tbEmail.Text == "")
                MessageBox.Show("Tên nhân viên không được để trống", "Cảnh Báo");
            else if (tbMobile.Text == "")
                MessageBox.Show("Tên nhân viên không được để trống", "Cảnh Báo");
            else
            {
                SinhVien_DTO sv = new SinhVien_DTO();
                sv.Id = tbId.Text;
                sv.Name = tbName.Text;
                sv.Email = tbEmail.Text;
                sv.Mobile = tbMobile.Text;

                svBUS.NewSinhVien(sv);

                dgvsinhvien.Rows.Add(sv.Id, sv.Name, sv.Email, sv.Mobile);


                tbId.Text = "";
                tbName.Text = "";
                tbEmail.Text = "";
                tbMobile.Text = "";
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?",
                                     "Cảnh Báo!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SinhVien_DTO sv = new SinhVien_DTO();
                sv.Id = tbId.Text;
                sv.Name = tbName.Text;
                sv.Email = tbEmail.Text;
                sv.Mobile = tbMobile.Text;

                svBUS.DeleteSinhVien(sv);

                int idx = dgvsinhvien.CurrentCell.RowIndex;
                dgvsinhvien.Rows.RemoveAt(idx);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "")
                MessageBox.Show("mã nhân viên không được để trống", "Cảnh Báo");
            else if (tbName.Text == "")
                MessageBox.Show("Tên nhân viên không được để trống", "Cảnh Báo");
            else if (tbEmail.Text == "")
                MessageBox.Show("Tên nhân viên không được để trống", "Cảnh Báo");
            else if (tbMobile.Text == "")
                MessageBox.Show("Tên nhân viên không được để trống", "Cảnh Báo");
            else
            {
                DataGridViewRow row = dgvsinhvien.CurrentRow;

                SinhVien_DTO sv = new SinhVien_DTO();
                sv.Id = tbId.Text;
                sv.Name = tbName.Text;
                sv.Email = tbEmail.Text;
                sv.Mobile = tbMobile.Text;

                svBUS.EditSinhVien(sv);

                row.Cells[0].Value = sv.Id;
                row.Cells[1].Value = sv.Name;
                row.Cells[2].Value = sv.Email;
                row.Cells[3].Value = sv.Mobile;
            }

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?",
                                     "Cảnh Báo!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                Close();

        }
    }
}//////////
