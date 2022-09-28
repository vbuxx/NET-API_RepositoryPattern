using API.Context;
using API.Models;
using API.ViewModels.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        MyContext myContext;

        public EmployeeController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Index()
        {
            var data = myContext.Employees.ToList();

            _Employee employeeList = new _Employee();
            foreach (Employee employee in data)
            {
                employeeList.Employees.Add(new _Employee()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PositionId = employee.PositionId,
                    DepartmentId = employee.DepartmentId
                });

            };

            if (employeeList.Employees != null)
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = employeeList.Employees });
            }
            else
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = "null" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var data = myContext.Employees.Find(id);
            _Employee result = new _Employee()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                PositionId = data.PositionId,
                DepartmentId = data.DepartmentId
            };

            if (result != null)
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = result });
            }
            else
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = "null" });
            }

        }


        //CREATE
        [HttpPost]
        public IActionResult Post(_Employee employee)
        {
            Employee result = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PositionId = employee.PositionId,
                DepartmentId = employee.DepartmentId
            };
            myContext.Employees.Add(result);
            if (myContext.SaveChanges() > 0)
            {
                return Ok(new { message = "Sukses tambah data", statusCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Gagal tambah data", statusCode = 200 });
            }



        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, _Employee employee)
        {
            var data = myContext.Employees.Find(id);
            data.FirstName = employee.FirstName;
            data.LastName = employee.LastName;
            data.PositionId = employee.PositionId;
            data.DepartmentId = employee.DepartmentId;
            myContext.Employees.Update(data);

            if (myContext.SaveChanges() > 0)
            {
                return Ok(new { message = "Sukses ubah data", statusCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Gagal ubah data", statusCode = 200 });
            }

        }


        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Employees.Find(id);
            myContext.Employees.Remove(data);

            if (myContext.SaveChanges() > 0)
            {
                return Ok(new { message = "Sukses hapus data", statusCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Gagal hapus data", statusCode = 200 });
            }

        }
    }
}
