using Onion.CleanArchitecture.Net.CoreWorker.DTOs;

namespace Onion.CleanArchitecture.Net.CoreWorker.Interfaces
{
    public interface IEmployeeHttpClientAsync
    {
        Task<List<EmployeeDto>?> GetEmployeeDtosAsync();
        Task<int> CountUser();
        Task<(int add, int update)> SyncEmployee();
    }
}
