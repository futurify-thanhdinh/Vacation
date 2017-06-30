using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Route("api/Position")]
    public class PositionController : Controller
    {
        private ITeamService _teamService;
        private IPositionService _positionService;
        public PositionController(ITeamService teamService, IPositionService positionService)
        {
            _teamService = teamService;
            _positionService = positionService;
        }
        // GET: api/Profile
        [HttpGet]
        [Route("PositionList")]
        public async Task<IEnumerable<PositionViewModel>> GetAllPosition()
        {
            var PositionViewModelList = new List<PositionViewModel>();
            foreach(Position pos in await _positionService.GetAllAsync())
            {
                PositionViewModelList.Add(PositionAdapter.ToViewModel(pos));
            }
            return PositionViewModelList;
        }

        // GET: api/Profile/5
        [HttpGet]
        [Route("Position/{PositionId}")]
        public async Task<PositionViewModel> GetPosition(int PositionId)
        {
            return PositionAdapter.ToViewModel(await _positionService.GetAsync(PositionId));
        }
        
        // POST: api/Profile
        [HttpPost("CreatePosition")]
        public async Task<int> CreatePosition([FromBody]PositionBindingModel newPosition)
        {
            return await _positionService.CreateAsync(PositionAdapter.ToModel(newPosition));
        }
        
        // PUT: api/Profile/5
        [HttpPut]
        [Route("UpdatePosition/{PositionId}")]
        public async Task<int> UpdatePosition(int PositionId, [FromBody]PositionBindingModel updatePosition)
        { 
            
            return await _positionService.UpdateAsync(PositionAdapter.ToModel(updatePosition, PositionId));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("RemovePosition/{PositionId}")]
        public async Task<int> Delete(int PositionId)
        {
            return await _positionService.RemovePositionAsync(PositionId);
        }

        [HttpGet]
        [Route("GetAllTeam")]
        public IEnumerable<Team> GetAllTeam()
        {
            return _teamService.GetAllTeam();
        }
    }
}
