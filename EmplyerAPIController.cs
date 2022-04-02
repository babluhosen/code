using Code.Data;
using Code.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmplyerAPIController : ControllerBase
    {
        private readonly IEmplerRepository emplerRepository;
        public EmplyerAPIController(IEmplerRepository emplerRepository)
        {
            this.emplerRepository = emplerRepository;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Getempler(int id)
        {
            var result = await emplerRepository.GetEmplyers(id);
            if (result == null)
            {
                return NotFound();
            }
            try
            { 
                return Ok(await emplerRepository.GetEmplyers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Creatempler(int empId)
        {
            var result = await emplerRepository.GetEmplyers(empId);
            if (result == null)
            {
                return BadRequest();
            }
            try
            {

                return Ok(await emplerRepository.GetEmplyers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error data from the database");
            }
        }
        public async Task<ActionResult> Updateempler(int id,emplyer emplyer)
        {
          
            try
               
            {
                if (id != emplyer.empId)
                    return BadRequest("ID does not match");
                var result = await emplerRepository.GetEmplyers(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(await emplerRepository.Updateemplyer(emplyer));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error data from the database");
            }
        }

    }
}
