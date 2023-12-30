using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIEmployeeManagement.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Department { get; set; }
        public string EmailId { get; set; }
        public DateTime? DOJ  { get; set; }
    }
}