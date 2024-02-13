using System.ComponentModel.DataAnnotations;

namespace WebApiTask.Models
{
    public class DrillBlockPoint
    {
        public int Id { get; set; }
        [Required]
        public int DrillBlockId { get; set; }
        public double Sequence { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
