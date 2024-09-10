using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientBTN
{
    public partial class UpdateKH : Form
    {
        private int _id;
        public UpdateKH(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void UpdateKH_Load(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng SQLSocket
            SQLSocket sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = sqlSocket.SelectWithCondition("2.1", "Id = " + _id); // Sử dụng "2.1" cho BKeHoach
            if(dt.Rows.Count > 0 )
            {
                // Gán dữ liệu vào các control
                tbTen.Text = dt.Rows[0]["Ten"].ToString();
                tbMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                dtpBatDau.Value = DateTime.Parse(dt.Rows[0]["NgayBatDau"].ToString());
                dtpKetThuc.Value = DateTime.Parse(dt.Rows[0]["NgayKetThuc"].ToString());
                tbIdAdmin.Text = dt.Rows[0]["IdAdmin"].ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng SQLSocket
            SQLSocket sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ form AddKH
            string ten = tbTen.Text;
            string mota = tbMoTa.Text;
            string ngaybatdau = dtpBatDau.Value.ToString("yyyy/MM/dd");
            string ngayketthuc = dtpKetThuc.Value.ToString("yyyy/MM/dd");
            string idadmin = tbIdAdmin.Text;
            // Gọi hàm Insert
            int result = sqlSocket.Update("2.3", _id, new string[] { ten, mota, ngaybatdau, ngayketthuc, idadmin });

            // Kiểm tra kết quả
            //if (result == -1)
            //{
            //    MessageBox.Show("Có lỗi xảy ra khi cập nhật dữ liệu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    DialogResult dialogResult = MessageBox.Show("Cập nhật dữ liệu thành công.", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    if (dialogResult == DialogResult.OK)
            //    {
            //        this.Close(); // Đóng form
            //    }
            //}
        }
    }
}
