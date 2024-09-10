using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    internal class BCongViec
    {
        DataAccess da = new DataAccess();

        // Select, Insert, Update, Delete
        public List<CongViec> SelectAll()
        {
            String query = "Select * From CongViec";
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<CongViec> ds = new List<CongViec>();
                foreach (DataRow r in tb.Rows)
                {
                    CongViec cv = new CongViec();
                    cv.IdCongViec = int.Parse(r["Id"].ToString());
                    cv.Ten = r["Ten"].ToString();
                    cv.MoTa = r["MoTa"].ToString();
                    cv.NgayBatDau = DateTime.Parse(r["NgayBatDau"].ToString());
                    cv.NgayKetThuc = DateTime.Parse(r["NgayKetThuc"].ToString());
                    cv.TrangThai = r["TrangThai"].ToString();
                    cv.IdNguoiThucHien = int.Parse(r["IdNguoiThucHien"].ToString());
                    cv.IdNhomCV = int.Parse(r["IdNhomCV"].ToString());                  
                    ds.Add(cv);
                }
                return ds;
            }
            else
                return null;
        }

        public DataTable SelectAllToTable()
        {
            String query = "Select  Id, Ten, MoTa, NgayBatDau, NgayKetThuc, IdNguoiThucHien * From CongViec";
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectToTable(String condition)
        {
            String query = "Select Ten, MoTa, NgayBatDau, NgayKetThuc, IdNguoiThucHien, Id from CongViec Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectTrangThai(String condition)
        {
            String query = "Select TrangThai from CongViec Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectId(String condition)
        {
            String query = "Select Id from CongViec Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public List<CongViec> Select(String condition)
        {
            String query = "Select * from CongViec Where " + condition;
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<CongViec> ds = new List<CongViec>();
                foreach (DataRow r in tb.Rows)
                {
                    CongViec cv = new CongViec();
                    cv.IdCongViec = int.Parse(r["Id"].ToString());
                    cv.Ten = r["Ten"].ToString();
                    cv.MoTa = r["MoTa"].ToString();
                    cv.NgayBatDau = DateTime.Parse(r["NgayBatDau"].ToString());
                    cv.NgayKetThuc = DateTime.Parse(r["NgayKetThuc"].ToString());
                    cv.TrangThai = r["TrangThai"].ToString();
                    cv.IdNguoiThucHien = int.Parse(r["IdNguoiThucHien"].ToString());
                    cv.IdNhomCV = int.Parse(r["IdNhomCV"].ToString());
                    ds.Add(cv);
                }
                return ds;
            }
            else
                return null;
        }

        public int Insert(String ten, String mota, DateTime ngaybatdau, DateTime ngayketthuc, String trangthai, int idnguoithuchien, int idnhomcv)
        {
            String query = "Insert into CongViec(Ten, MoTa, NgayBatDau, NgayKetThuc, TrangThai, IdNguoiThucHien, IdNhomCV) Values(N'"
                + ten + "', N'"
                + mota + "', N'"
                + ngaybatdau.ToString("MM/dd/yyyy") + "', N'"
                + ngayketthuc.ToString("MM/dd/yyyy") + "', N'"
                + trangthai + "', "
                + idnguoithuchien.ToString() + ", "
                + idnhomcv.ToString() + ")";
            int dem = da.Write(query);
            return dem;
        }

        public int Update(int id, String ten, String mota, DateTime ngaybatdau, DateTime ngayketthuc, String trangthai, int idnguoithuchien, int idnhomcv)
        {
            String query = "Update CongViec Set Ten=N'"
                + ten + "', " + "MoTa = N'"
                + mota + "', NgayBatDau = N'"
                + ngaybatdau.ToString("MM/dd/yyyy") + "', NgayKetThuc = N'"
                + ngayketthuc.ToString("MM/dd/yyyy") + "', TrangThai = N'"
                + trangthai + "', IdNguoiThucHien = "
                + idnguoithuchien.ToString() + ", IdNhomCV = "
                + idnhomcv + " Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }


        public int Delete(int id)
        {
            String query = "Delete From CongViec Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }

        public int DeleteCondition(String condition)
        {
            String query = "Delete From CongViecCon Where " + condition.ToString();
            int dem = da.Write(query);
            return dem;
        }
    }
}
