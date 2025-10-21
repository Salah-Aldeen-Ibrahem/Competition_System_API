using System.Security.Cryptography;
using Assisment.Dtos;
using Assisment.InterFaces;
using Assisment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeam _repo;
        private readonly ICoach _Coach;

        public TeamController( ITeam repo, ICoach coach)
        {
            _repo = repo;
            _Coach = coach;
        }
        [HttpPost]
        public async Task<IActionResult> CrateTeam([FromBody] TeamDto teamDto)
        {
            if (teamDto.Name == null) return BadRequest("The Name is required");
            if (teamDto.CoachId <= 0) return BadRequest("The CoachID Should be positive number");
            var ch = await _Coach.GetCoach(teamDto.CoachId);
            if (ch == null) return BadRequest($"This coachId {teamDto.CoachId} is not found");
            var ch2 = await _Coach.Check(teamDto.CoachId);
            if (ch2 == null)  return BadRequest($"The Coach with id {teamDto.CoachId} has a team already");
            Team team = new Team { 
                Name = teamDto.Name,
                City = teamDto.City,
                CoachId = teamDto.CoachId,
            };

            await _repo.CreateAsync(team);
            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var get = await _repo.GetTeams();
            var filter = get.Select(m => new
            {
                m.Name, 
                m.City,
                m.CoachId,
                CountOfPlayers = m.Player.Count()
            }).OrderByDescending(n => n.CountOfPlayers).ToList();
            return Ok(filter);
        }
    }
}
