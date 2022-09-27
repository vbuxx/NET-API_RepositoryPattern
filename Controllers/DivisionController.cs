using API.Context;
using API.Models;
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
    public class DivisionController : ControllerBase
    {
        MyContext myContext;

        public DivisionController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Index()
        {
            var datas = myContext.Divisions.ToList();
            return Ok(new { data = datas });
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var data = myContext.Divisions.Find(id);

            if (data != null)
            {
                return Ok(new { data = data });
            }
            else
            {
                return Ok(new { data= "null"});
            }

        }


        //CREATE
        [HttpPost]
        public IActionResult Post(Division division)
        {
           
            myContext.Divisions.Add(division);
            if (myContext.SaveChanges() > 0)
            {
             return Ok();
            }
            else
            {
            return BadRequest();
            }

            
           
        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, Division division)
        {
            var data = myContext.Divisions.Find(id);
            data.Name = division.Name;    
            myContext.Divisions.Update(data);
                
            if (myContext.SaveChanges() > 0)
                {
                    return Ok();
            }
            else
            {
                return BadRequest();
            }
                
        }


        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Divisions.Find(id);
            myContext.Divisions.Remove(data);

            if (myContext.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
