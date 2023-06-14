using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace giaodien
{
    public partial class DangKy : Form
    {
       
        public DangKy()
        {
            InitializeComponent();
        }


        public bool CheckAccount(string ac)//check tài khoản, mật khẩu
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }
        public bool CheckEmail(string em)// check email
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string from, to, pass;
            from = "lenhungththcstt@gmail.com";
            to = textBox4_Email.Text;
            pass = "jsoxavmytkyrwifa";
            string Numrd_str;
            Random rd = new Random();
            Numrd_str = rd.Next(100000,999999).ToString();//CHUYỂN giá trị random về kiểu string
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            Regex.IsMatch(to, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            mail.From = new MailAddress(from);
            mail.Subject = "GROUP_4";
            mail.Body = "Mã định danh của bạn là:" + Numrd_str;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(mail);
                MessageBox.Show("Email send successfully!", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Email",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*
            //kiểm tra mã xác thực có đúng hay không?             
            if(codeRandom.Text != "" && codeRandom.Text != Numrd_str)
            {
                MessageBox.Show("Mã định danh không đúng vui lòng nhập lại.", "Thông báo");
            }  
            */
        }
        Modify modify = new Modify();

        private void button1_DangKy_Click(object sender, EventArgs e)
        {
            string tentk = textBox1_TenTaiKhoan.Text;
            string matkhau = textBox2_MatKhau.Text;
            string xnmatkhau = textBox3_XNMatKhau.Text;
            string email = textBox4_Email.Text;           
            if(!CheckAccount(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!");
                return;
            }
            if(codeRandom.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã định danh không được bỏ trống.", "Thông báo");
                return;
            }    
            if(!CheckAccount(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu dài 6-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!");
                return;
            }
            if(xnmatkhau != matkhau)
            {
                MessageBox.Show("Vui lòng xác nhập mật khẩu chính xác");
                return;
            }
            if(!CheckEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email!");
                return;
            }
            if(modify.TaiKhoans("Select * from TaiKhoan where Email = '" + email + "'").Count != 0)
            {
                MessageBox.Show("Email này đã được đăng ký vui lòng đăng ký email khác!");
                return;
            }
            try
            {
                string query = "Insert into TaiKhoan values ('" + tentk + "' ,'" + matkhau + "','" + email + "')";
                modify.Command(query);
                if (MessageBox.Show("Đăng ký thành công! bạn có muốn đăng nhập luôn không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch
            {
                {
                    MessageBox.Show("Tên tài khoản này đã được đăng ký!");
                }

            }
        }
    }
}
