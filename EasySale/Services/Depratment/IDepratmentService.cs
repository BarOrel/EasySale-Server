using EasySale.Data.Models;

namespace EasySale.Services.DepratmentService
{
    public interface IDepratmentService
    {
        Task AddDeparment(Department department);
        Task DeleteDeparment(int deparment_Id);
        Task<IEnumerable<Department>> GetDeparments();
        Task EditDeparment(Department department);
        Task<Department> GetDeparmentById(int id);
    }
}
