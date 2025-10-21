using Assisment.Models;

namespace Assisment.InterFaces
{
    public interface ITeam : IGenericRepo<Team>
    {
        Task<List<Team>> GetTeams();
        
    }
}
