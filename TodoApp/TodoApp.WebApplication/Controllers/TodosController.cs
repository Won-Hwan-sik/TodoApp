using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Apis.Controllers
{
    [Route("api/[Controller]")]
    public class TodosController : ControllerBase
    {
        public IActionResult GetAll()
        {
            return Content("안녕하세요!");
        }

        [HttpPost]
        public IActionResult Add([FromBody]Todo dto)
        {
            return Ok(dto);
        }
    }
}
