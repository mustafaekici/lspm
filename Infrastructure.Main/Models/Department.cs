using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
