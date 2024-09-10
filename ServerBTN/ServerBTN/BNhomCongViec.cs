using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class BNhomCongViec
    {
        DataAccess da = new DataAccess();

        // Select, Insert, Update, Delete
        public List<NhomCongViec> SelectAll()
        {
            String query = "Select * From NhomCongViec";
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<NhomCongViec> ds = new List<NhomCongViec>();
                foreach (DataRow r in tb.Rows)
                {
                    NhomCongViec ncv = new NhomCongViec();
                    ncv.ID = int.Parse(r["ID"].ToString());
                    ncv.Ten = r["Ten"].ToString();
                    ncv.IdKeHoach = int.Parse(r["IdKeHoach"].ToString());
                    ds.Add(ncv);
                }
                return ds;
            }
            else
                return null;
        }

        public DataTable SelectAllToTable()
        {
            String query = "Select * From NhomCongViec";
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectToTable(String condition)
        {
            String query = "Select Ten, Id, IdKeHoach from NhomCongViec Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectIdAdmin(String condition)
        {
            String query = "Select KeHoach.IdAdmin from NhomCongViec inner join KeHoach on NhomCongViec.IdKeHoach = KeHoach.Id  Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public DataTable SelectIdNCV(String condition)
        {
            String query = "Select Id from NhomCongViec Where " + condition;
            DataTable tb = da.Read(query);
            return tb;
        }

        public List<NhomCongViec> Select(String condition)
        {
            String query = "Select * from NhomCongViec Where " + condition;
            DataTable tb = da.Read(query);
            if (tb != null && tb.Rows.Count > 0)
            {
                List<NhomCongViec> ds = new List<NhomCongViec>();
                foreach (DataRow r in tb.Rows)
                {
                    NhomCongViec ncv = new NhomCongViec();
                    ncv.ID = int.Parse(r["ID"].ToString());
                    ncv.Ten = r["Ten"].ToString();
                    ncv.IdKeHoach = int.Parse(r["IdKeHoach"].ToString());
                    ds.Add(ncv);
                }
                return ds;
            }
            else
                return null;
        }

        public int Insert(String ten, int idkehoach)
        {
            String query = "Insert into NhomCongViec(Ten, IdKeHoach) Values(N'"
                + ten + "', N'"
                + idkehoach.ToString() + "')";
            int dem = da.Write(query);
            return dem;
        }

        public int Update(int id, String ten, int idkehoach)
        {
            String query = "Update NhomCongViec Set Ten=N'"
                + ten + "', IdKeHoach = N'"
                + idkehoach.ToString() + "' Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }

        public int Delete(int id)
        {          
            String query = "Delete NhomCongViec Where Id=" + id.ToString();
            int dem = da.Write(query);
            return dem;
        }
    }
}
