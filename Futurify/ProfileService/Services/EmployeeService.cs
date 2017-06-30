using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ProfileService.IServiceInterfaces;
using ProfileService.Model;

namespace ProfileService.Services
{
    public class EmployeeService : IEmployeeService
    {

        private IHostingEnvironment _env;
        private ProfileContext _profileContext;
        public EmployeeService(ProfileContext profileContext, IHostingEnvironment env)
        {
            _env = env;
            _profileContext = profileContext;
        }
        public Task<int> CreateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllAsync()
        {
            return  _profileContext.Employees.ToList();
        }

        public Employee GetAsync(int Id)
        {
            return _profileContext.Employees.SingleOrDefault(s => s.EmployeeId == Id);
        }

        public Task<int> RemovePositionAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAvatar(int EmployeeId, string Url)
        {
            var existingEmployee = GetAsync(EmployeeId);
            if (existingEmployee == null)
                throw new NullReferenceException("Null Employee");
            if (!string.IsNullOrEmpty(existingEmployee.Avatar))
            {
                try
                {
                    string fullPath = Path.Combine(_env.WebRootPath, existingEmployee.Avatar.Trim('/'));
                    if (File.Exists(fullPath))
                        File.Delete(fullPath);
                }
                catch (Exception)
                {
                }
            }

            existingEmployee.Avatar = Url;
            await _profileContext.SaveChangesAsync();
        }
    }

     
}
