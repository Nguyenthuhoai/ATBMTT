using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBTN
{
    public class TinNhan
    {
        public int Id { get; set; }
        public string NguoiNhan { get; set; }
        public string NguoiGui { get; set;  }
        public string NoiDung { get; set; }
        public DateTime ThoiGian { get; set; }

        public List<TinNhan> DanhSachTN()
        {
            BTinNhan btn = new BTinNhan();
            return btn.Select("Id=" + Id.ToString());
        }
    }
}
