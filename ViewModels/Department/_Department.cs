using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels.Department
{
    public class _Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }

        public List<_Department> Departments = new List<_Department>();

    }
}
