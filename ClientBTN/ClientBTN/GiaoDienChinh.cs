using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientBTN
{
    public partial class GiaoDienChinh : Form
    {
        private string _username;
        private int _idND;
        private SQLSocket _sqlSocket;
        Timer tm = new Timer();
        public GiaoDienChinh(string username)
        {
            InitializeComponent();
            tm.Interval = 30000;
            tm.Tick += Tm_Tick;
            _username = username;
            _sqlSocket = new SQLSocket();
            DataTable id_nguoidung = _sqlSocket.SelectWithCondition("1.1", "HoTen = '" + _username + "'");
            _idND = int.Parse(id_nguoidung.Rows[0]["Id"].ToString());

        }

        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            lbUsername.Text = _username;
            lbId.Text = _idND.ToString();
            loadTenTVN();
            tm.Start();
            LoadData();
        }
        public void LoadData()
        {
            // Khởi tạo đối tượng SQLSocket
            _sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = _sqlSocket.SelectWithCondition("3.1", "KeHoach.IdAdmin = " + _idND + " OR ThanhVienNhom.IdNguoiDung = " + _idND); // Sử dụng "3.1" 

            btnView.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            //Tạo một DataTable mới chỉ chứa hai cột "Id" và "Ten"
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("Id", typeof(int));
            dtNew.Columns.Add("Ten", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                dtNew.Rows.Add(row["Id"], row["Ten"]);
            }


            // Đặt dữ liệu cho DataGridView
            dgvDanhSachKH.DataSource = dtNew;
            // Đảm bảo rằng các cột đã được tạo
            dgvDanhSachKH.AutoGenerateColumns = true;
            // Đặt kích thước cột "Id" và "Ten"
            dgvDanhSachKH.Columns["Id"].Width = 25;
            dgvDanhSachKH.Columns["Ten"].Width = 280;
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            LoadData(); 
        }

            private void dgvDanhSachKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem người dùng có click vào một dòng hợp lệ không
            {
                //btnAdd.Enabled = true;
                btnView.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvDanhSachKH.SelectedRows.Count > 0)
            {
                // Lấy ID từ cột "Id" của dòng được chọn
                int id = Convert.ToInt32(dgvDanhSachKH.SelectedRows[0].Cells["Id"].Value);

                // Khởi tạo một đối tượng ViewKH với ID
                ViewKH viewKH = new ViewKH(id, _idND);
                viewKH.Show();
                //this.Hide();
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            // Mở OpenFileDialog
            DialogResult result = openFileDialog1.ShowDialog();
            // Kiểm tra xem người dùng có chọn một tệp không
            if (result == DialogResult.OK)
            {
                // Lấy đường dẫn của tệp đã chọn
                string filePath = openFileDialog1.FileName;
                // Cập nhật ảnh của PictureBox
                pictureBox1.Image = Image.FromFile(filePath);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachKH.SelectedRows.Count > 0)
            {
                // Lấy ID từ cột "Id" của dòng được chọn
                int id = Convert.ToInt32(dgvDanhSachKH.SelectedRows[0].Cells["Id"].Value);

                // Khởi tạo một đối tượng ViewKH với ID
                UpdateKH updateKH = new UpdateKH(id);
                updateKH.Show();
                LoadData();
                //this.Hide();
            }           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddKH addKH = new AddKH(_username);
            addKH.Show();
            //this.Close();
            LoadData();
        }
   
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachKH.SelectedRows.Count > 0)
            {
                // Lấy ID từ cột "Id" của dòng được chọn
                int idKH = Convert.ToInt32(dgvDanhSachKH.SelectedRows[0].Cells["Id"].Value);

                _sqlSocket.DeleteCondition("3.6", "IdKeHoach = " + idKH + " AND IdNguoiDung = " + _idND);
               // _sqlSocket.DeleteCondition(" ", )

                // Khởi tạo đối tượng SQLSocket
                //SQLSocket sqlSocket = new SQLSocket();
                // Gọi hàm Delete
                int result = _sqlSocket.Delete("2.4", idKH);
                // Kiểm tra kết quả
                //if (result == -1)
                //{
                //    MessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //    MessageBox.Show("Xóa dữ liệu thành công.", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    LoadData();
                //}
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btnThemThanhVien_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachKH.SelectedRows.Count > 0)
            {
                int idKH = Convert.ToInt32(dgvDanhSachKH.SelectedRows[0].Cells["Id"].Value);
                // Lấy dòng được chọn từ ComboBox
                DataRowView selectedRow = (DataRowView)cbThanhVienNhom.SelectedItem;
                // Lấy giá trị tên người dùng từ cột "TenNguoiDung"
                string tenNguoiDung = selectedRow["HoTen"].ToString();
                string quyen = cbQuyen.SelectedItem.ToString().Trim();

                // Lấy ID người dùng từ tên người dùng
                int idND = GetIdNguoiDung(tenNguoiDung);

                // Kiểm tra xem người dùng đã tồn tại trong dự án hay chưa
                if (KiemtraTVTrongKH(idKH, idND))
                {
                    MessageBox.Show("Người dùng đã tồn tại trong dự án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra xem kế hoạch đã có admin chưa
                if (quyen == "Admin" && KiemTraAdmin(idKH))
                {
                    MessageBox.Show("Chỉ có thể có một tài khoản Admin cho mỗi kế hoạch.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Thêm vào cơ sở dữ liệu
                int result = _sqlSocket.Insert("3.2", new string[] { idKH.ToString(), idND.ToString(), quyen });
                //LoadData();
                cbThanhVienNhom.SelectedIndex = -1; // Đặt lại giá trị của combobox
                cbQuyen.SelectedIndex = -1;
                //if (result == -1)
                //{
                //    MessageBox.Show("Có lỗi xảy ra khi thêm thành viên.");
                //}
                //else
                //{
                //    MessageBox.Show("Thêm thành viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cbThanhVienNhom.SelectedIndex = -1; // Đặt lại giá trị của combobox
                //    cbQuyen.SelectedIndex = -1;
                //    //LoadData();
                //}
            }
        }
        private int GetIdNguoiDung(string hoTen)
        {
            // Khởi tạo đối tượng SQLSocket
            _sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = _sqlSocket.SelectWithCondition("1.1", "NguoiDung.HoTen =  '" + hoTen + "'");
            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["Id"].ToString());
            }
            else
            {
                return -1;
            }
        }
        private bool KiemTraAdmin(int idKH)
        {
            // Khởi tạo đối tượng SQLSocket
            _sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = _sqlSocket.SelectWithCondition("3.1", "IdKeHoach = " + idKH + " AND Quyen = 'Admin'");
            // Kiểm tra xem có admin chưa
            return dt != null && dt.Rows.Count > 0;
        }

        private bool KiemtraTVTrongKH( int idKH, int idND)
        {
            DataTable dt = _sqlSocket.SelectWithCondition("3.7", "IdKeHoach = " + idKH + "AND IdNguoiDung = " + idND);
            return dt != null && dt.Rows.Count > 0;
        }

        private void loadTenTVN()
        {
            DataTable dt = _sqlSocket.SelectAll("1.1");
            cbThanhVienNhom.DataSource = dt;
            cbThanhVienNhom.DisplayMember = "HoTen";

        }
    }
}
