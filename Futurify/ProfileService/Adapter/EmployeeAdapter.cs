using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileService.Model;
using ProfileService.Model.ViewModel;

namespace ProfileService.Adapter
{
    public class EmployeeAdapter
    {
        public static EmployeeViewModel ToViewModel(Employee employee)
        {
            var ViewModel = new EmployeeViewModel();
            ViewModel.Id = employee.EmployeeId;
            ViewModel.FirstName = employee.FirstName;
            ViewModel.LastName = employee.LastName;
            ViewModel.PhoneNumber = employee.PhoneNumber;
            ViewModel.RemainDayOff = (int)employee.RemainingDay;
            ViewModel.Email = employee.Email;
            ViewModel.PositionId = (int)employee.PositionId;
            ViewModel.Avatar = employee.Avatar;
            ViewModel.BirthDate = (DateTime)employee.BirthDate;
            return ViewModel;
        }
    }
}
