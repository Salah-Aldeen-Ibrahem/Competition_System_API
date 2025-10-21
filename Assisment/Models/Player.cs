using System.ComponentModel.DataAnnotations;

namespace Assisment.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
