using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class BThanhVienNhom
    {
        DataAccess da = new DataAccess();

        // Select, Insert, Update, Delete
        public List<ThanhVienNhom> SelectAll()
        {
            String query = "Select * From ThanhVienNhom";
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<ThanhVienNhom> ds = new List<ThanhVienNhom>();
                foreach (DataRow r in tb.Rows)
                {
                    ThanhVienNhom tvn = new ThanhVienNhom();
                    tvn.ID = int.Parse(r["Id"].ToString());
                    tvn.IdNguoiDung = int.Parse(r["IdNguoiDung"].ToString());
                    tvn.IdKeHoach = int.Parse(r["IdKeHoach"].ToString());
                    tvn.Quyen = r["Quyen"].ToString();                   
                    ds.Add(tvn);
                }
                return ds;
            }
            else
                return null;
        }

        public DataTable SelectAllToTable()
        {
            String query = "Select * From ThanhVienNhom";
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectToTable(String condition)
        {
            String query = "Select Id, IdNguoiDung, Quyen from ThanhVienNhom Where " + condition + " ORDER BY Quyen ASC";
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectTVN(String condition)
        {
            String query = "Select * from ThanhVienNhom Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        //public DataTable SelectWithCondition(string query)
        //{
        //    DataTable tb = da.Read(query);
        //    return tb;
        //}

        public DataTable SelectWithJoin(string condition)
        {
            String query = "select distinct KeHoach.Id, KeHoach.Ten from KeHoach left join ThanhVienNhom on ThanhVienNhom.IdKeHoach = KeHoach.Id left join NguoiDung on ThanhVienNhom.IdNguoiDung = NguoiDung.Id where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }


        public List<ThanhVienNhom> Select(String condition)
        {
            String query = "Select * from ThanhVienNhom Where " + condition;
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<ThanhVienNhom> ds = new List<ThanhVienNhom>();
                foreach (DataRow r in tb.Rows)
                {
                    ThanhVienNhom tvn = new ThanhVienNhom();
                    tvn.ID = int.Parse(r["Id"].ToString());
                    tvn.IdNguoiDung = int.Parse(r["IdNguoiDung"].ToString());
                    tvn.IdKeHoach = int.Parse(r["IdKeHoach"].ToString());
                    tvn.Quyen = r["Quyen"].ToString();
                    ds.Add(tvn);
                }
                return ds;
            }
            else
                return null;
        }

        public int Insert(int idkehoach, int idnguoidung, string quyen)
        {
            String query = "Insert into ThanhVienNhom(IdNguoiDung, IdKeHoach, Quyen) Values("
                + idnguoidung.ToString() + ", "
                + idkehoach.ToString() + ", N'"
                + quyen + "')";
            int dem = da.Write(query);
            return dem;
        }

        public int Update(int id, int idkehoach, int idnguoidung, string quyen)
        {
            String query = "Update ThanhVienNhom Set IdKeHoach="
                + idkehoach.ToString() + ", IdNguoiDung = "
                + idnguoidung.ToString() + ", Quyen = N'"
                + quyen + "' Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }

        public int Delete(int id)
        {
            String query = "Delete From ThanhVienNhom Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }
        public int DeleteCondition(String condition)
        {
            String query = "Delete From ThanhVienNhom Where " + condition.ToString();
            int dem = da.Write(query);
            return dem;
        }
    }
}
