using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientBTN
{
    public partial class WorkList : Form
    {
        private int _idNCV;
        private int _idND;
        private string oldStatusCV;
        private string oldStatusCVC;
        private int selectedCVCId;
        private bool isStatusCVCChanged = false;
        private int selectedCVId;
        private bool isStatusCVChanged = false;
        private SQLSocket sqlSocket;
        public WorkList(int idNCV, int idND)
        {
            InitializeComponent();
            _idNCV = idNCV;
            _idND = idND;
            //dgvTTCV.CellClick += new DataGridViewCellEventHandler(dvgTTCV_CellClick);
        }

        private void LoadCongViec()
        {
            // Khởi tạo đối tượng SQLSocket
            sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = sqlSocket.SelectWithCondition("5.1", "IdNhomCV = " + _idNCV); // Sử dụng "5.1" cho BCongViec
            // Đặt dữ liệu cho DataGridView
            dgvTTCV.DataSource = dt;
            // Đảm bảo rằng các cột đã được tạo
            dgvTTCV.AutoGenerateColumns = true;
            // Đặt kích thước cột "Ten" 
            dgvTTCV.Columns["Id"].Width = 25;
            dgvTTCV.Columns["Ten"].Width = 100;
            dgvTTCV.Columns["MoTa"].Width = 100;
            dgvTTCV.Columns["NgayBatDau"].Width = 100;
            dgvTTCV.Columns["NgayKetThuc"].Width = 100;
            dgvTTCV.Columns["IdNguoiThucHien"].Width = 100;
            //dgvTTCV.Columns["IdNhomCV"].Width = 100;

            // Kiểm tra xem có dòng nào được chọn không
            if (dgvTTCV.CurrentRow != null)
            {
                // Lấy ID của công việc hiện tại từ DataGridView
                selectedCVId = (int)dgvTTCV.CurrentRow.Cells["Id"].Value;
                // Load trạng thái công việc
                LoadTrangThaiCV(selectedCVId);
            }
            oldStatusCV = cbTrangThaiCV.Text;
        }

        private void LoadCongViecCon()
        {
            // Lấy ID của công việc con từ dgvDanhsachCVC
            if (dgvTTCV.CurrentRow != null)
            {
                int idCV = (int)dgvTTCV.CurrentRow.Cells["Id"].Value;
                // Khởi tạo đối tượng SQLSocket
                sqlSocket = new SQLSocket();
                // Lấy dữ liệu từ server
                DataTable dt = sqlSocket.SelectWithCondition("6.1", "IdCongViec = " + idCV); // Sử dụng "5.1" cho BCongViec
                // Đặt dữ liệu cho DataGridView

                if (dt != null)
                {
                    dgvDanhsachCVC.DataSource = dt;
                }
                else
                {
                    // Tạo DataTable rỗng với cùng cấu trúc cột
                    DataTable dtEmpty = new DataTable();
                    dtEmpty.Columns.Add("Id", typeof(int));
                    dtEmpty.Columns.Add("Ten", typeof(string));
                    dtEmpty.Columns.Add("MoTa", typeof(string));
                    dtEmpty.Columns.Add("NgayBatDau", typeof(DateTime));
                    dtEmpty.Columns.Add("NgayKetThuc", typeof(DateTime));
                    dtEmpty.Columns.Add("IdNguoiThucHien", typeof(int));
                    // dtEmpty.Columns.Add("IdCongViec", typeof(int));

                    dgvDanhsachCVC.DataSource = dtEmpty;
                }

                // Đảm bảo rằng các cột đã được tạo
                dgvDanhsachCVC.AutoGenerateColumns = false; // Tắt tự động tạo cột
                dgvDanhsachCVC.Columns["Id"].DataPropertyName = "Id";
                dgvDanhsachCVC.Columns["Ten"].DataPropertyName = "Ten";
                dgvDanhsachCVC.Columns["MoTa"].DataPropertyName = "MoTa";
                dgvDanhsachCVC.Columns["NgayBatDau"].DataPropertyName = "NgayBatDau";
                dgvDanhsachCVC.Columns["NgayKetThuc"].DataPropertyName = "NgayKetThuc";
                dgvDanhsachCVC.Columns["IdNguoiThucHien"].DataPropertyName = "IdNguoiThucHien";
                // dgvDanhsachCVC.Columns["IdCongViec"].DataPropertyName = "IdCongViec";
                //Đặt kích thước cột "Ten"
                dgvDanhsachCVC.Columns["Id"].Width = 25;
                dgvDanhsachCVC.Columns["Ten"].Width = 100;
                dgvDanhsachCVC.Columns["MoTa"].Width = 100;
                dgvDanhsachCVC.Columns["NgayBatDau"].Width = 100;
                dgvDanhsachCVC.Columns["NgayKetThuc"].Width = 100;
                dgvDanhsachCVC.Columns["IdNguoiThucHien"].Width = 100;
                //dgvDanhsachCVC.Columns["IdCongViec"].Width = 100;
            }
            // Lấy ID của công việc con từ dgvDanhsachCVC
            if (dgvDanhsachCVC.CurrentRow != null)
            {
                selectedCVCId = (int)dgvDanhsachCVC.CurrentRow.Cells["Id"].Value;
                // Load trạng thái công việc con
                LoadTrangThaiCVC(selectedCVCId);
                LoadDsTep(selectedCVCId);
            }
            oldStatusCVC = cbTrangThaiCVC.Text;
            
        }
     
        private void WorkList_Load(object sender, EventArgs e)
        {
            LoadCongViec();
            LoadCongViecCon();
            // Thêm sự kiện CellBeginEdit cho dgvTTCV
            dgvTTCV.CellBeginEdit += dgvTTCV_CellBeginEdit;
            // 
            dgvDanhsachCVC.CellBeginEdit += dgvDanhsachCVC_CellBeginEdit;
        }

        private void LoadTrangThaiCV(int idCV)
        {
            //// Lấy dữ liệu từ server cho công việc
            //DataTable dtCV = sqlSocket.SelectWithCondition("5.5", "Id = " + idCV); // Sử dụng "5.1" cho BCongViec
            //if (dtCV != null && dtCV.Rows.Count > 0)
            //{
            //    // Đặt trạng thái cho cbTrangThaiCV
            //    cbTrangThaiCV.Text = dtCV.Rows[0]["TrangThai"].ToString();
            //}

            // Kiểm tra xem có dòng nào được chọn không
            if (dgvTTCV.CurrentRow != null)
            {
                // Lấy ID của công việc hiện tại từ DataGridView
                selectedCVId = (int)dgvTTCV.CurrentRow.Cells["Id"].Value;

                // Lấy dữ liệu từ server cho công việc
                DataTable dtCV = sqlSocket.SelectWithCondition("5.5", "Id = " + selectedCVId); // Sử dụng "5.1" cho BCongViec
                if (dtCV != null && dtCV.Rows.Count > 0)
                {
                    // Đặt trạng thái cho cbTrangThaiCV
                    cbTrangThaiCV.Text = dtCV.Rows[0]["TrangThai"].ToString();
                }
            }
        }

        private void LoadTrangThaiCVC(int idCVC)
        {
            // Lấy dữ liệu từ server cho công việc con
            DataTable dtCVC = sqlSocket.SelectWithCondition("6.5", "Id = " + idCVC); // Sử dụng "6.5"
            if (dtCVC != null && dtCVC.Rows.Count > 0)
            {
                // Đặt trạng thái cho cbTrangThaiCVC
                cbTrangThaiCVC.Text = dtCVC.Rows[0]["TrangThai"].ToString();
            }
        }

        private int GetIdAdmin(int idNCV)
        {
            // Khởi tạo đối tượng SQLSocket
            sqlSocket = new SQLSocket();
            // Lấy dữ liệu từ server
            DataTable dt = sqlSocket.SelectWithCondition("4.5", "NhomCongViec.Id = " + idNCV);
            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["IdAdmin"].ToString());
            }
            else
            {
                return -1;
            }
        }
        private void btnLuuCV_Click_1(object sender, EventArgs e)
        {          
            // Lấy dữ liệu từ DataGridView
            DataTable dt = (DataTable)dgvTTCV.DataSource;
            // Kiểm tra xem người dùng hiện tại có phải là admin không
            bool isAdmin = GetIdAdmin(_idNCV) == _idND;
            // Lưu dữ liệu vào cơ sở dữ liệu
            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["Id"] == selectedCVId && (row.RowState == DataRowState.Modified || isStatusCVChanged))
                {
                    // Lấy ID của công việc hiện tại từ DataGridView
                    //int idCV = (int)row["Id"];

                    // Lấy trạng thái mới từ ComboBox
                    string newStatusCV = cbTrangThaiCV.Text;

                    // Kiểm tra xem người dùng có sửa cbTrangThai hay không
                    if (newStatusCV == "Hoàn thành")
                    {
                        // Người dùng đã sửa cbTrangThai
                        if (isAdmin)
                        {
                            // Cập nhật trạng thái công việc
                            sqlSocket.Update("5.3", selectedCVId, new string[] {row["Ten"].ToString(), row["MoTa"].ToString(), row["NgayBatDau"].ToString(), row["NgayKetThuc"].ToString(),
                     newStatusCV, row["IdNguoiThucHien"].ToString(), _idNCV.ToString() });
                        }
                        else
                        {
                            MessageBox.Show("Chỉ admin của kế hoạch mới được sửa trường dữ liệu này", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break; // Thoát khỏi vòng lặp sau khi hiển thị thông báo
                        }
                    }
                    else if (newStatusCV == "Đang thực hiện")
                    {
                        continue;
                    }
                    else
                    {
                        // Người dùng không sửa cbTrangThai, cập nhật dữ liệu khác
                        sqlSocket.Update("5.3", selectedCVId, new string[] {row["Ten"].ToString(), row["MoTa"].ToString(), row["NgayBatDau"].ToString(), row["NgayKetThuc"].ToString(),
                    cbTrangThaiCV.Text, row["IdNguoiThucHien"].ToString(), _idNCV.ToString() });

                    }
                }
                else if (row.RowState == DataRowState.Added)
                {
                    // Thêm công việc mới
                    int newCV = sqlSocket.Insert("5.2", new string[] {row["Ten"].ToString(), row["MoTa"].ToString(), row["NgayBatDau"].ToString(), row["NgayKetThuc"].ToString(),
                "Đang thực hiện", row["IdNguoiThucHien"].ToString(), _idNCV.ToString() });
                    //lấy ra id của cv mới tạo
                   //DataTable dtCV = sqlSocket.SelectWithCondition("5.7", "Ten =  N'" + row["Ten"].ToString() + "'");
                    //if (dtCV.Rows.Count > 0)
                    //{
                        //lấy id nhóm cv mới thêm
                        ///int kpidCV = int.Parse(dtCV.Rows[0]["Id"].ToString());
                        sqlSocket.Insert("6.2", new string[] {" ", " ", "1/5/2024", "2/5/2024",
                        "Đang thực hiện", _idND.ToString(),  newCV.ToString() });
                    //}
                }
            }
            isStatusCVChanged = false;
            // Sau khi lưu dữ liệu, tải lại dữ liệu cho dgvTTCV và dgvDanhsachCVC
            LoadCongViec();
        }


        private void btnXoaCV_Click(object sender, EventArgs e)
        {
            if (dgvTTCV.SelectedRows.Count > 0)
            {
                // Lấy ID từ cột "Id" của dòng được chọn
                int idCongViec = Convert.ToInt32(dgvTTCV.SelectedRows[0].Cells["Id"].Value);

                sqlSocket.DeleteCondition("6.7", "IdCongViec = " + idCongViec);

                sqlSocket.DeleteCondition("5.4", "IdCongViec = " + idCongViec);

                // Khởi tạo đối tượng SQLSocket
                //SQLSocket sqlSocket = new SQLSocket();
                // Gọi hàm Delete
                int result = sqlSocket.Delete("5.6", idCongViec);
                LoadCongViec();
                //// Kiểm tra kết quả
                //if (result == -1)
                //{
                //    MessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //    MessageBox.Show("Xóa dữ liệu thành công.", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    // Tải lại dữ liệu cho dgvTTCV và dgvDanhsachCVC
                //    LoadCongViec();
                //}
            }
        }

        private void btnLuuCVC_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ DataGridView
            DataTable dt = (DataTable)dgvDanhsachCVC.DataSource;
            // Kiểm tra xem người dùng hiện tại có phải là admin không
            bool isAdmin = GetIdAdmin(_idNCV) == _idND;

            //Lưu dữ liệu vào cơ sở dữ liệu
            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["Id"] == selectedCVCId && (row.RowState == DataRowState.Modified || isStatusCVCChanged))
                {
                    // Lấy trạng thái mới từ ComboBox
                    string newStatusCVC = cbTrangThaiCVC.Text;

                    // Kiểm tra xem người dùng có sửa cbTrangThai hay không
                    if (newStatusCVC != "Hoàn thành")
                    {
                        // Người dùng đã sửa cbTrangThai
                        if (isAdmin)
                        {
                            // Cập nhật trạng thái công việc
                            sqlSocket.Update("6.3", selectedCVCId, new string[] {row["Ten"].ToString(), row["MoTa"].ToString(), row["NgayBatDau"].ToString(), row["NgayKetThuc"].ToString(),
                     newStatusCVC, row["IdNguoiThucHien"].ToString(), selectedCVId.ToString() });
                        }
                        else
                        {
                            MessageBox.Show("Chỉ admin của kế hoạch mới được sửa trường dữ liệu này", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break; // Thoát khỏi vòng lặp sau khi hiển thị thông báo
                        }
                    }
                    else if (newStatusCVC == "Đang thực hiện")
                    {
                        continue;
                    }
                    else
                    {
                        // Người dùng không sửa cbTrangThai, cập nhật dữ liệu khác
                        sqlSocket.Update("6.3", selectedCVCId, new string[] {row["Ten"].ToString(), row["MoTa"].ToString(), row["NgayBatDau"].ToString(), row["NgayKetThuc"].ToString(),
                    cbTrangThaiCVC.Text, row["IdNguoiThucHien"].ToString(),  selectedCVId.ToString() });
                    }
                }
                else if (row.RowState == DataRowState.Added)
                {
                    // Thêm công việc mới
                    sqlSocket.Insert("6.2", new string[] {row["Ten"].ToString(), row["MoTa"].ToString(), row["NgayBatDau"].ToString(), row["NgayKetThuc"].ToString(),
                "Đang thực hiện", row["IdNguoiThucHien"].ToString(),  selectedCVId.ToString() });
                }
            }
            isStatusCVChanged = false;
            // Sau khi lưu dữ liệu, tải lại dữ liệu cho dgvTTCV và dgvDanhsachCVC
            LoadCongViecCon();
        }

        private void cbTrangThaiCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            isStatusCVChanged = true;
        }

        private void cbTrangThaiCVC_SelectedIndexChange(object sender, EventArgs e)
        {
            isStatusCVCChanged = true;
        }

        private void dgvTTCV_SelectionChanged(object sender, EventArgs e)
        {
            // Lấy ID của công việc hiện tại từ DataGridView
            if (dgvTTCV.CurrentRow != null)
            {
                selectedCVId = (int)dgvTTCV.CurrentRow.Cells["Id"].Value;
                // Tải lại dữ liệu cho dgvDanhsachCVC dựa trên idCV
                LoadCongViecCon();
                LoadTrangThaiCV(selectedCVId);
            }
        }

        private void dgvDanhsachCVC_SelectionChanged(object sender, EventArgs e)
        {
            // Lấy ID của công việc con hiện tại từ DataGridView
            if (dgvDanhsachCVC.CurrentRow != null)
            {
                selectedCVCId = (int)dgvDanhsachCVC.CurrentRow.Cells["Id"].Value;
                // Load trạng thái công việc con
                LoadTrangThaiCVC(selectedCVCId);
                LoadDsTep(selectedCVCId);
            }
        }


        private void btnXoaCVC_Click(object sender, EventArgs e)
        {
            if (dgvDanhsachCVC.SelectedRows.Count > 0)
            {
                // Lấy ID từ cột "Id" của dòng được chọn
                int idCVC = Convert.ToInt32(dgvDanhsachCVC.SelectedRows[0].Cells["Id"].Value);

                // Gọi hàm Delete
                int result = sqlSocket.Delete("6.4", idCVC);
                LoadCongViec();
                // Kiểm tra kết quả
                //if (result == -1)
                //{
                //    MessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //    MessageBox.Show("Xóa dữ liệu thành công.", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    // Tải lại dữ liệu cho dgvTTCV và dgvDanhsachCVC
                //    LoadCongViec();
                //}
            }
        }

        private void pcdinhKemTep_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy thông tin tệp
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);
                    DateTime currentTime = DateTime.Now;

                    // đọc nội dung tệp
                    string fileContent = File.ReadAllText(filePath);

                    // Hiển thị thông tin tệp lên danh sách (lsbDsTepTin)
                    lsbDsTepTin.Items.Add($"ID Công Viêc Con: {selectedCVCId}- {fileName} - {currentTime} - ID Người tải tệp: {_idND}");

                    int newDULIEU = sqlSocket.Insert("7.2", new string[] { selectedCVCId.ToString(), _idND.ToString(), fileName, currentTime.ToString("yyyy/MM/dd"), fileContent });

                    //// Kiểm tra kết quả
                    //if (newDULIEU == -1)
                    //{
                    //    MessageBox.Show("Có lỗi xảy ra khi thêm dữ liệu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Thêm dữ liệu thành công.", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
        }
        private void LoadMucDoCVC()
        {
            // Lấy ID của công việc hiện tại từ DataGridView
            if (dgvDanhsachCVC.CurrentRow != null)
            {
                selectedCVCId = (int)dgvDanhsachCVC.CurrentRow.Cells["Id"].Value;
                // Lấy dữ liệu từ server
                DataTable dtTimeKetThuc = sqlSocket.SelectWithCondition("6.6", "Id = " + selectedCVCId);

                // Lấy dữ liệu từ server
                DataTable dtTimeUpdate = sqlSocket.SelectWithCondition("7.1", "IdCongViecCon = " + selectedCVCId);

                // Kiểm tra và hiển thị kết quả
                if (dtTimeKetThuc != null && dtTimeKetThuc.Rows.Count > 0)
                {
                    DateTime timeKetThuc = Convert.ToDateTime(dtTimeKetThuc.Rows[0]["NgayKetThuc"]);

                    if (dtTimeUpdate != null && dtTimeUpdate.Rows.Count > 0)
                    {
                        DateTime timeUpdate = Convert.ToDateTime(dtTimeUpdate.Rows[0]["ThoiGianUpdate"]);

                        if (timeKetThuc > timeUpdate)
                        {
                            // Hiển thị "Hoàn thành đúng hạn"
                            tbMucDoCVC.Text = "Hoàn thành đúng hạn";
                        }
                        else
                        {
                            // Hiển thị "Hoàn thành trễ"
                            tbMucDoCVC.Text = "Hoàn thành trễ";
                        }
                    }
                    else
                    {
                        // Xử lý khi không có dữ liệu
                        tbMucDoCVC.Text = "Chưa hoàn thành";
                    }
                }
                else 
                {
                    tbMucDoCVC.Text = " ";
                }
            }
        }


        private void LoadDsTep(int idCVC)
        {
            // Xóa bỏ các mục cũ trong danh sách
            lsbDsTepTin.Items.Clear();

            // Lấy dữ liệu từ server
            DataTable dt = sqlSocket.SelectWithCondition("7.5", "IdCongViecCon = " + idCVC);

            if (dt != null)
            {
                // Hiển thị thông tin từ DataTable lên danh sách (lsbDsTepTin)
                foreach (DataRow row in dt.Rows)
                {
                    int idCV = Convert.ToInt32(row["IdCongViecCon"]);
                    int idND = Convert.ToInt32(row["IdNguoiUpdateTep"]);
                    string tentep = row["TenTep"].ToString();
                    DateTime uploadTime = Convert.ToDateTime(row["ThoiGianUpdate"]);

                    // Thêm thông tin vào danh sách
                    lsbDsTepTin.Items.Add($"ID Công Việc Con: {idCV} - Tên tệp: {tentep} - Thời gian tải lên: {uploadTime} - ID Người tải tệp: {idND}");
                }
            }
            else
            {
                // Xử lý khi không có dữ liệu
                lsbDsTepTin.Items.Add("Không có dữ liệu tệp.");
            }
            LoadMucDoCVC();
        }

        private void dgvTTCV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Kiểm tra nếu trạng thái là "Hoàn thành", vô hiệu hóa chỉnh sửa
                if (cbTrangThaiCV.Text == "Hoàn thành")
                {
                    e.Cancel = true;
                    dgvTTCV.Rows[e.RowIndex].Cells["Id"].ReadOnly = true;
                    dgvTTCV.Rows[e.RowIndex].Cells["Ten"].ReadOnly = true;
                    dgvTTCV.Rows[e.RowIndex].Cells["MoTa"].ReadOnly = true;
                    dgvTTCV.Rows[e.RowIndex].Cells["NgayBatDau"].ReadOnly = true;
                    dgvTTCV.Rows[e.RowIndex].Cells["NgayKetThuc"].ReadOnly = true;
                    dgvTTCV.Rows[e.RowIndex].Cells["IdNguoiThucHien"].ReadOnly = true;
                }
            }
        }

        private void dgvDanhsachCVC_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(cbTrangThaiCVC.Text == "Hoàn thành")
            {
                e.Cancel = true;
                dgvDanhsachCVC.Rows[e.RowIndex].Cells["Id"].ReadOnly = true;
                dgvDanhsachCVC.Rows[e.RowIndex].Cells["Ten"].ReadOnly = true;
                dgvDanhsachCVC.Rows[e.RowIndex].Cells["MoTa"].ReadOnly = true;
                dgvDanhsachCVC.Rows[e.RowIndex].Cells["NgayBatDau"].ReadOnly = true;
                dgvDanhsachCVC.Rows[e.RowIndex].Cells["NgayKetThuc"].ReadOnly = true;
                dgvDanhsachCVC.Rows[e.RowIndex].Cells["IdNguoiThucHien"].ReadOnly = true;
            }    
        }
    }
}
