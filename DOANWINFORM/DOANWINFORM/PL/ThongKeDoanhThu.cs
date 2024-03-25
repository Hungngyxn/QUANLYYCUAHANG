using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANWINFORM.PL
{
    public partial class ThongKeDoanhThu : Form
    {
        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            QLBHDataContext data = new QLBHDataContext();
            var listhd = from hoadon in data.HoaDons
                         where hoadon.NgayHD <= DateTime.Parse(dateTimePicker2.Text) && hoadon.NgayHD >= DateTime.Parse(dateTimePicker1.Text)
                         select new
                         {
                             hoadon.MaHD,
                             hoadon.MaKH,
                             hoadon.NgayHD,
                             hoadon.ThanhTien
                         };
            dataGridView1.DataSource = listhd;
            dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Ngày lập";
            dataGridView1.Columns[3].HeaderText = "Thành tiền";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            double Tongmoi = 0;
            foreach (var gia in listhd)
            {
                 Tongmoi += Convert.ToDouble(gia.ThanhTien);
                txtdoanhthu.Text = Tongmoi.ToString();
                txtchu.Text = Function.ChuyenSoSangChuoi(Tongmoi);
            }

            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = null;
            
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {

        }

        private void ThongKeDoanhThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                btnthongke_Click(sender, e);
            }
        }
    }
}
