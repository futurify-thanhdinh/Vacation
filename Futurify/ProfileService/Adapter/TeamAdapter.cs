using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileService.Model;
using ProfileService.Model.ViewModel;

namespace ProfileService.Adapter
{
    public static class TeamAdapter
    {
        public static IEnumerable<EmployeeTeamViewModel> ToEmployeeViewModel(IEnumerable<Employee> employees) 
        { 
            List<EmployeeTeamViewModel> employeeTeamViewModels = new List<EmployeeTeamViewModel>();
            foreach(Employee employee in employees)
            {
                EmployeeTeamViewModel employeeViewModel = new EmployeeTeamViewModel();
                employeeViewModel.Id = employee.EmployeeId;
                employeeViewModel.Name = employee.FirstName + " " + employee.LastName;
                employeeTeamViewModels.Add(employeeViewModel);
            }
           
            return employeeTeamViewModels;
        }
    }
}
