using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class TepTin
    {
        public int Id { get; set; }
        public int IdCongViecCon { get; set; }
        public int IdNguoiUpdateTep { get; set; }
        public String TenTep { get; set; }
        public DateTime ThoiGianUpdate { get; set; }
        public string DuLieuTep { get; set; }

        public List<TepTin> DanhSachTT()
        {
            BTepTin btt = new BTepTin();
            return btt.Select("TTId=" + Id.ToString());
        }
    }
}
