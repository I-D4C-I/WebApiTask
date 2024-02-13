using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApiTask.Models
{
    public class DrillBlock
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
