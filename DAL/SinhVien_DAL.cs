using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAL
{
    public class SinhVien_DAL:DBConnection
    {
        public List<SinhVien_DTO> ReadSinhVien()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //khỏi tạo instance của class SqlCommand
            SqlCommand cmd = new SqlCommand();
            //sử dụng thuộc tính CommandText để chỉ định tên Proc
            cmd.CommandText = "spReadStudent";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<SinhVien_DTO> lstSv = new List<SinhVien_DTO>();
            while (reader.Read())
            {
                SinhVien_DTO sv = new SinhVien_DTO();
                sv.Id = reader["Id"].ToString();
                sv.Name = reader["Name"].ToString();
                sv.Email = reader["Email"].ToString();
                sv.Mobile = reader["Mobile"].ToString();
                lstSv.Add(sv);
            }
            conn.Close();
            return lstSv;
        }

        public void DeleteSinhVien(SinhVien_DTO sv)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //khỏi tạo instance của class SqlCommand
            SqlCommand cmd = new SqlCommand();
            //sử dụng thuộc tính CommandText để chỉ định tên Proc
            cmd.CommandText = "spDeleteStudent";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@id", sv.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewSinhVien(SinhVien_DTO sv)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "spInsertStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
 
            cmd.Parameters.Add(new SqlParameter("@Id", sv.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", sv.Name));
            cmd.Parameters.Add(new SqlParameter("@Email", sv.Email));
            cmd.Parameters.Add(new SqlParameter("@Mobile", sv.Mobile));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void EditSinhVien(SinhVien_DTO sv)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //khỏi tạo instance của class SqlCommand
            SqlCommand cmd = new SqlCommand();
            //sử dụng thuộc tính CommandText để chỉ định tên Proc
            cmd.CommandText = "spUpdateStudent";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@Id", sv.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", sv.Name));
            cmd.Parameters.Add(new SqlParameter("@Email", sv.Email));
            cmd.Parameters.Add(new SqlParameter("@Mobile", sv.Mobile));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
//coment dòng 90
