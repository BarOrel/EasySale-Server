using EasySale.Data.Models;
using EasySale.Services.DepratmentService;
using EasySale.Services.TasksService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasySale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepratmentService depratmentService;

        public DepartmentController(IDepratmentService depratmentService)
        {
            this.depratmentService = depratmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDeparments()
        {
            try
            {
                var departments = await depratmentService.GetDeparments();
                return Ok(departments);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeparmentById(int id)
        {
            try
            {
                var departments = await depratmentService.GetDeparmentById(id);
                return Ok(departments);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeparment(Department department)
        {
            try
            {
                await depratmentService.AddDeparment(department);
                return Ok(department);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpDelete("{deparment_id}")]
        public async Task<IActionResult> DeleteTask(int deparment_id)
        {
            try
            {
                await depratmentService.DeleteDeparment(deparment_id);
                return Ok($"Task : {deparment_id} \nHas Been Deleted");
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPatch]
        public async Task<IActionResult> EditTask(Department department)
        {
            try
            {
                await depratmentService.EditDeparment(department);
                return Ok(department);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}
