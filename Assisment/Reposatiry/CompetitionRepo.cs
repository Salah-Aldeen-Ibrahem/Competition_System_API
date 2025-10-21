using Assisment.Data;
using Assisment.InterFaces;
using Assisment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assisment.Reposatiry
{
    public class CompetitionRepo : GenericRepo<Competition>, ICompetition
    {
        public CompetitionRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Competition>> GetCompetitionAsync()
        {
          return await _context.Competitions.Include(t => t.Team).ThenInclude(p => p.Player).ToListAsync();
        }
    }
}
