using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        public string? Employee_name { get; set; }
        public decimal Employee_salary { get; set; }
        public short Employee_age { get; set; }
        public string? Profile_image { get; set; }
    }
}
