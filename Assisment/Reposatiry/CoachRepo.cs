using Assisment.Data;
using Assisment.InterFaces;
using Assisment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assisment.Reposatiry
{
    public class CoachRepo : GenericRepo<Coach>, ICoach
    {
        public CoachRepo(AppDbContext context) : base(context)
        {
        }

        public Task<Coach> Check(int id)
        {
            return _context.Coachs.Where(c => c.Team == null).FirstOrDefaultAsync(i =>i.Id == id);
        }

        public async Task<Coach> GetCoach(int id)
        {
            return await _context.Coachs.Include(t => t.Team).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Coach>> GetCoachwithTeams()
        {
            return await _context.Coachs.Include(t => t.Team).ToListAsync();
        }

        public async Task<Coach> GetSpCoach(int id)
        {
            return await _context.Coachs.Include(t => t.Team).ThenInclude(p => p.Player).FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
