using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTUDCSDL.Class
{
    class ChuyenXe
    {
        string _IdChuyen;
        string _SoXe;
        string _NgayDi;
        string _GioDi;
        string _HieuXe;
        int _SoGheTrong;
        string _XuatPhat;
        string _DichDen;

        public string IdChuyen
        {
            get
            {
                return _IdChuyen;
            }

            set
            {
                _IdChuyen = value;
            }
        }

        public string SoXe
        {
            get
            {
                return _SoXe;
            }

            set
            {
                _SoXe = value;
            }
        }

        public string NgayDi
        {
            get
            {
                return _NgayDi;
            }

            set
            {
                _NgayDi = value;
            }
        }

        public string GioDi
        {
            get
            {
                return _GioDi;
            }

            set
            {
                _GioDi = value;
            }
        }

        public string HieuXe
        {
            get
            {
                return _HieuXe;
            }

            set
            {
                _HieuXe = value;
            }
        }

        public int SoGheTrong
        {
            get
            {
                return _SoGheTrong;
            }

            set
            {
                _SoGheTrong = value;
            }
        }

        public string XuatPhat
        {
            get
            {
                return _XuatPhat;
            }

            set
            {
                _XuatPhat = value;
            }
        }

        public string DichDen
        {
            get
            {
                return _DichDen;
            }

            set
            {
                _DichDen = value;
            }
        }
    }
}
