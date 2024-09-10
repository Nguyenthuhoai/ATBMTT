using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class BTepTin
    {
        DataAccess da = new DataAccess();

        // Select, Insert, Update, Delete
        public List<TepTin> SelectAll()
        {
            String query = "Select * From TepTin";
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<TepTin> ds = new List<TepTin>();
                foreach (DataRow r in tb.Rows)
                {
                    TepTin tt = new TepTin();
                    tt.Id = int.Parse(r["Id"].ToString());
                    tt.IdCongViecCon = int.Parse(r["IdCongViecCon"].ToString());
                    tt.IdNguoiUpdateTep = int.Parse(r["IdNguoiUpdateTep"].ToString());
                    tt.TenTep = r["TenTep"].ToString();                    
                    tt.ThoiGianUpdate = DateTime.Parse(r["ThoiGinUpdate"].ToString());
                    tt.DuLieuTep = r["DuLieuTep"].ToString();
                    ds.Add(tt);
                }
                return ds;
            }
            else
                return null;
        }

        public DataTable SelectAllToTable()
        {
            String query = "Select * From TepTin";
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectToTable(String condition)
        {
            String query = "Select * from TepTin Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectTimeUpdate(String condition)
        {
            String query = "Select ThoiGianUpdate from TepTin Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectCondition(String condition)
        {
            String query = "Select IdCongViecCon, IdNguoiUpdateTep, TenTep, ThoiGianUpdate from TepTin Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public List<TepTin> Select(String condition)
        {
            String query = "Select * from TepTin Where " + condition;
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<TepTin> ds = new List<TepTin>();
                foreach (DataRow r in tb.Rows)
                {
                    TepTin tt = new TepTin();
                    tt.Id = int.Parse(r["Id"].ToString());
                    tt.IdCongViecCon = int.Parse(r["IdCongViecCon"].ToString());
                    tt.IdNguoiUpdateTep = int.Parse(r["IdNguoiUpdateTep"].ToString());
                    tt.TenTep = r["TenTep"].ToString();
                    tt.ThoiGianUpdate = DateTime.Parse(r["ThoiGinUpdate"].ToString());
                    tt.DuLieuTep = r["DuLieuTep"].ToString();
                    ds.Add(tt);
                }
                return ds;
            }
            else
                return null;
        }

        public int Insert(int idcongvieccon, int idnguoiupdatetep, String tentep, DateTime thoigianupdate,  String dulieutep)
        {
            String query = "INSERT INTO TepTin (IdCongViecCon, IdNguoiUpdateTep, TenTep, ThoiGianUpdate, DuLieuTep) VALUES ("
         + idcongvieccon + ", "
         + idnguoiupdatetep + ", N'"
         + tentep + "', '"
         + thoigianupdate.ToString("yyyy-MM-dd HH:mm:ss") + "', N'"
         + dulieutep + "')";
            int dem = da.Write(query);
            return dem; 
        }

        public int Update(int id, int idcongvieccon, int idnguoiupdatetep, String tentep, DateTime thoigianupdate, String dulieutep)
        {
            string query = "UPDATE TepTin SET IdCongViecCon = " + idcongvieccon +
                  ", IdNguoiUpdateTep = " + idnguoiupdatetep +
                  ", TenTep = N'" + tentep +
                  "', ThoiGianUpdate = '" + thoigianupdate.ToString("yyyy-MM-dd HH:mm:ss") +
                  "', DuLieuTep = N'" + dulieutep +
                  "' WHERE Id = " + id;
            int dem = da.Write(query);
            return dem;
        }


        public int Delete(int id)
        {
            String query = "Delete From TepTin Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }

        public int DeleteCondition(String condition)
        {
            String query = "Delete From TepTin Where " + condition.ToString();
            int dem = da.Write(query);
            return dem;
        }
    }
}
