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

        public int Create(Team team)
        {
            _context.Teams.Add(team);
            return _context.SaveChanges();
        }

        public Team Get(int TeamId)
        {
            return _context.Teams.SingleOrDefault(s => s.TeamId == TeamId);
        }

        public List<Team> GetAllTeam()
        {
            return _context.Teams.ToList();
        }

        public int Update(Team team)
        {
            _context.Teams.Update(team);
            return _context.SaveChanges();
        }
    }
}
