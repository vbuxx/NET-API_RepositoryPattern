using API.Context;
using API.Models;
using API.ViewModels.Region;
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
    public class RegionController : ControllerBase
    {
        MyContext myContext;

        public RegionController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Index()
        {
            var data = myContext.Regions.ToList();

            _Region reg = new _Region();
            foreach (Region region in data)
            {
                reg.Regions.Add(new _Region()
                {
                    Id = region.Id,
                    Name = region.Name,
                    DivisionId = region.DivisionId
                });

            };

            if (reg.Regions != null)
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = reg.Regions });
            }
            else
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = "null" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var data = myContext.Regions.Find(id);
            _Region result = new _Region()
            {
                Id = data.Id,
                Name = data.Name,
                DivisionId = data.DivisionId
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
        public IActionResult Post(_Region region)
        {
            Region result = new Region()
            {
                Id = region.Id,
                Name = region.Name,
                DivisionId = region.DivisionId
            };
            myContext.Regions.Add(result);
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
        public IActionResult Put(int id, _Region region)
        {
            var data = myContext.Regions.Find(id);
            data.Name = region.Name;
            data.DivisionId = region.DivisionId;
            myContext.Regions.Update(data);

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
            var data = myContext.Regions.Find(id);
            myContext.Regions.Remove(data);

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
