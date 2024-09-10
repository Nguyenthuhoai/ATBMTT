using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ServerBTN
{
    public  class DataAccess
    {   
        // thuộc tính
        String Connection;
        public DataAccess() 
        {   
            // truy cập cở sở dữ liệu bằng cách sử dụng chuỗi kết nối đã được cấu hình 
            Connection = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        }
        
        // truy vấn đọc dữ liệu từ cơ sở dữ liệu
        public DataTable Read(String query)
        {   
            // tạo 1 kết nối và thực hiện truy vấn được truyển vào thông qua sqlcommand
            // dữ liệu được trả về dưới dạng 1 bảng datatable
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable tb = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
                return tb;
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                return null;
            }
        }

        // phương thức truy vấn ghi dữ liệu vào cơ sở dữ liệu 
        // thực hiện truy vấn và trả về số hàng bị ảnh hưởng (số lượng hàng được thêm, sửa, xoá)
        public int Write(String query)
        {
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int dem = 0;
                dem = cmd.ExecuteNonQuery();
                con.Close();
                return dem;
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                return -1;
            }
        }
        
        //thực hiện truy vấn ghi dữ liệu và trả về ID của hàng vừa được chèn
        // sử dụng scope_identity() để lấy ID của hàng vừa chèn
        public int WriteAndReturnInsertedId(String query)
        {
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandText += "; SELECT SCOPE_IDENTITY();";
            try
            {
                con.Open();
                int insertedId = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return insertedId;
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                return -1;
            }
        }


    }
}
