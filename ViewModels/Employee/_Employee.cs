using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels.Employee
{
    public class _Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int PositionId { get; set; }

        public int DepartmentId { get; set; }

        public List<_Employee> Employees = new List<_Employee>();
    }
}
