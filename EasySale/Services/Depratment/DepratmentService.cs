using EasySale.Data.Models;
using EasySale.Data.Repository;

namespace EasySale.Services.DepratmentService
{
    public class DepratmentService : IDepratmentService
    {
        private readonly IGenericRepository<Department> deparmentRepository;

        public DepratmentService(IGenericRepository<Department> deparmentRepository)
        {
            this.deparmentRepository = deparmentRepository;
        }

        public async Task AddDeparment(Department department)
        {
            try
            {
                await deparmentRepository.Insert(department);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task EditDeparment(Department department)
        {
            try
            {
                await deparmentRepository.Update(department);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteDeparment(int deparment_Id)
        {
            try
            {
                var task = await deparmentRepository.GetById(deparment_Id);
                await deparmentRepository.Delete(task);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<IEnumerable<Department>> GetDeparments()
        {
            try
            {
                 return await deparmentRepository.GetAll();
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<Department> GetDeparmentById(int id)
        {
            try
            {
                return await deparmentRepository.GetById(id);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
