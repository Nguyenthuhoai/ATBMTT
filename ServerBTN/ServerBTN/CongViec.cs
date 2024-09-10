using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class CongViec
    {
        public int IdCongViec { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThai { get; set; }
        public int IdNguoiThucHien { get; set; }
        public int IdNhomCV { get; set; }

        public List<CongViec> DanhSachCV()
        {
            BCongViec bcv = new BCongViec();
            return bcv.Select("CVId=" + IdCongViec.ToString());
        }
    }
}
