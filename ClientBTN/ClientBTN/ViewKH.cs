using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientBTN
{
    public partial class ViewKH : Form
    {
        private int _id;
        private int _idND;
        private SQLSocket sqlSocket;
        public ViewKH(int idKH, int idND)
        {
            _id = idKH;
            _idND = idND;
            InitializeComponent();
        }

        private void ViewKH_Load(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng SQLSocket
            sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = sqlSocket.SelectWithCondition("2.1", "Id = " + _id); // Sử dụng "2.1" cho BKeHoach
            // Đặt dữ liệu cho DataGridView
            dgvDSKHFull.DataSource = dt;
            // Đảm bảo rằng các cột đã được tạo
            dgvDSKHFull.AutoGenerateColumns = true;

            // Ẩn cột "Id"
            //dgvDSKHFull.Columns["Id"].Visible = false;

            // Đặt kích thước cột "Ten" 
            dgvDSKHFull.Columns["Id"].Width = 25;
            dgvDSKHFull.Columns["Ten"].Width = 115;
            dgvDSKHFull.Columns["mota"].Width = 125;
            dgvDSKHFull.Columns["NgayBatDau"].Width = 100;
            dgvDSKHFull.Columns["NgayKetThuc"].Width = 100;
            dgvDSKHFull.Columns["IdAdmin"].Width = 50;

            // Ẩn tiêu đề của cột "Id"
            //dgvDSKHFull.RowHeadersVisible = false;


            LoadNhomCV();
            LoadThanhVN();
        }

        private void LoadNhomCV()
        {         
            // Khởi tạo đối tượng SQLSocket
            sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = sqlSocket.SelectWithCondition("4.1", "IdKeHoach = " + _id); // Sử dụng "4.1" cho BNhomCongViec
            // Đặt dữ liệu cho DataGridView
            dgvDsNhomCV.DataSource = dt;
            // Đảm bảo rằng các cột đã được tạo
            dgvDsNhomCV.AutoGenerateColumns = true;

            // Ẩn cột "Id"
            //dgvDsNhomCV.Columns["Id"].Visible = false;
            //dgvDsNhomCV.Columns["IdKeHoach"].Visible = false;

            // Đặt kích thước cột "Ten" 
            dgvDsNhomCV.Columns["Id"].Width = 25;
            dgvDsNhomCV.Columns["Ten"].Width = 320;
            dgvDsNhomCV.Columns["IdKeHoach"].Width = 70;

            // Ẩn tiêu đề của cột "Id"
            //dgvDsNhomCV.RowHeadersVisible = false;
        }

        private void LoadThanhVN()
        {   
            // Khởi tạo đối tượng SQLSocket
            sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = sqlSocket.SelectWithCondition("3.5", "IdKeHoach = " + _id); // Sử dụng "3.1" cho BThanhVienNhom
            // Đặt dữ liệu cho DataGridView
            dgvDsTVN.DataSource = dt;
            // Đảm bảo rằng các cột đã được tạo
            dgvDsTVN.AutoGenerateColumns = true;
            // Ẩn cột "Id"
            dgvDSKHFull.Columns["Id"].Visible = false;
            // Đặt kích thước cột "Ten" 
            dgvDsTVN.Columns["Id"].Width = 25;
            dgvDsTVN.Columns["IdNguoiDung"].Width = 80;
            dgvDsTVN.Columns["Quyen"].Width = 70;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //lấy ra id kế hoạch trong bảng kế hoạch 
            if (dgvDSKHFull.CurrentRow != null)
            {
                int idKH = (int)dgvDSKHFull.CurrentRow.Cells["Id"].Value;
                // Lấy dữ liệu từ DataGridView
                DataTable dt = (DataTable)dgvDsNhomCV.DataSource;
                // Lưu dữ liệu vào cơ sở dữ liệu
                foreach (DataRow row in dt.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        // Cập nhật dữ liệu đã sửa
                        sqlSocket.Update("4.3", (int)row["Id"], new string[] { row["Ten"].ToString(), row["IdKeHoach"].ToString() });
                    }
                    else if (row.RowState == DataRowState.Added)
                    {
                        // Thêm dữ liệu mới
                        sqlSocket.Insert("4.2", new string[] { row["Ten"].ToString(), idKH.ToString() });
                        // lấy ra id vừa mới thêm
                        DataTable dtNCV = sqlSocket.SelectWithCondition("4.6", "Ten =  N'" + row["Ten"].ToString() + "'");
                        int kpidNCV = int.Parse(dtNCV.Rows[0]["Id"].ToString());
                        sqlSocket.Insert("5.2", new string[] {" ", " ", "1/5/2024", "1/5/2024", "Đang thực hiện", _idND.ToString(), kpidNCV.ToString() });
                        DataTable dtNCVC = sqlSocket.SelectWithCondition("5.7", "Ten =  '" + " " + "'");
                        if (dtNCVC.Rows.Count > 0)
                        {   // lấy ra id công việc
                            int kpidCV = int.Parse(dtNCVC.Rows[0]["Id"].ToString());
                            sqlSocket.Insert("6.2", new string[] { " ", " ", "1/5/2024", "2/5/2024", "Đang thực hiện", _idND.ToString(), kpidCV.ToString() });
                        }
                    }
                }
                // Tải lại dữ liệu
                LoadNhomCV();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn
            int rowIndex = dgvDsNhomCV.CurrentCell.RowIndex;
            // Lấy dữ liệu từ DataGridView
            DataTable dt = (DataTable)dgvDsNhomCV.DataSource;
            // Lưu lại ID trước khi xóa
            int id = (int)dt.Rows[rowIndex]["Id"];
            // Xóa dòng khỏi DataGridView
            dgvDsNhomCV.Rows.RemoveAt(rowIndex);
            // Xóa dữ liệu từ cơ sở dữ liệu
            sqlSocket.Delete("4.4", id);
            // Tải lại dữ liệu
            LoadNhomCV();
        }

        private void btnLuuTV_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ DataGridView
            DataTable dt = (DataTable)dgvDsTVN.DataSource;
            // Lưu dữ liệu vào cơ sở dữ liệu
            foreach (DataRow row in dt.Rows)
            {               
                if (row.RowState == DataRowState.Modified)
                {                       
                    if (row["Quyen"].ToString() != "Admin")
                    {
                        // Cập nhật dữ liệu đã sửa
                            sqlSocket.Update("3.3", (int)row["Id"], new string[] { _id.ToString(), row["IdNguoiDung"].ToString(), row["Quyen"].ToString() });
                    }
                    else
                    {
                        if(GetIdNguoiDungwithAdmin(_id) == _idND)
                        {
                            // Cập nhật dữ liệu đã sửa
                            sqlSocket.Update("3.3", (int)row["Id"], new string[] { _id.ToString(), row["IdNguoiDung"].ToString(), row["Quyen"].ToString() });
                        }
                        else
                        {
                            MessageBox.Show("Chỉ admin của kế hoạch mới được sửa trường dữ liệu này", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        }
                    }
                else if (row.RowState == DataRowState.Added)
                {                      
                     if (row["Quyen"].ToString() != "Admin")
                     {
                         sqlSocket.Insert("3.2", new string[] { _id.ToString(), row["IdNguoiDung"].ToString(), row["Quyen"].ToString() });
                     }
                     else
                     {
                         if (KiemTraCoAdmin(_id) == true)
                         MessageBox.Show("Chỉ có thể có một tài khoản Admin cho mỗi kế hoạch.", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }    
                    
                }               
            }
            // Tải lại dữ liệu
            LoadThanhVN();
        }
        private bool KiemTraCoAdmin(int idKH)
        {
            // Khởi tạo đối tượng SQLSocket
            sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = sqlSocket.SelectWithCondition("3.5", "IdKeHoach = " + idKH + " AND Quyen = 'Admin'");
            // Kiểm tra xem có admin chưa
            return dt != null && dt.Rows.Count > 0;
        }

        private void btnXoaTV_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn
            int rowIndex = dgvDsTVN.CurrentCell.RowIndex;
            // Lấy dữ liệu từ DataGridView
            DataTable dt = (DataTable)dgvDsTVN.DataSource;
            // Lưu lại ID trước khi xóa
            int id = (int)dt.Rows[rowIndex]["Id"];

            if (GetIdNguoiDungwithAdmin(_id) == _idND)
            {
                // Xóa dòng khỏi DataGridView
                dgvDsTVN.Rows.RemoveAt(rowIndex);
                // Xóa dữ liệu từ cơ sở dữ liệu
                sqlSocket.Delete("3.4", id);
                // Tải lại dữ liệu
                LoadThanhVN();
            }
            else
            {
                MessageBox.Show("Chỉ admin của kế hoạch mới được xóa trường dữ liệu này", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int GetIdNguoiDungwithAdmin(int idKH)
        {
            // Khởi tạo đối tượng SQLSocket
            sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = sqlSocket.SelectWithCondition("3.5", "IdKeHoach = " + idKH + " AND Quyen ='Admin'");
            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["IdNguoiDung"].ToString());
            }
            else
            {
                return -1;
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvDsNhomCV.SelectedRows.Count > 0)
            {
                // Lấy ID từ cột "Id" của dòng được chọn
                int idNCV = Convert.ToInt32(dgvDsNhomCV.SelectedRows[0].Cells["Id"].Value);

                // Khởi tạo một đối tượng ViewKH với ID
                WorkList workList = new WorkList(idNCV, _idND);
                workList.Show();
                //this.Hide();
            }
           
        }
    }
}
