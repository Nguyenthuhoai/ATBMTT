using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;


//thuật toán Vigenère cipher.
namespace giaodien
{
    public partial class Home : Form
    {
        byte[] bangChuCai;//mảng 1 chiều 
        byte[,] bangTra;//mảng 2 chiều 

        public Home()
        {
            InitializeComponent();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Multiselect = false;
            if (od.ShowDialog() == DialogResult.OK)
            {
                tbDuongDan.Text = od.FileName;
            }
        }
        private void Home_Load(object sender, EventArgs e)
        {
            rbMaHoa.Checked = true;
            // Khoi tao bang chu cai
            bangChuCai = new byte[256];
            for (int i = 0; i < 256; i++)
                bangChuCai[i] = Convert.ToByte(i);

            // Khoi tao bang tra
            bangTra = new byte[256, 256];
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    bangTra[i, j] = bangChuCai[(i + j) % 256];
                }
        }

        private void rbMaHoa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMaHoa.Checked)
            {
                rbGiaiMa.Checked = false;
            }
        }

        private void rbGiaiMa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGiaiMa.Checked)
            {
                rbMaHoa.Checked = false;
            }
        }

        private void button1_DangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                DangNhap dangNhap = new DangNhap();
                dangNhap.ShowDialog();
            }
        }

        int count = 0;
        Modify modify = new Modify();
        private void btThucHien_Click(object sender, EventArgs e)
        {
            // Kiem tra xem tep tin nguoi dung chon co ton tai hay ko
            if (!File.Exists(tbDuongDan.Text))
            {
                MessageBox.Show("Tệp tin không tồn tại. Bạn hãy chọn lại tệp tin.");
                return;
            }

            // Kiem tra xem nguoi dung da nhap mat khau hay chua

            string email = tbEmail.Text;
            string matkhau = tbMatKhau.Text;
            if (email.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập email!");
            }
            else if (matkhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
            }
            else
            {
                string query = "Select * from TaiKhoan where Email = '" + email + "' and MatKhau = '" + matkhau + "'";
                if (modify.TaiKhoans(query).Count != 0 && modify.TaiKhoans("Select * from TaiKhoan where Email = '" + email + "'").Count != 0)//tồn tại tài khoản 
                {
                    // Chuan bi du lieu de ma hoa hoac giai ma
                    try
                    {
                        // Doc noi dung tep tin
                        byte[] noiDungTepTin = File.ReadAllBytes(tbDuongDan.Text);
                        // Sinh khoa tu mat khau
                        byte[] matKhauByte = Encoding.ASCII.GetBytes(tbMatKhau.Text);
                        byte[] khoa = new byte[noiDungTepTin.Length];
                        for (int i = 0; i < khoa.Length; i++)
                            khoa[i] = matKhauByte[i % matKhauByte.Length];

                        // Thuc hien cong viec
                        byte[] ketQua = new byte[noiDungTepTin.Length];
                        if (rbMaHoa.Checked)
                        {
                            progressBar1.Minimum = 0;//thêm
                            progressBar1.Maximum = noiDungTepTin.Length;//thêm
                            // Ma hoa tep tin
                            for (int i = 0; i < noiDungTepTin.Length; i++)
                            {
                                byte kyTuCanMa = noiDungTepTin[i];
                                byte kyTuKhoa = khoa[i];
                                int viTriKyTuCanMa = -1, viTriKyTuKhoa = -1;
                                for (int j = 0; j < 256; j++)
                                    if (bangChuCai[j] == kyTuCanMa)
                                    {
                                        viTriKyTuCanMa = j;
                                        break;
                                    }
                                for (int j = 0; j < 256; j++)
                                    if (bangChuCai[j] == kyTuKhoa)
                                    {
                                        viTriKyTuKhoa = j;
                                        break;
                                    }
                                ketQua[i] = bangTra[viTriKyTuKhoa, viTriKyTuCanMa];
                                progressBar1.Value = i + 1;//mỗi lần vòng lặp được thực hiện xong sẽ tăng giá trị của progressbar lên 1 đơn vị bằng các sử dụng phương thức Value
                            }
                            // Luu ket qua vao tep tin
                            String ext = Path.GetExtension(tbDuongDan.Text);
                            SaveFileDialog sd = new SaveFileDialog();
                            sd.Filter = "File type (*" + ext + ") | *" + ext;//Câu lệnh này sẽ thiết lập bộ lọc cho hộp thoại lưu file. Nó sẽ chỉ cho phép người dùng lưu file có phần mở rộng giống với file ban đầu  
                            sd.FileName = Path.GetFileName(tbDuongDan.Text);
                            if (sd.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllBytes(sd.FileName, ketQua);
                                if (sd.FileName != tbDuongDan.Text)
                                {
                                    //xoá tệp tin gốc
                                    File.SetAttributes(tbDuongDan.Text, FileAttributes.Hidden);
                                }
                            }
                        }
                        else
                        {
                            progressBar1.Minimum = 0;//giá trị tối thiểu
                            progressBar1.Maximum = noiDungTepTin.Length;//giá trị tối đa 
                            // Giai ma tep tin
                            for (int i = 0; i < noiDungTepTin.Length; i++)
                            {
                                byte kyTuCanMa = noiDungTepTin[i];
                                byte kyTuKhoa = khoa[i];
                                int viTriKyTuCanMa = -1, viTriKyTuKhoa = -1;
                                for (int j = 0; j < 256; j++)
                                    if (bangChuCai[j] == kyTuKhoa)
                                    {
                                        viTriKyTuKhoa = j;
                                        break;
                                    }
                                for (int j = 0; j < 256; j++)
                                    if (bangTra[viTriKyTuKhoa, j] == kyTuCanMa)
                                    {
                                        viTriKyTuCanMa = j;
                                        break;
                                    }
                                ketQua[i] = bangChuCai[viTriKyTuCanMa];
                                progressBar1.Value = i + 1;
                            }
                            // Luu ket qua vao tep tin
                            String ext = Path.GetExtension(tbDuongDan.Text);
                            SaveFileDialog sd = new SaveFileDialog();
                            sd.Filter = "File type (*" + ext + ") | *" + ext;//Câu lệnh này sẽ thiết lập bộ lọc cho hộp thoại lưu file. Nó sẽ chỉ cho phép người dùng lưu file có phần mở rộng giống với file ban đầu  
                            sd.FileName = Path.GetFileName(tbDuongDan.Text);
                            if (sd.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllBytes(sd.FileName, ketQua);
                                if(sd.FileName != tbDuongDan.Text)
                                {
                                    //xoá tệp tin gốc
                                    File.SetAttributes(tbDuongDan.Text, FileAttributes.Hidden);
                                }
                            }                        
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Tệp tin đang được sử dụng bởi chương trình khác, hãy đóng chương trình đang sử dụng tệp tin và thử lại.");
                        return;
                    }
                }

                if (modify.TaiKhoans(query).Count == 0)
                {
                    MessageBox.Show("Email hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    count++;

                    if (count == 2)
                    {
                        //thông báo cho người dùng biết do nhập mật khâu sai quá 5 lần nên file bị xoá thông tin chi tiết sẽ gửi vào gmail của bạn
                        MessageBox.Show("Nhập sai quá 6 lần file sẽ bị xoá. Thông tin chi tiết về tệp sẽ được gửi về gmail của bạn", "Thông báo");
                    }

                    else if (count == 6)
                    {
                        MessageBox.Show("Do bạn nhập sai mật khẩu hoặc email quá 5 lần nên chúng tôi sẽ xoá file gốc và gửi thông tin về email của bạn!.Vui lòng đợi để nhận thông báo gửi thành công.", "Thông báo");
                        //gửi tệp tin gốc vào email
                        string from, to, pass;
                        from = "lenhungththcstt@gmail.com";
                        to = tbEmail.Text;
                        pass = "jsoxavmytkyrwifa";
                        MailMessage mail = new MailMessage();
                        mail.To.Add(to);
                        Regex.IsMatch(to, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        mail.From = new MailAddress(from);
                        mail.Subject = "GROUP_4";
                        
                        string layMatKhau = "Select MatKhau form TaiKhoan where Email'" + email + "'";
                        //đọc nội dung tệp tin
                        byte[] noiDungTep = File.ReadAllBytes(tbDuongDan.Text);
                        //sinh khoá từ mật khẩu
                        byte[] matkhauuByte = Encoding.ASCII.GetBytes(layMatKhau);
                        byte[] khoaa = new byte[noiDungTep.Length];
                        for (int b = 0; b< khoaa.Length;b++)
                            khoaa[b] = matkhauuByte[b % matkhauuByte.Length];
                                                                     
                        //thực hiện công việc
                        byte[] ketQuaa = new byte[noiDungTep.Length];
                        if(rbMaHoa.Checked)
                        {
                            Attachment attachment = new Attachment(tbDuongDan.Text);
                            mail.Attachments.Add(attachment);
                        }
                        else
                        {
                            //sử dụng tiến trình 
                            progressBar1.Minimum = 0;//giá trị tối thiểu
                            progressBar1.Maximum = noiDungTep.Length;// giá trị tối đa
                            //giải mã tệp tin
                            for(int a = 0; a<noiDungTep.Length; a++)
                            {
                                byte kyTuCanMaa = noiDungTep[a];
                                byte kyTuKhoaa = khoaa[a];
                                int viTriKyTuCanMaa = -1, viTriKyTuKhoaa = -1;
                                for(int c =0;c<256; c++)
                                    if (bangChuCai[ c] == kyTuKhoaa)
                                    {
                                        viTriKyTuKhoaa = c;
                                        break;
                                    }                   
                                for(int c=0;c<256;c++)
                                    if (bangTra[viTriKyTuKhoaa,c] == kyTuCanMaa)
                                    {
                                        viTriKyTuCanMaa = c;
                                        break;
                                    }
                                ketQuaa[a] = bangChuCai[viTriKyTuCanMaa];
                                progressBar1.Value = a + 1;
                            }
                       
                                //lưu kết quả vào tệp tin
                                string ext = Path.GetExtension(tbDuongDan.Text);
                                string tenTepTin = Path.GetFileNameWithoutExtension(tbDuongDan.Text);
                                string duongDan = Path.GetDirectoryName(tbDuongDan.Text);
                                string duongDanMoi = duongDan + "\\" + tenTepTin + ext;
                                File.WriteAllBytes(duongDanMoi, ketQuaa);
                                //đính kèm tệp tin vào email                               
                                File.WriteAllBytes(duongDanMoi, ketQuaa);
                                Attachment attachment = new Attachment(duongDanMoi);
                                mail.Attachments.Add(attachment);
                            }

                        //tiếp tục gửi tin cho email
                        mail.Body = "Do có người cố ý xâm nhập vào file của bạn. Người đó đã nhập sai mật khẩu quá 5 lần. GROUP_4 chúng tôi đã xoá file đó đi và gửi bạn file gốc. Cảm ơn đã bạn đã sử dụng dịch vụ của chúng tôi!";

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(from, pass);
                        try
                        {
                            smtp.Send(mail);
                            MessageBox.Show("Email send successfull!", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //xoá tệp tin gốc
                        File.SetAttributes(tbDuongDan.Text, FileAttributes.Hidden);
                    }

                    else if (count == 7)
                    {
                        this.Hide();
                        DangNhap dangNhap = new DangNhap();
                        dangNhap.ShowDialog();
                    }
                }
            }
        }
    }
}


   









