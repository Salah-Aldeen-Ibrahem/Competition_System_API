using Assisment.Data;
using Assisment.InterFaces;
using Assisment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assisment.Reposatiry
{
    public class PlayerRepo : GenericRepo<Player>, IPlayer
    {
        public PlayerRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Player>> GetPlayer()
        {
         return await _context.Players.Include(t => t.Team).ToListAsync();
        }
    }
}
