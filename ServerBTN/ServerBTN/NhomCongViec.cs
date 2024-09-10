using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class NhomCongViec
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public int IdKeHoach { get; set; }

        public List<NhomCongViec> DanhSachNhomCV()
        {
            BNhomCongViec bncv = new BNhomCongViec();
            return bncv.Select("NhomCVId=" + ID.ToString());
        }
    }
}
