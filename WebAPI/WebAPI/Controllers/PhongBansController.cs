using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PhongBansController : ApiController
    {
        //***************************lấy dữ liệu từ database /api/NhanViens  **********************
        public HttpResponseMessage Get()
        {
            string query = @"select * 
                             from dbo.PhongBan";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLNVData"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        //***************Thêm nhân viên********************
        public string Post(PhongBan pb)
        {
            try
            {
                string query = @"
                    insert into dbo.PhongBan values
                    (N'" + pb.MaPB + "',N'" + pb.TenPB + @"')    
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLNVData"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Thành công !!";
            }
            catch (Exception)
            {

                return "Không thành công !!";
            }
        }
        //**********************Sửa nhân viên***********************
        public string Put(PhongBan pb)
        {
            try
            {
                string query = @"
                    update dbo.PhongBan 
                    set TenPB=N'" + pb.TenPB + @"'
                    where MaPB='" + pb.MaPB + @"' 
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLNVData"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Thành công !!";
            }
            catch (Exception)
            {

                return "Không thành công !!";
            }
        }
        //*********************Xóa nhân viên*********************************
        public string Delete(string id)
        {
            try
            {
                string query = @"delete from dbo.PhongBan 
                                where MaPB='" + id + @"'";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLNVData"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Thành công !!";
            }
            catch (Exception)
            {
                return "Không thành công !!";
            }
        }
    }
}