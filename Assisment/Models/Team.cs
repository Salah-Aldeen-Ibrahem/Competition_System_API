using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Assisment.Models
{
    [Index (nameof(Name ) , IsUnique = true)]
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public int CoachId { get; set; }
        public Coach Coach { get; set; } 
        public List<Player> Player { get; set; }
        public List<Competition> Competition { get; set; }
    }
}
