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
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT [ID]
                              ,[Name]
                              ,[Department]
                              ,[EmailId]
                              ,[DOJ]
                          FROM [ReactEmployeeDB].[dbo].[Employee]";
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

        public string Post(Employee employee)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"INSERT INTO [ReactEmployeeDB].[dbo].[Employee](Name,Department,EmailId,DOJ) VALUES ('" + employee.Name + "',"
                    +"'"+ employee.Department + "',"
                    +"'"+ employee.EmailId + "',"
                    +"'"+ employee.DOJ + "'"
                    + ")";
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
            catch (Exception ex)
            {
                return "Failed To Add";
            }
        }

        public string Put(Employee employee)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"UPDATE [ReactEmployeeDB].[dbo].[Employee] SET 
                    Name = '" + employee.Name + "',"
                    + "Department= " + employee.Department + ","
                    + "EmailId= '" + employee.EmailId + "',"
                    + "DOJ= '" + employee.DOJ + "' WHERE ID = " + employee.Id;
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
            catch (Exception ex)
            {
                return "Failed To Update";
            }
        }

        public string Delete(int Id)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"DELETE FROM [ReactEmployeeDB].[dbo].[Employee] WHERE ID = " + Id;
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
