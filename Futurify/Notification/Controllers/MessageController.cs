using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.common.core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Notification.Handles;
using Notification.IServiceInterfaces;
using Notification.Models;
using Notification.Services;
using RawRabbit;
using RawRabbit.Context;
using Vacation.common;
using Vacation.common.Events;


namespace Notification.Controllers
{
    [Route("api/message")]
    public class MessageController : Controller
    {
        private IMailService _mailService;
        private IBusClient _rawRabbitBus;
        private ConfigSendEmail _configSendEmail;
        private IHostingEnvironment _env;
        public MessageController(IHostingEnvironment env, IBusClient rawRabbitBus, IMailService mailService, IOptions<ConfigSendEmail> configSendEmail)
        {
            _configSendEmail = configSendEmail.Value;
            _mailService = mailService;
            _rawRabbitBus = rawRabbitBus;
            _env = env;
        }
        // GET api/values
        [HttpGet]
        [Route("send")]
        public async void SendEmail()
        {
            ConfigSendEmail config = new ConfigSendEmail(_configSendEmail);

            try
            {
                AccountCreatedForEmail accountCreated = new AccountCreatedForEmail();
                accountCreated.Email = "thanh.kyanon@gmail.com";
                accountCreated.FirstName = "Thành";
                accountCreated.Password = "asdqASSDw";
                IMailService emailService = new MailService();
                IDataStaticService dataService = new DataStaticService(_env);
                MailTemplate mailTemplate = dataService.GetMailTemplate(CommonContants.AccountCreated);
                if (mailTemplate != null)
                {
                    config.Receivers = new List<string>() { accountCreated.Email };//send an email
                    await emailService.SendMail(config, mailTemplate, accountCreated);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            //var messageHandler = new DemoHandler();
            //_rawRabbitBus.SubscribeAsync<DemoRabbit>(messageHandler.HandleAsync);
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
