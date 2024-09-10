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
    public partial class DangKi : Form
    {
        public DangKi()
        {
            InitializeComponent();
            tb_signup_name.TabIndex = 0;
            tb_signup_pass.TabIndex = 1;
            cb_signup_showPass.TabIndex = 2;
            btn_signup.TabIndex = 3;
            lb_loginHere.TabIndex = 4;
        }

        private void lb_loginHere_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (tb_signup_name.Text == "" || tb_signup_pass.Text == "" || tb_signup_pass.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // Duyệt qua tất cả các hàng trong DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        // Kiểm tra xem tên đăng nhập đã tồn tại trong cơ sở dữ liệu hay không
                        if (row["HoTen"].ToString() == tb_signup_name.Text)
                        {
                            // Nếu tồn tại, hiển thị thông báo và thoát khỏi phương thức
                            MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng nhập tên khác!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Nếu tên đăng nhập không tồn tại, tiến hành đăng ký
                    string[] data = { tb_signup_name.Text, tb_signup_pass.Text };
                    int dem = sqlSocket.Insert("1.2", data);
                    if (dem == 1)
                    {
                        MessageBox.Show("Đăng ký thành công!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 lform = new Form1();
                        lform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thất bại!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cb_signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_signup_showPass.Checked)
            {
                tb_signup_pass.PasswordChar = '\0';
            }
            else
            {
                tb_signup_pass.PasswordChar = '*';
            }
        }
    }
}
