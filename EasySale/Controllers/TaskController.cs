using EasySale.Data.Models;
using EasySale.Services.TasksService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasySale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet("{Deparment_Id}")]
        public async Task<IActionResult> GetTasksByDeparments(int Deparment_Id)
        {
            try
            {
                var TasksByUser = await taskService.GetTasksByDepartment(Deparment_Id);
                return Ok(TasksByUser);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpGet("GetById/{task_id}")]
        public async Task<IActionResult> GetTaskById(int task_id)
        {
            try
            {
                var Task = await taskService.GetTaskById(task_id);
                return Ok(Task);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                var Tasks = await taskService.GetTasks();
                return Ok(Tasks);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskModel task)
        {
            try
            {
                await taskService.AddTask(task);
                return Ok(task);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            try
            {
                await taskService.DeleteTask(taskId);
                return Ok($"Task : {taskId} \nHas Been Deleted");
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPatch]
        public async Task<IActionResult> EditTask(TaskModel task)
        {
            try
            {
                await taskService.EditTask(task);
                return Ok(task);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

    }
}
