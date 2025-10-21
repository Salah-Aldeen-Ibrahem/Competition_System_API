using Assisment.Models;

namespace Assisment.InterFaces
{
    public interface ICompetition : IGenericRepo<Competition>
    {
        Task<List<Competition>> GetCompetitionAsync();
    }
}
