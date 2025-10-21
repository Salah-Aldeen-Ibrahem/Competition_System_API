using Assisment.Models;

namespace Assisment.InterFaces
{
    public interface IPlayer : IGenericRepo<Player>
    {
        Task<List<Player>> GetPlayer();
    }
}
