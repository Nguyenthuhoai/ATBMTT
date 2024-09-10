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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tb_login_name.TabIndex = 0;
            tb_login_pass.TabIndex = 1;
            cb_login_showPass.TabIndex = 2;
            btn_login.TabIndex = 3;
            lb_registerHere.TabIndex = 4;
        }

        private void lb_registerHere_Click(object sender, EventArgs e)
        {
            DangKi sForm = new DangKi();
            sForm.Show();
            this.Hide();
        }

        private void cb_login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_login_showPass.Checked)
            {
                tb_login_pass.PasswordChar = '\0';
            }
            else
            {
                tb_login_pass.PasswordChar = '*';
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {   
            // kiểm tra dữ liệu người dùng nhập từ giao diện
            if(tb_login_name.Text == ""  || tb_login_pass.Text == "")
            {
                MessageBox.Show("Hãy điền đầu đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            else
            {
                // Khởi tạo đối tượng SQLSocket
                SQLSocket sqlSocket = new SQLSocket();

                // Lấy tất cả dữ liệu từ cơ sở dữ liệu
                DataTable dt = sqlSocket.SelectAll("1.1");

                // Kiểm tra xem dữ liệu có tồn tại hay không
                if (dt != null)
                {
                    bool found = false;
                    // Duyệt qua tất cả các hàng trong DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        // Kiểm tra xem tên đăng nhập và mật khẩu có khớp với dữ liệu trong cơ sở dữ liệu hay không
                        if (row["HoTen"].ToString().Trim() == tb_login_name.Text.Trim() && row["MatKhau"].ToString().Trim() == tb_login_pass.Text.Trim())
                        {
                            // Nếu khớp, hiển thị thông báo và thoát khỏi phương thức
                            MessageBox.Show("Đăng nhập thành công!", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GiaoDienChinh giaoDienChinh = new GiaoDienChinh(tb_login_name.Text.Trim());
                            giaoDienChinh.Show();
                            this.Hide();
                            found = true;
                            break;
                        }
                    }
                    // Nếu không tìm thấy tên đăng nhập và mật khẩu khớp, hiển thị thông báo lỗi
                    if (!found)
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                      
                }              
            }                      
        }
    }
}
