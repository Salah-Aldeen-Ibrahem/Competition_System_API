using System.ComponentModel.DataAnnotations;

namespace Assisment.Models
{
    public class Coach
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Specializatiion { get; set; }
        [Required]
        public int ExperinceYears { get; set; }
        public Team Team { get; set; }
    }
}
