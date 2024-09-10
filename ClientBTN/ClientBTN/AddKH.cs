using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClientBTN
{
    public partial class AddKH : Form
    {
        private string _username;
        public AddKH(string username)
        {
            InitializeComponent();
            _username = username;
            tbIdAdmin.Text = GetIdAdmin(username).ToString();
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

            int newKeHoachId = sqlSocket.Insert("2.2", new string[] { ten, mota, ngaybatdau, ngayketthuc, idadmin });

            // lấy ra id kế hoạch vừa thêm vào 
            //DataTable dtKH  = sqlSocket.SelectWithCondition("2.5", "Ten = '" + ten + "'");
            //if (dtKH.Rows.Count > 0)
            //{   
                // lấy idkh mới thêm vào 
                //int kqidKH =  int.Parse(dtKH.Rows[0]["Id"].ToString());
                // insert dữ liệu rỗng vào nhóm công việc, công việc, công việc con.
                // nhóm công việc
                string tenNCV = " ";
                int newdulieu = sqlSocket.Insert("4.2", new string[] { tenNCV.ToString(), newKeHoachId.ToString() });
                // công việc
                ////////////////
                DataTable dtNCV = sqlSocket.SelectWithCondition("4.6", "Ten =  '" + tenNCV + "'");
                if(dtNCV.Rows.Count > 0)
                {
                    //lấy id nhóm cv mới thêm
                    int kpidNCV = int.Parse(dtNCV.Rows[0]["Id"].ToString());
                    sqlSocket.Insert("5.2", new string[] { " ", " ", "1/5/2024", "2/5/2024", "Đang thực hiện", idadmin, kpidNCV.ToString() });
                    // công việc con 
                    DataTable dtNCVC = sqlSocket.SelectWithCondition("5.7", "Ten =  '" + " " + "'");
                    if(dtNCVC.Rows.Count > 0)
                    {   // lấy ra id công việc
                        int kpidCV = int.Parse(dtNCVC.Rows[0]["Id"].ToString());
                        sqlSocket.Insert("6.2", new string[] { " ", " ", "1/5/2024", "2/5/2024", "Đang thực hiện", idadmin, kpidCV.ToString()});
                    }                     
                }

            //}
           
            // Kiểm tra kết quả
            if (newKeHoachId == -1)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm dữ liệu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //MessageBox.Show("Thêm dữ liệu thành công.", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Thêm người tạo dự án vào nhóm với quyền Admin
                int result = sqlSocket.Insert("3.2", new string[] { newKeHoachId.ToString(),idadmin, "Admin" });

            }
            LamMoi();
        }
        private void LamMoi()
        {
            tbTen.Text = "";
            tbMoTa.Text = "";

        }
        
        private int GetIdAdmin(string username)
        {
            // Khởi tạo đối tượng SQLSocket
            SQLSocket sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = sqlSocket.SelectWithCondition("1.1", "NguoiDung.HoTen =  '" + username + "'");
            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["Id"].ToString());
            }
            else
            {
                return -1;
            }
        }

    }
}
