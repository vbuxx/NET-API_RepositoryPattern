using API.Context;
using API.Models;
using API.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        MyContext myContext;

        public DepartmentController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Index()
        {
            var data = myContext.Departments.ToList();

            _Department departmentList = new _Department();
            foreach (Department department in data) {
                departmentList.Departments.Add(new _Department() {
                    Id = department.Id,
                    Name = department.Name,
                    DivisionId = department.DivisionId
            });
                
            };

            if (departmentList.Departments != null)
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = departmentList.Departments });
            }
            else
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = "null" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var data = myContext.Departments.Find(id);
            _Department result = new _Department() { 
            Id=data.Id,
            Name=data.Name,
            DivisionId=data.DivisionId
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
        public IActionResult Post(_Department department)
        {
            Department result = new Department()
            {
                Id = department.Id,
                Name = department.Name,
                DivisionId = department.DivisionId
            };
            myContext.Departments.Add(result);
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
        public IActionResult Put(int id, _Department department)
        {
            var data = myContext.Departments.Find(id);
            data.Name = department.Name;
            data.DivisionId = department.DivisionId;
            myContext.Departments.Update(data);

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
            var data = myContext.Departments.Find(id);
            myContext.Departments.Remove(data);

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
