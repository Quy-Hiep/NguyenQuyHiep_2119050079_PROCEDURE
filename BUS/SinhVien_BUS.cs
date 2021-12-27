using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL;
using DTO;
namespace BUS
{
    public class SinhVien_BUS
    {
        SinhVien_DAL dal = new SinhVien_DAL();
        public List<SinhVien_DTO> ReadSinhVien()
        {
            List<SinhVien_DTO> lstSv = dal.ReadSinhVien();
            return lstSv;
        }
        public void NewSinhVien(SinhVien_DTO sv)
        {
            dal.NewSinhVien(sv);
        }
        public void DeleteSinhVien(SinhVien_DTO sv)
        {
            dal.DeleteSinhVien(sv);
        }
        public void EditSinhVien(SinhVien_DTO sv)
        {
            dal.EditSinhVien(sv);
        }
    }
}
