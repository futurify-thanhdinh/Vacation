using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileService.Model;

namespace ProfileService.IServiceInterfaces
{
    public interface IEmployeeService
    {
        Employee GetAsync(int Id);
        IEnumerable<Employee> GetAllAsync();
        Task<int> CreateAsync(Employee employee);
        Task<int> UpdateAsync(Employee employee);
        Task<int> RemovePositionAsync(int employeeId);
        Task UpdateAvatar(int EmployeeId, string Url);
    }
}
