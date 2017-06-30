using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.common.core.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Adapter;
using ProfileService.IServiceInterfaces;
using ProfileService.Model;
using ProfileService.Model.BindingModel;
using ProfileService.Model.ViewModel;

namespace ProfileService.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private string AVATAR_FOLDER = "Avatars";
        private string AVATAR_FOLDER_FULL_PATH; 

        private ITeamService _teamService;
        private IEmployeeService _employeeService;
        private IHostingEnvironment _env;

        public EmployeeController(ITeamService teamService, IEmployeeService employeeService,  IHostingEnvironment env)
        {
            _env = env;
            _teamService = teamService;
            _employeeService = employeeService;
            AVATAR_FOLDER_FULL_PATH = Path.Combine(env.WebRootPath, AVATAR_FOLDER);
           
        }
        // GET: api/Employee
        [HttpGet]
        [Route("EmployeeList")]
        public  IEnumerable<EmployeeViewModel> Get()
        {
            var EmployeeViewModelList = new List<EmployeeViewModel>();
            foreach (Employee employee in  _employeeService.GetAllAsync())
            {
                EmployeeViewModelList.Add(EmployeeAdapter.ToViewModel(employee));
            }
            return EmployeeViewModelList;
            
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Employee
        [HttpPost]
        [Route("UpdateInfo")]
        public void Post(EmployeeBindingModel employee)
        {
            var ok = employee;
            var i = 0;
        }
        
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("UploadAvatar/{EmployeeId}")]
        public IActionResult UploadAvatar(int EmployeeId)
        {
            string[] validExts = new string[] { ".jpeg", ".jpg", ".png" };
            var files = Request.Form.Files;
            if (files == null || files.Count != 1)
            {
                throw new NullReferenceException();
            }
            var file = files.FirstOrDefault();
            var filename = Uploader.GetFileName(file);
            var fileExtension = Path.GetExtension(filename).ToLower();

            if (validExts.Contains(fileExtension))
            {
                var newFileName = Guid.NewGuid().ToString("N") + fileExtension;
                Uploader.Upload(file, AVATAR_FOLDER_FULL_PATH, newFileName);

                var url = $"/{AVATAR_FOLDER}/{newFileName}";

                try
                {
                     _employeeService.UpdateAvatar(EmployeeId, url);
                    return Ok() ;
                }
                catch (Exception e)
                {
                    System.IO.File.Delete(Path.Combine(AVATAR_FOLDER_FULL_PATH, newFileName));
                    throw e;
                }
            }
            else
            {
                throw new FileLoadException("Invalid File Extension");
                 
            }
        }
    }
}
