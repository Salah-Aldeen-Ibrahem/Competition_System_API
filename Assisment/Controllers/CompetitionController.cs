using Assisment.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private ICompetition _repo;

        public CompetitionController(ICompetition repo)
        {
            _repo = repo;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DEleteComp(int id)
        {
            var ch = await _repo.GetByIDAsync(id);
            if (ch == null) return NotFound($"The Competesion with the id {id} is not found");
            await _repo.DeleteAsync(id);
            return NoContent();

        }
        [HttpGet]
        public async Task<IActionResult> Final()
        {
            var get = await _repo.GetCompetitionAsync();
            var filter = get.GroupBy(l => l.Location).Select(n => new
            {
                Name = n.Key,
                Competesion = n.Select(r => new
                {
                    r.Title,
                    r.Date,
                }),
              Teams = n.SelectMany(t=>t.Team).Select(v => new
              {
                  v.Name,
                 CountingOfPlayyers = v.Player.Count,
              }).ToList(),
            }).ToList();
            return Ok(filter);

        }
    }
}
