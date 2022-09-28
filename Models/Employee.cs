using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Position Positions { get; set; }

        [ForeignKey("Position")]
        public int PositionId { get; set; }

        public Department Department { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
    }
}
