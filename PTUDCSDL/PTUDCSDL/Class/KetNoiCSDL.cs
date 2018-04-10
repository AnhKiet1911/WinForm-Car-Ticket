using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace PTUDCSDL
{
    class KetNoiCSDL
    {
        public static SqlConnection KetNoiSQL()
        {
            var Con = new SqlConnection();
            Con.ConnectionString = "Data Source=AK-PC;Initial Catalog=HeThongBanVeXe;Integrated Security=True";//Đường dẫn database
            return Con;
        }
    }
}
