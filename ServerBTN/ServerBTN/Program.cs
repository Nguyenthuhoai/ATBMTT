using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.IO;
using System.Globalization;

namespace ServerBTN
{
    class Program
    {
        static void Main(string[] args)
        {   
            // tạo 1 socket máy chủ svSocket để lắng nghe kết nói từ máy khách
            // máy chỉ được liên kết với địa chỉ IP và cổng 12000
            Socket svSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 56000);
            svSocket.Bind(iep);
            svSocket.Listen(100);
            // Xử lý dữ liệu từ máy khách
            // khi máy khách kết nối, máy chủ chấp nhận kết nối và tạo 1 socket máy khách (client)
            // dữ liệu từ máy khách được nhận và gắn vào biến data
            // mã <E0F> được sử dụng để đánh dấu kết thúc dữ liệu 
            while (true)
            {
                Socket client = svSocket.Accept();
                if (client != null)
                {
                    // Doc du lieu
                    String data = "";
                    byte[] boDem = new byte[1024];
                    int demNhan = client.Receive(boDem);
                    data += Encoding.UTF8.GetString(boDem).Trim().Substring(0, demNhan);
                    while (!data.Contains("<EOF>"))
                    {
                        boDem = new byte[1024];
                        demNhan = client.Receive(boDem);
                        data += Encoding.UTF8.GetString(boDem).Trim().Substring(0, demNhan);
                    }

                    data = data.Replace("\0", "");
                    data = data.Substring(0, data.Length - 5); // Loai bo <EOF>

                    //Nếu data bắt đầu bằng 1.1: Select 1.1*[điều kiện] với BNguoiDung
                    //Nếu data bắt đầu bằng 1.2: Insert 1.2* với BNguoiDung
                    //Nếu data bắt đầu bằng 2.1: Select 2.1*[điều kiện] với BKeHoach
                    //Nếu data bắt đầu bằng 2.2: Insert 2.2* với BKeHoach
                    //Nếu data bắt đầu bằng 2.3: Update 2.3* với BKeHoach
                    //Nếu data bắt đầu bằng 2.4: Delete 2.4* với BKeHoach
                    //Nếu data bắt đầu bằng 3.1: Select 3.1* với BThanhVienNhom
                    //Nếu data              3.2: Insert với BThanhVienNhom
                    //----------------------3.4: Delete với BThanhVienNhom
                    //----------------------4.1: Select với BNhomCongViec
                    //----------------------4.2: Insert với BNhomCongViec
                    //----------------------4.3: Update với BNhomCongViec   
                    //----------------------4.4: Delete với BNhomCongViec
                    //----------------------5.1: Select với BCongViec
                    
                    // dựa vào chuỗi data máy chủ xác định loại truy vấn 1.1, 1.2,..
                    // các loại truy vấn khác nhau được xử lý bằng cách gọi các phương thức tướng ứng trong các lớp
                    // khi có dữ liệu trả về từ csdl thì máy chủ gửi dữ liệu đó cho máy khách 

                    String loaiQuery = data.Split('*')[0];
                    String duLieu = data.Split('*')[1];
                    if (loaiQuery.Equals("1.1"))
                    {
                        DataTable tb;
                        BNguoiDung bnd = new BNguoiDung();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bnd.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bnd.SelectToTable(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("1.2"))
                    {
                        String hoten = duLieu.Split(';')[0];
                        String matkhau = duLieu.Split(';')[1];
                        BNguoiDung bnd = new BNguoiDung();
                        int dem = bnd.Insert(hoten, matkhau);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }                 
                    else if (loaiQuery.Equals("2.1"))
                    {
                        DataTable tb;
                        BKeHoach bkh = new BKeHoach();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bkh.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bkh.SelectToTable(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("2.2"))
                    {
                        string[] parts = duLieu.Split(';');
                        if (parts.Length >= 5)
                        {                          
                            String ten = duLieu.Split(';')[0];
                            String mota = duLieu.Split(';')[1];

                            String format = "yyyy/MM/dd";
                            DateTime ngaybatdau = DateTime.ParseExact(duLieu.Split(';')[2], format, CultureInfo.InvariantCulture);
                            DateTime ngayketthuc = DateTime.ParseExact(duLieu.Split(';')[3], format, CultureInfo.InvariantCulture);

                            //DateTime ngaybatdau = DateTime.Parse(duLieu.Split(';')[2]);
                            //DateTime ngayketthuc = DateTime.Parse(duLieu.Split(';')[3]);
                            int idadmin = int.Parse(duLieu.Split(';')[4]);
                            BKeHoach bkh = new BKeHoach();
                            int dem = bkh.Insert(ten, mota, ngaybatdau, ngayketthuc, idadmin);
                            client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                        }
                    }
                    else if (loaiQuery.Equals("2.3"))
                    {
                        int id = int.Parse(duLieu.Split(';')[0]);
                        String ten = duLieu.Split(';')[1];
                        String mota = duLieu.Split(';')[2];
                        DateTime ngaybatdau = DateTime.Parse(duLieu.Split(';')[3]);
                        DateTime ngayketthuc = DateTime.Parse(duLieu.Split(';')[4]);
                        int idadmin = int.Parse(duLieu.Split(';')[5]);
                        BKeHoach bkh = new BKeHoach();
                        int dem = bkh.Update(id, ten, mota, ngaybatdau, ngayketthuc, idadmin);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("2.4"))
                    {
                        int id = int.Parse(duLieu);
                        BKeHoach bkh = new BKeHoach();
                        int dem = bkh.Delete(id);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("2.5"))
                    {
                        DataTable tb;
                        BKeHoach bkh = new BKeHoach();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bkh.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bkh.SelectIdKH(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("3.1"))
                    {
                        DataTable tb;
                        BThanhVienNhom btvn = new BThanhVienNhom();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = btvn.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = btvn.SelectWithJoin(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }                        
                    }
                    else if (loaiQuery.Equals("3.2"))
                    {
                        string[] parts = duLieu.Split(';');
                        if (parts.Length >= 3)
                        {
                            int idkehoach = int.Parse(duLieu.Split(';')[0]);
                            int idnguoidung = int.Parse(duLieu.Split(';')[1]);
                            String quyen = duLieu.Split(';')[2];
                            BThanhVienNhom btvn = new BThanhVienNhom();
                            int dem = btvn.Insert(idkehoach, idnguoidung, quyen);
                            client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                        }
                    }
                    else if (loaiQuery.Equals("3.3"))
                    {
                        int id = int.Parse(duLieu.Split(';')[0]);
                        int idkehoach = int.Parse(duLieu.Split(';')[1]);
                        int idnguoidung = int.Parse(duLieu.Split(';')[2]);
                        String quyen = duLieu.Split(';')[3];
                        BThanhVienNhom btvn = new BThanhVienNhom();
                        int dem = btvn.Update(id, idkehoach, idnguoidung, quyen);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("3.4"))
                    {
                        int id = int.Parse(duLieu);
                        BThanhVienNhom btvn = new BThanhVienNhom();
                        int dem = btvn.Delete(id);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("3.5"))
                    {
                        DataTable tb;
                        BThanhVienNhom btvn = new BThanhVienNhom();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = btvn.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = btvn.SelectToTable(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("3.6"))
                    {
                        String condition = duLieu;
                        BThanhVienNhom btvn = new BThanhVienNhom();
                        int dem = btvn.DeleteCondition(condition);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("3.7"))
                    {
                        DataTable tb;
                        BThanhVienNhom btvn = new BThanhVienNhom();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = btvn.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = btvn.SelectTVN(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    if (loaiQuery.Equals("4.1"))
                    {
                        DataTable tb;
                        BNhomCongViec bncv = new BNhomCongViec();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bncv.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bncv.SelectToTable(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("4.2"))
                    {
                        string[] parts = duLieu.Split(';');
                        if (parts.Length >= 2)
                        {
                            String ten = duLieu.Split(';')[0];
                            int idkehoach = int.Parse(duLieu.Split(';')[1]);
                            BNhomCongViec bncv = new BNhomCongViec();
                            int dem = bncv.Insert(ten, idkehoach);
                            client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                        }
                    }
                    else if (loaiQuery.Equals("4.3"))
                    {
                        int id = int.Parse(duLieu.Split(';')[0]);
                        String ten = duLieu.Split(';')[1];
                        int idkehoach = int.Parse(duLieu.Split(';')[2]);
                        BNhomCongViec bncv = new BNhomCongViec();
                        int dem = bncv.Update(id, ten, idkehoach);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("4.4"))
                    {
                        int id = int.Parse(duLieu);
                        BNhomCongViec bncv = new BNhomCongViec();
                        int dem = bncv.Delete(id);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("4.5"))
                    {
                        DataTable tb;
                        BNhomCongViec bncv = new BNhomCongViec();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bncv.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bncv.SelectIdAdmin(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("4.6"))
                    {
                        DataTable tb;
                        BNhomCongViec bncv = new BNhomCongViec();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bncv.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bncv.SelectIdNCV(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("5.1"))
                    {
                        DataTable tb;
                        BCongViec bcv = new BCongViec();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bcv.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bcv.SelectToTable(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("5.2"))
                    {
                        string[] parts = duLieu.Split(';');
                        if (parts.Length >= 7)
                        {
                            String ten = duLieu.Split(';')[0];
                            String mota = duLieu.Split(';')[1];
                            DateTime ngaybatdau = DateTime.Parse(duLieu.Split(';')[2]);
                            DateTime ngayketthuc = DateTime.Parse(duLieu.Split(';')[3]);
                            String trangthai = duLieu.Split(';')[4];
                            int idnguoithuchien = int.Parse(duLieu.Split(';')[5]);
                            int idnhomcv = int.Parse(duLieu.Split(';')[6]);
                            BCongViec bcv = new BCongViec();
                            int dem = bcv.Insert(ten, mota, ngaybatdau, ngayketthuc, trangthai, idnguoithuchien, idnhomcv);
                            client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                        }
                    }
                    else if (loaiQuery.Equals("5.3"))
                    {
                        int id = int.Parse(duLieu.Split(';')[0]);
                        String ten = duLieu.Split(';')[1];
                        String mota = duLieu.Split(';')[2];
                        DateTime ngaybatdau = DateTime.Parse(duLieu.Split(';')[3]);
                        DateTime ngayketthuc = DateTime.Parse(duLieu.Split(';')[4]);
                        String trangthai = duLieu.Split(';')[5];
                        int idnguoithuchien = int.Parse(duLieu.Split(';')[6]);
                        int idnhomcv = int.Parse(duLieu.Split(';')[7]);
                        BCongViec bcv = new BCongViec();
                        int dem = bcv.Update(id, ten, mota, ngaybatdau, ngayketthuc, trangthai, idnguoithuchien, idnhomcv);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("5.4"))
                    {
                        String condition = duLieu;
                        BCongViec bcv = new BCongViec();
                        int dem = bcv.DeleteCondition(condition);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("5.5"))
                    {
                        DataTable tb;
                        BCongViec bcv = new BCongViec();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bcv.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bcv.SelectTrangThai(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("5.6"))
                    {
                        int id = int.Parse(duLieu);
                        BCongViec bcv = new BCongViec();
                        int dem = bcv.Delete(id);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("5.7"))
                    {
                        DataTable tb;
                        BCongViec bcv = new BCongViec();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bcv.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bcv.SelectId(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("6.1"))
                    {
                        DataTable tb;
                        BCongViecCon bcvc = new BCongViecCon();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bcvc.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bcvc.SelectToTable(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("6.2"))
                    {
                        string[] parts = duLieu.Split(';');
                        if (parts.Length >= 7)
                        {
                            String ten = duLieu.Split(';')[0];
                            String mota = duLieu.Split(';')[1];
                            DateTime ngaybatdau = DateTime.Parse(duLieu.Split(';')[2]);
                            DateTime ngayketthuc = DateTime.Parse(duLieu.Split(';')[3]);
                            String trangthai = duLieu.Split(';')[4];
                            int idnguoithuchien = int.Parse(duLieu.Split(';')[5]);
                            int idcv = int.Parse(duLieu.Split(';')[6]);
                            BCongViecCon bcvc = new BCongViecCon();
                            int dem = bcvc.Insert(ten, mota, ngaybatdau, ngayketthuc, trangthai, idnguoithuchien, idcv);
                            client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                        }
                    }
                    else if (loaiQuery.Equals("6.3"))
                    {
                        int id = int.Parse(duLieu.Split(';')[0]);
                        String ten = duLieu.Split(';')[1];
                        String mota = duLieu.Split(';')[2];
                        DateTime ngaybatdau = DateTime.Parse(duLieu.Split(';')[3]);
                        DateTime ngayketthuc = DateTime.Parse(duLieu.Split(';')[4]);
                        String trangthai = duLieu.Split(';')[5];
                        int idnguoithuchien = int.Parse(duLieu.Split(';')[6]);
                        int idcv = int.Parse(duLieu.Split(';')[7]);
                        BCongViecCon bcvc = new BCongViecCon();
                        int dem = bcvc.Update(id, ten, mota, ngaybatdau, ngayketthuc, trangthai, idnguoithuchien, idcv);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("6.4"))
                    {
                        int id = int.Parse(duLieu);
                        BCongViecCon bcvc = new BCongViecCon();
                        int dem = bcvc.Delete(id);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("6.5"))
                    {
                        DataTable tb;
                        BCongViecCon bcvc = new BCongViecCon();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bcvc.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bcvc.SelectTrangThai(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("6.6"))
                    {
                        DataTable tb;
                        BCongViecCon bcvc = new BCongViecCon();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = bcvc.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = bcvc.SelectTime(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("6.7"))
                    {
                        String condition = duLieu;
                        BCongViec bcv = new BCongViec();
                        int dem = bcv.DeleteCondition(condition);
                        client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                    }
                    else if (loaiQuery.Equals("7.1"))
                    {
                        DataTable tb;
                        BTepTin btt = new BTepTin();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = btt.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = btt.SelectTimeUpdate(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else if (loaiQuery.Equals("7.2"))
                    {
                        string[] parts = duLieu.Split(';');
                        if (parts.Length >= 5)
                        {
                            int idcongvieccon = int.Parse(duLieu.Split(';')[0]);
                            int idnguoiupdate = int.Parse(duLieu.Split(';')[1]);
                            String tentep = duLieu.Split(';')[2];
                            DateTime thoigianupdate = DateTime.Parse(duLieu.Split(';')[3]);
                            String noidung = duLieu.Split(';')[4];
                            BTepTin bcvc = new BTepTin();
                            int dem = bcvc.Insert(idcongvieccon, idnguoiupdate, tentep, thoigianupdate, noidung);
                            client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                        }
                    }
                    else if (loaiQuery.Equals("7.5"))
                    {
                        DataTable tb;
                        BTepTin btt = new BTepTin();
                        if (String.IsNullOrEmpty(duLieu))
                        {
                            // Select All                            
                            tb = btt.SelectAllToTable();
                        }
                        else
                        {
                            // Select theo dieu kien
                            tb = btt.SelectCondition(duLieu);
                        }
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream();
                            System.Runtime.Serialization.IFormatter fm =
                                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            fm.Serialize(ms, tb);
                            byte[] bData = ms.GetBuffer();
                            client.Send(bData);
                        }
                    }
                    else
                    if (loaiQuery.Equals("8.2"))
                    {
                        string[] parts = duLieu.Split(';');
                        if (parts.Length >= 4)
                        {
                            String nguoinhan = duLieu.Split(';')[0];
                            String nguoigui = duLieu.Split(';')[1];
                            String noidung = duLieu.Split(';')[2];
                            DateTime thoigian = DateTime.Parse(duLieu.Split(';')[3]);
                            BTinNhan btn = new BTinNhan();
                            int dem = btn.Insert(nguoinhan, nguoigui, noidung, thoigian);
                            client.Send(Encoding.UTF8.GetBytes(dem.ToString()));
                        }
                    }
                    client.Disconnect(false);
                    client.Close();
                    client.Dispose();
                   
                }
            }
        }
    }
}
