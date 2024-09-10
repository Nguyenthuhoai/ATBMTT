using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class BNguoiDung
    {
        DataAccess da = new DataAccess();
        // Select, Insert 
        public List<NguoiDung> SelectAll()
        {
            String query = "Select * From NguoiDung";
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<NguoiDung> ds = new List<NguoiDung>();
                foreach (DataRow r in tb.Rows)
                {
                    NguoiDung nd = new NguoiDung();
                    nd.ID = int.Parse(r["Id"].ToString());
                    nd.HoTen = r["HoTen"].ToString();
                    nd.MatKhau = r["MatKhau"].ToString();
                    ds.Add(nd);
                }
                return ds;
            }
            else
                return null;
        }

        public DataTable SelectAllToTable()
        {
            String query = "Select * From NguoiDung";
            DataTable nd = da.Read(query);
            return nd;
        }

        public DataTable SelectToTable(String condition)
        {
            String query = "Select Id from NguoiDung Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }
        public DataTable SelectName()
        {
            String query = "Select HoTen from NguoiDung " ;
            DataTable tb = da.Read(query);
            return tb;
        }

        public List<NguoiDung> Select(String condition)
        {
            String query = "Select * from NguoiDung Where " + condition;
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<NguoiDung> ds = new List<NguoiDung>();
                foreach (DataRow r in tb.Rows)
                {
                    NguoiDung nd = new NguoiDung();
                    nd.ID = int.Parse(r["Id"].ToString());
                    nd.HoTen = r["HoTen"].ToString();
                    nd.MatKhau = r["MatKhau"].ToString();
                    ds.Add(nd);
                }
                return ds;
            }
            else
                return null;
        }

        public int Insert(String hoten, String matkhau)
        {
            String query = "Insert into NguoiDung(HoTen, MatKhau) Values(N'"
                + hoten + "', N'"
                + matkhau + "')";
            int dem = da.Write(query);
            return dem;
        }
    }
}
