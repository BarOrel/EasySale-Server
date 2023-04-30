using EasySale.Data.Models;
using EasySale.Data.Repository;

namespace EasySale.Services.TasksService
{
    public class TaskService : ITaskService
    {
        private readonly IGenericRepository<TaskModel> taskRepository;

        public TaskService(IGenericRepository<TaskModel> taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task AddTask(TaskModel task)
        {
            try
            {
                await taskRepository.Insert(task);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteTask(int task_Id)
        {
            try
            {
                var task = await taskRepository.GetById(task_Id);
                await taskRepository.Delete(task);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task EditTask(TaskModel task)
        {
            try
            {
                await taskRepository.Update(task);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<IEnumerable<TaskModel>> GetTasksByDepartment(int Deparment_Id)
        {
            try
            {
                var Tasks = await taskRepository.GetAll();
                return Tasks.Where(task => task.Department_Id == Deparment_Id);
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public async Task<IEnumerable<TaskModel>> GetTasks()
        {
            try
            {
                return await taskRepository.GetAll();
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public async Task<TaskModel> GetTaskById(int task_id)
        {
            try
            {
                return await taskRepository.GetById(task_id);
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

    }
}
