using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileService.Model;

namespace ProfileService.IServiceInterfaces
{
    public interface ITeamService
    {
        List<Team> GetAllTeam();
    }
}
