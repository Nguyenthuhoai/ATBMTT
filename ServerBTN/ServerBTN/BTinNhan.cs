using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class BTinNhan
    {
        DataAccess da = new DataAccess();

        // Select, Insert, Update, Delete
        public List<TinNhan> SelectAll()
        {
            String query = "Select * From TinNhan";
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<TinNhan> ds = new List<TinNhan>();
                foreach (DataRow r in tb.Rows)
                {
                    TinNhan tn = new TinNhan();
                    tn.Id = int.Parse(r["Id"].ToString());
                    tn.NguoiNhan = r["NguoiNhan"].ToString();
                    tn.NguoiGui = r["NguoiGui"].ToString();
                    tn.NoiDung = r["NoiDung"].ToString();
                    tn.ThoiGian = DateTime.Parse(r["NgayBatDau"].ToString());
                    ds.Add(tn);
                }
                return ds;
            }
            else
                return null;
        }

        public DataTable SelectAllToTable()
        {
            String query = "Select * From TinNhan";
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectToTable(String condition)
        {
            String query = "Select * from TinNhan Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectTimeUpdate(String condition)
        {
            String query = "Select ThoiGianUpdate from TinNhan Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectCondition(String condition)
        {
            String query = "Select * from TinNhan Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public List<TinNhan> Select(String condition)
        {
            String query = "Select * from TinNhan Where " + condition;
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<TinNhan> ds = new List<TinNhan>();
                foreach (DataRow r in tb.Rows)
                {
                    TinNhan tn = new TinNhan();
                    tn.Id = int.Parse(r["Id"].ToString());
                    tn.NguoiNhan = r["NguoiNhan"].ToString();
                    tn.NguoiGui = r["NguoiGui"].ToString();
                    tn.NoiDung = r["NoiDung"].ToString();
                    tn.ThoiGian = DateTime.Parse(r["NgayBatDau"].ToString());
                    ds.Add(tn);
                }
                return ds;
            }
            else
                return null;
        }

        public int Insert( String nguoinhan, String nguoigui, String noidung, DateTime thoigian)
        {
            string query = "INSERT INTO TinNhan (NguoiNhan, NguoiGui, NoiDung, ThoiGian) VALUES ("
        + "'" + nguoinhan + "', "
        + "'" + nguoigui + "', "
        + "N'" + noidung + "',N' "
        + thoigian.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            int dem = da.Write(query);
            return dem;
        }

        public int Update(int id, String nguoinhan, String nguoigui, String noidung, DateTime thoigian)
        {
            string query = "UPDATE TinNhan SET NguoiNhan = N'" + nguoinhan +
                   "', NguoiGui = N'" + nguoigui +
                   "', NoiDung = N'" + noidung +
                   "', ThoiGian = N'" + thoigian.ToString("yyyy-MM-dd HH:mm:ss") +
                   "' WHERE Id = " + id;
            int dem = da.Write(query);
            return dem;
        }


        public int Delete(int id)
        {
            String query = "Delete From TinNhan Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }

        public int DeleteCondition(String condition)
        {
            String query = "Delete From TinNhan Where " + condition.ToString();
            int dem = da.Write(query);
            return dem;
        }
    }
}
