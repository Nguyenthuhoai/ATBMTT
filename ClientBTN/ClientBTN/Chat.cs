 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ClientBTN
{
    public partial class Chat : Form
    {
        private string connectionString = @"Data Source=DESKTOP-68FB4LQ\MSSQLSERVER01;Initial Catalog=QLBTN;Integrated Security=True";


        private string _username;
        private System.Timers.Timer _timer; // Timer
        private SQLSocket sqlSocket;

        public Chat(string name)
        {
            InitializeComponent();
            _username = name;
        }

        private void StartTimer()
        {
            _timer = new System.Timers.Timer(10000); // 10 giây
            _timer.Elapsed += TimerElapsed;
            _timer.Enabled = true;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (tbTo.Text != null && tbFrom.Text != null)
            {
                String nguoiNhan = tbTo.Text.ToString();

                // Tao socket de gui tin nhan
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12000);


                // Gui tin nhan
                byte[] messageByte = Encoding.UTF8.GetBytes(nguoiNhan + "<|TACH|>?<|EOM|>");
                client.Connect(ep);
                if (!client.Connected)
                {
                    return;
                }
                client.Send(messageByte);

                // Nhan du lieu phan hoi tu server
                String message = "";

                // Nhan du lieu cho den khi nao ket thuc tin nhan tu server
                byte[] buffer = new byte[1024];
                int count = 0;
                while ((count = client.Receive(buffer)) > 0)
                {
                    message += Encoding.UTF8.GetString(buffer, 0, count);
                    if (message.IndexOf("<|EOM|>") > -1)
                    {
                        message = message.Replace("<|EOM|>", "").Replace("<|TACH|>", "`");
                        String nguoiGui = message.Split('`')[0];
                        String noiDung = message.Split('`')[1];
                        if (!String.IsNullOrEmpty(noiDung))
                            tbLichSu.Text += DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + nguoiGui + ": " + noiDung + "\r\n";
                        break;
                    }
                }
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form AddKH
            string nguoinhan = tbTo.Text;
            string nguoigui = tbFrom.Text;
            string noidung = tbNoiDung.Text;
            string thoigian = DateTime.Now.ToString(); // ngày giờ tại lúc bấm gửi


            // Gọi hàm Insert
            int newTinNhan = sqlSocket.Insert("8.2", new string[] { nguoinhan, nguoigui, noidung, thoigian });
            using (SqlConnection connection = new SqlConnection(connectionString))

                // Kiểm tra kết quả
                if (newTinNhan == -1)
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm dữ liệu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // mở kết nối
                    connection.Open();

                    tbNoiDung.Text = " ";
                    string query = "SELECT NguoiGui, NoiDung, ThoiGian FROM dbo.TinNhan";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Thực thi câu lệnh và lấy dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Xử lý dữ liệu ở đây

                            // Hiển thị dữ liệu lên TextBox
                            tbLichSu.Text += DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + " Đã gửi: " + tbNoiDung.Text + "\r\n";
                            tbLichSu.AppendText("Người gửi: " + reader["NguoiGui"].ToString() + "\r\n");
                            tbLichSu.AppendText(reader["NoiDung"].ToString() + "\r\n");
                        }
                    }
                    //MessageBox.Show("Thêm dữ liệu thành công.", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

        }



        private void Chat_Load(object sender, EventArgs e)
        {
            tbFrom.Text = _username;
            sqlSocket = new SQLSocket(); // Khởi tạo đối tượng sqlSocket

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Chat_Load(sender, e);
        }

        //private void ClearChat()
        //{
        //    tb
        //}
    }
}