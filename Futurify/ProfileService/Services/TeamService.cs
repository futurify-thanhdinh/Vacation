using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileService.IServiceInterfaces;
using ProfileService.Model;

namespace ProfileService.Services
{
    public class TeamSevice : ITeamService
    {
        private ProfileContext _context;
        public TeamSevice(ProfileContext context)
        {
            _context = context;
        }
        public List<Team> GetAllTeam()
        {
            return _context.Teams.ToList();
        }
    }
}
