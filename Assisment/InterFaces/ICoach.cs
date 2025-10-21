using System.Runtime.InteropServices;
using Assisment.Models;

namespace Assisment.InterFaces
{
    public interface ICoach : IGenericRepo<Coach>
    {
        Task<List<Coach>> GetCoachwithTeams();
        Task<Coach> GetSpCoach(int id);
        Task<Coach> GetCoach(int id);
        Task<Coach> Check(int id);
    }
}
