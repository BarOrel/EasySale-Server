using EasySale.Data.Models;

namespace EasySale.Services.TasksService
{
    public interface ITaskService
    {
        Task AddTask(TaskModel task);
        Task DeleteTask(int task_Id);
        Task EditTask(TaskModel task);
        Task<IEnumerable<TaskModel>> GetTasksByDepartment(int Deparment_Id);
        Task<IEnumerable<TaskModel>> GetTasks();
        Task<TaskModel> GetTaskById(int task_id);
    }
}
