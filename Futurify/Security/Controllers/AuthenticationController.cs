using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.common.core.Authentication;
using App.common.core.Exceptions;
using App.common.core.Helpers;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PhoneNumbers;
using Security.Adapters;
using Security.IServiceInterfaces;
using Security.Models.BindingModels;

namespace Security.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private IAccountService _accountService; 
        public AuthenticationController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel registerModel)
        {
            var account = AccountAdapter.RegisterModelToModel(registerModel);
            if (account == null || !ModelState.IsValid)
            {
                throw new CustomException("Errors.INVALID_REGISTRATION_DATA", "Errors.INVALID_REGISTRATION_DATA_MSG");
            }

            try
            {
                if (registerModel.PhoneNumner != null)
                {
                    var formatedPhoneNumber = PhoneNumbers.PhoneNumberHelpers.GetFormatedPhoneNumber(registerModel.PhoneNumner);
                    account.PhoneNumber = formatedPhoneNumber;
                }
                //standardize phone number
                
            }
            catch (NumberParseException)
            {
                throw new CustomException("Errors.INVALID_PHONE_NUMBER", "Errors.INVALID_PHONE_NUMBER_MSG");
            }

            account.AccountPermissions = new List<Models.AccountPermission>()
            {
                 new Models.AccountPermission
                 {
                      PermissionId = "CREATE_USER"
                 }
            };

            account = await _accountService.CreateAsync(account, account.Password);

            //publish a jobseeker account is created message to rabbit mq bus
           // await _rawRabbitBus.PublishAsync(new JobseekerAccountCreated { Id = account.Id, PhoneNumber = account.PhoneNumber, Status = account.Status, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email });

            //string smsContent = $"Verification code at JobHop: {account.VerificationCodes.First().VerifyCode}";

            ////send SMS using eSMS.vn
            //var response = await _esmsService.SendSMS(account.PhoneNumber, smsContent, 4);

            var viewModel = AccountAdapter.ToViewModel(account);

            
            return new JsonResult(viewModel);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
         
    }
}
