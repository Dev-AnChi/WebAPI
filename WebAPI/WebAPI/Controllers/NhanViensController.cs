using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class NhanViensController : ApiController
    {
        //***************************lấy dữ liệu từ database /api/NhanViens  **********************
        public HttpResponseMessage Get()
        {
            string query = @"select * 
                             from dbo.NhanVien";
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
        public string Post(NhanVien nv)
        {
            try
            {
                string query= @"
                    insert into dbo.NhanVien values
                    (N'" + nv.MaNV + "',N'" + nv.HoNV+ "',N'" + nv.TenNV + "','" + nv.GioiTinh + "','" +
                    nv.NgaySinh + "','" + nv.Luong + "','" + nv.AnhNV + "','" + nv.DiaChi + "','" + nv.MaPB + @"')    
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
        public string Put(NhanVien nv)
        {
            try
            {
                string query = @"
                    update dbo.NhanVien 
                    set HoNV=N'" + nv.HoNV + "',TenNV=N'" + nv.TenNV + "',GioiTinh='" + nv.GioiTinh + "',NgaySinh='" + nv.NgaySinh + 
                    "',Luong='" + nv.Luong + "',AnhNV='" + nv.AnhNV + "',DiaChi='" + nv.DiaChi + "',MaPB='" + nv.MaPB + @"'
                    where MaNV='" + nv.MaNV+@"' 
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
                string query = @"delete from dbo.NhanVien 
                                where MaNV='" + id + @"'";

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


        //chuyển ảnh vào thư mục Images (chọn file)
        [Route("api/NhanViens/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Images/" + filename);

                postedFile.SaveAs(physicalPath);
                return filename;
            }
            catch (Exception)
            {
                return "Không thành công";
            }
        }

        [Route("api/NhanViens/GetAllPhongBanNames")]
        [HttpGet]
        public HttpResponseMessage GetAllPhongBanNames()
        {
            string query = @"select TenPB from dbo.PhongBan";

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
    }
}