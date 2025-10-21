using System.ComponentModel.DataAnnotations;

namespace Assisment.Dtos
{
    public class CoachBasicDataDto
    {
        public string Name { get; set; }
        public string Specializatiion { get; set; }
        [Required]
        public int ExperinceYears { get; set; }
        public List<TeamDto> Team { get; set; } = new List<TeamDto>();
    }
}
