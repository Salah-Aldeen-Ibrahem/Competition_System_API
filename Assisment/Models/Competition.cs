using System.ComponentModel.DataAnnotations;

namespace Assisment.Models
{
    public class Competition
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public List<Team> Team { get; set; }
    }
}
