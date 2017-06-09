using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfileService.IServiceInterfaces;
using ProfileService.Model;

namespace ProfileService.Services
{
    public class PositionService : IPositionService
    {
        private ProfileContext _context;
        public PositionService(ProfileContext context)
        {
            _context = context;
        }

        public async Task CreateAsync()
        {
            var position = new Position();
            position.PositionId = 1;
            position.PositionName = "askd;asd";
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
        }

        public async Task<Position> GetAsync(int Id)
        {
            return await _context.Positions.FirstOrDefaultAsync<Position>(s => s.PositionId == Id);
        }
    }
}
