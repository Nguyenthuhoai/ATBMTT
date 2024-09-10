using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class BKeHoach
    {
        DataAccess da = new DataAccess();
        public List<KeHoach> SelectAll()
        {
            String query = "Select * From KeHoach";
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<KeHoach> ds = new List<KeHoach>();
                foreach (DataRow r in tb.Rows)
                {
                    KeHoach kh = new KeHoach();
                    kh.ID = int.Parse(r["Id"].ToString());
                    kh.Ten = r["Ten"].ToString();
                    kh.MoTa = r["MoTa"].ToString();
                    kh.NgayBatDau = DateTime.Parse(r["NgayBatDau"].ToString());
                    kh.NgayKetThuc = DateTime.Parse(r["NgayKetThuc"].ToString());
                    kh.IdAdmin = int.Parse(r["IdAdmin"].ToString());
                    ds.Add(kh);
                }
                return ds;
            }
            else
                return null;
        }

        public DataTable SelectAllToTable()
        {
            String query = "Select * From KeHoach";
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectToTable(String condition)
        {
            String query = "Select Ten, MoTa, NgayBatDau, NgayKetThuc, IdAdmin, Id from KeHoach Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectIdKH(String condition)
        {
            String query = "Select Id from KeHoach Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public List<KeHoach> Select(String condition)
        {
            String query = "Select * from KeHoach Where " + condition;
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<KeHoach> ds = new List<KeHoach>();
                foreach (DataRow r in tb.Rows)
                {
                    KeHoach kh = new KeHoach();
                    kh.ID = int.Parse(r["Id"].ToString());
                    kh.Ten = r["Ten"].ToString();
                    kh.MoTa = r["MoTa"].ToString();
                    kh.NgayBatDau = DateTime.Parse(r["NgayBatDau"].ToString());
                    kh.NgayKetThuc = DateTime.Parse(r["NgayKetThuc"].ToString());
                    kh.IdAdmin = int.Parse(r["IdAdmin"].ToString());
                    ds.Add(kh);
                }
                return ds;
            }
            else
                return null;
        }

        public int Insert(String ten, string mota, DateTime ngaybatdau, DateTime ngayketthuc, int idadmin)
        {
            String query = "Insert into KeHoach(Ten, MoTa, NgayBatDau, NgayKetThuc, IdAdmin) Values(N'"
                + ten + "', N'"
                + mota + "', N'"
                + ngaybatdau.ToString("yyyy/MM/dd") + "', N'"
                + ngayketthuc.ToString("yyyy/MM/dd") + "', '"
                + idadmin.ToString() + "')";
            int dem = da.WriteAndReturnInsertedId(query);
            return dem;
        }

        public int Update(int id, String ten, string mota, DateTime ngaybatdau, DateTime ngayketthuc, int idadmin)
        {
            String query = "Update KeHoach Set Ten=N'"
                + ten + "', MoTa = N'"
                + mota + "', NgayBatDau = N'"
                + ngaybatdau.ToString("MM/dd/yyyy") + "', NgayKetThuc = N'"
                + ngayketthuc.ToString("MM/dd/yyyy") +"', IdAdmin = '"
                + idadmin.ToString() + "' Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }

        public int Delete(int id)
        {
            String query = "Delete KeHoach Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }

       
    }
}
