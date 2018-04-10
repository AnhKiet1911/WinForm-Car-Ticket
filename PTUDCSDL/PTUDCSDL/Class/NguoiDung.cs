using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTUDCSDL
{
    class NguoiDung
    {
        string _Ten = "";
        string _NgaySinh = "";
        string _GioiTinh = "";
        string _DiaChi = "";
        string _SoDienThoai = "";

        public string Ten
        {
            get
            {
                return _Ten;
            }

            set
            {
                _Ten = value;
            }
        }

        public string NgaySinh
        {
            get
            {
                return _NgaySinh;
            }

            set
            {
                _NgaySinh = value;
            }
        }

        public string GioiTinh
        {
            get
            {
                return _GioiTinh;
            }

            set
            {
                _GioiTinh = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return _DiaChi;
            }

            set
            {
                _DiaChi = value;
            }
        }

        public string SoDienThoai
        {
            get
            {
                return _SoDienThoai;
            }

            set
            {
                _SoDienThoai = value;
            }
        }
    }
}
