using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class BCongViecCon
    {
        DataAccess da = new DataAccess();

        // Select, Insert, Update, Delete
        public List<CongViecCon> SelectAll()
        {
            String query = "Select * From CongViecCon";
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<CongViecCon> ds = new List<CongViecCon>();
                foreach (DataRow r in tb.Rows)
                {
                    CongViecCon cvc = new CongViecCon();
                    cvc.IdCongViec = int.Parse(r["IdCongViec"].ToString());
                    cvc.Ten = r["Ten"].ToString();
                    cvc.MoTa = r["MoTa"].ToString();
                    cvc.NgayBatDau = DateTime.Parse(r["NgayBatDau"].ToString());
                    cvc.NgayKetThuc = DateTime.Parse(r["NgayKetThuc"].ToString());
                    cvc.TrangThai = r["TrangThai"].ToString();
                    cvc.IdNguoiThucHien = int.Parse(r["IdNguoiThucHien"].ToString());
                    cvc.IdCongViecCon = int.Parse(r["Id"].ToString());
                    ds.Add(cvc);
                }
                return ds;
            }
            else
                return null;
        }

        public DataTable SelectAllToTable()
        {
            String query = "Select Id, Ten, MoTa, NgayBatDau, NgayKetThuc, IdNguoiThucHien from CongViecCon From CongViecCon";
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectToTable(String condition)
        {
            String query = "Select Ten, MoTa, NgayBatDau, NgayKetThuc, IdNguoiThucHien, Id from CongViecCon Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectTrangThai(String condition)
        {
            String query = "Select TrangThai from CongViecCon Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }
        public DataTable SelectTime(String condition)
        {
            String query = "Select NgayKetThuc from CongViecCon Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public List<CongViecCon> Select(String condition)
        {
            String query = "Select * from CongViecCon Where " + condition;
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<CongViecCon> ds = new List<CongViecCon>();
                foreach (DataRow r in tb.Rows)
                {
                    CongViecCon cvc = new CongViecCon();
                    cvc.IdCongViec = int.Parse(r["IdCongViec"].ToString());
                    cvc.Ten = r["Ten"].ToString();
                    cvc.MoTa = r["MoTa"].ToString();
                    cvc.NgayBatDau = DateTime.Parse(r["NgayBatDau"].ToString());
                    cvc.NgayKetThuc = DateTime.Parse(r["NgayKetThuc"].ToString());
                    cvc.TrangThai = r["TrangThai"].ToString();
                    cvc.IdNguoiThucHien = int.Parse(r["IdNguoiThucHien"].ToString());
                    cvc.IdCongViecCon = int.Parse(r["Id"].ToString());
                    ds.Add(cvc);
                }
                return ds;
            }
            else
                return null;
        }

        public int Insert(String ten, String mota, DateTime ngaybatdau, DateTime ngayketthuc, String trangthai, int idnguoithuchien, int idcongviec)
        {
            String query = "Insert into CongViecCon(Ten, MoTa, NgayBatDau, NgayKetThuc, TrangThai, IdNguoiThucHien, IdCongViec) Values(N'"
                + ten + "', N'"
                + mota + "', N'"
                + ngaybatdau.ToString("MM/dd/yyyy") + "', N'"
                + ngayketthuc.ToString("MM/dd/yyyy") + "',N' "
                + trangthai + "', "
                + idnguoithuchien.ToString() + ", "
                + idcongviec.ToString() + ")";
            int dem = da.WriteAndReturnInsertedId(query);
            return dem;
        }

        public int Update(int id, String ten, String mota, DateTime ngaybatdau, DateTime ngayketthuc, String trangthai, int idnguoithuchien, int idcongviec)
        {
            String query = "Update CongViecCon Set Ten=N'"
                + ten + "', " + "MoTa = N'"
                + mota + "', NgayBatDau = N'"
                + ngaybatdau.ToString("MM/dd/yyyy") + "', NgayKetThuc = N'"
                + ngayketthuc.ToString("MM/dd/yyyy") + "', TrangThai = N'"
                + trangthai + "', IdNguoiThucHien = "
                + idnguoithuchien.ToString() + ", IdCongViec = "
                + idcongviec + " Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }

        public int Delete(int id)
        {
            String query = "Delete From CongViecCon Where Id=" + id.ToString();
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
