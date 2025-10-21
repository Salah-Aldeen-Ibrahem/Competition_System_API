using Assisment.Dtos;
using Assisment.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoach _repo;

        public CoachController(ICoach repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetCoaches()
        {
            var get = await _repo.GetCoachwithTeams();
            if(get == null) return NotFound("There is no Coaches");
            var filter = get.GroupBy(n => n.Specializatiion).Select(x => new
            {
                x.Key,
                Coaches = x.Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.ExperinceYears,
                    TeamName = c.Team.Name,
                      TeamBasicInfo =  new
                      {
                          c.Team.City,
                          c.Team.CoachId,
                      }
                })
            }).ToList();
            return Ok(filter);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecificCoach(int id)
        {
            var get = await _repo.GetSpCoach(id);
            if (get == null) return NotFound($"The Coach with id {id} is not found");
            var filtr = new
            {
                get.Name,
                get.Specializatiion,
                get.ExperinceYears,
                TeamName =  get.Team.Name,
                get.Team.City,
                NumberOfPlayers = get.Team.Player.Count(),
            };
        
          
            return Ok(filtr);
            
        }
    }
}
