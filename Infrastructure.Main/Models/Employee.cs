using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        public string NationalIDNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public char? MaritalStatus { get; set; }
        public char? Gender { get; set; }
        public DateTime? HireDate { get; set; }
        public int? VacationHours { get; set; }
        public int? SickLeaveHours { get; set; }

        public string JobTitle { get; set; }
        public bool IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }
        public Department Department { get; set; }

        public ICollection<Project> ProjectManagers { get; set; }
        public ICollection<Project> InitialContacts { get; set; }
    }
}
