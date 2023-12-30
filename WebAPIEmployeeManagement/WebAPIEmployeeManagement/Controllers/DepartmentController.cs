using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIEmployeeManagement.Models;

namespace WebAPIEmployeeManagement.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT [ID]
                                  ,[Name]
                              FROM [ReactEmployeeDB].[dbo].[Department]";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }

                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string Post(Department dept)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"INSERT INTO [ReactEmployeeDB].[dbo].[Department] VALUES ('" + dept.Name + "')";
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(dt);
                        }

                    }
                }
                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Failed To Add";
            }
        }

        public string Put(Department dept)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"UPDATE [ReactEmployeeDB].[dbo].[Department] SET Name = '" + dept.Name + "' WHERE ID = "+dept.Id;
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(dt);
                        }

                    }
                }
                return "Updated Successfully";
            }
            catch (Exception)
            {
                return "Failed To Update";
            }
        }

        public string Delete(int Id)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"DELETE FROM [ReactEmployeeDB].[dbo].[Department] WHERE ID = " + Id;
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(dt);
                        }

                    }
                }
                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Failed To Delete";
            }
        }
    }
}
