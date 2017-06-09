using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileService.IServiceInterfaces;

namespace ProfileService.Controllers
{
    public class ProfilesController: Controller
    {
        private IPositionService _positionService;

        public ProfilesController(IPositionService service)
        {

        }
    }
}
