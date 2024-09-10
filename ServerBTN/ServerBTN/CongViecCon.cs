using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class CongViecCon
    {
        public int IdCongViec { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThai { get; set; }
        public int IdNguoiThucHien { get; set; }
        public int IdCongViecCon { get; set; }

        public List<CongViecCon> DanhSachCVC()
        {
            BCongViecCon bcvc = new BCongViecCon();
            return bcvc.Select("CVCId=" + IdCongViecCon.ToString());
        }
    }
}
