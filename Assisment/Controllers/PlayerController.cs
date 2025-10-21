using Assisment.Dtos;
using Assisment.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayer _repo;

        public PlayerController(IPlayer repo)
        {
            _repo = repo;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id , [FromBody] PlayerDto playerDto)
        {
            var get = await _repo.GetByIDAsync(id);
            if (get == null) return BadRequest($"The Player With id {id} is not found");
            get.Position = playerDto.Position;
            await _repo.UpdateAsync(get);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var get = await _repo.GetPlayer();
            var filter = get.GroupBy(b => b.Team.Name).Select(m => new
            {
                m.Key,
           
                TheYoungest = m.Select(k => new
                {
                    k.FullName,
                    k.Position,
                    k.Age
                }).OrderBy(m => m.Age).FirstOrDefault()
          
            }).ToList();
            return Ok(filter);

        }
    }
}
