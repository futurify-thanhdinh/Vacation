using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schedule.Adapters;
using Schedule.IServiceInterfaces;
using Schedule.Models;
using Schedule.Models.BindingModels;
using Schedule.Models.ViewModels;

namespace Schedule.Controllers
{
    [Route("api/schedule")]
    public class ScheduleController : Controller
    {
        private IVacationService _vacationService;
        public ScheduleController(IVacationService vacationService)
        {
            _vacationService = vacationService;
        }
        // GET api/values
        [HttpGet]
        [Route("GetAllVacations")]
        public IEnumerable<VacationViewModel> GetAllVacation()
        {
            var Vacations = _vacationService.GetAllVacations();
            if (Vacations != null)
            {
                return VacationAdapter.ToViewModel(Vacations);
            }
            else
            {
                return null;
            }

            //return Ok(new List<VacationViewModel> { new VacationViewModel() { Id = 3, Start = new DateTime(2017,7,19, 7, 30, 0, DateTimeKind.Utc), End = new DateTime(2017, 7, 19, 12, 30, 0, DateTimeKind.Utc),
            //OwnerId = 1, IsAllDay = false, Title= "asdadfdsfasd", Description = "ok hello ae"} });

        }

       

        // POST api/values
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody]VacationBindingModel vacationBindingModel)
        {
            if (vacationBindingModel != null)
            {
                vacationBindingModel.Id = _vacationService.Create(vacationBindingModel);
                if (vacationBindingModel.Id != 0)
                {
                    return Ok(vacationBindingModel);
                }
                else
                    return BadRequest(vacationBindingModel);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("Update")]
        public IActionResult Update([FromBody]VacationBindingModel vacationBindingModel)
        {
            if(vacationBindingModel != null)
            {
                if (_vacationService.Update(VacationAdapter.ToModel(vacationBindingModel)) != 0)
                    return Ok(vacationBindingModel);
                else
                    return BadRequest(vacationBindingModel);
            }
            else
            {
                return BadRequest();
            }
            
            
        }

        // DELETE api/values/5
        [HttpDelete("Delete/{Id}")]
        public IActionResult Delete(int? Id)
        {
            if (Id.HasValue)
            {
                if (_vacationService.Delete((int)Id) != 0)
                    return Ok();
                else
                    return BadRequest();
            } 
            else
                return BadRequest();
        }
    }
}
