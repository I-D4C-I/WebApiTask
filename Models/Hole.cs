using System.ComponentModel.DataAnnotations;

namespace WebApiTask.Models
{
    public class Hole
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int DrillBlockId { get; set; }
        public double Depth { get; set; }
    }
}
