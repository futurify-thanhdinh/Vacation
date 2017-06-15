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

        public async Task<int> CreateAsync(Position position)
        {
            if (position == null)
                throw new ArgumentNullException("position");
            await _context.Positions.AddAsync(position);
            return  await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(Position position)
        {
            if (position == null)
                throw new ArgumentNullException("position");
            var existingPosition = await this.GetAsync(position.PositionId);
            if (existingPosition == null)
                throw new NullReferenceException("existing position");
            existingPosition.PositionName = position.PositionName;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> RemovePositionAsync(int PositionId)
        {
            var existingPosition = await this.GetAsync(PositionId);
            if (existingPosition == null)
                throw new NullReferenceException("existing position");
            _context.Positions.Remove(existingPosition);
            return await _context.SaveChangesAsync();
        }
        public async Task<Position> GetAsync(int Id)
        {
            return await _context.Positions.FirstOrDefaultAsync(s => s.PositionId == Id);
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await _context.Positions.ToListAsync();
        }
    }
}
