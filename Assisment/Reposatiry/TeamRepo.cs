using Assisment.Data;
using Assisment.InterFaces;
using Assisment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assisment.Reposatiry
{
    public class TeamRepo : GenericRepo<Team>, ITeam
    {
        public TeamRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Team>> GetTeams()
        {
           return await _context.Teams.Include(c => c.Competition).Include(p => p.Player).Where(a => !a.Competition.Any())
                .ToListAsync();
        }
    }
}
