using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public decimal AnnualSalary { get; set; }
        public short Age { get; set; }
        public string? Profile_image { get; set; }
    }
}
