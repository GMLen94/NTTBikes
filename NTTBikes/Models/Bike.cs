using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikesByBDEGLR.Models
{
    public class Bike
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Type { get; set; }

        public bool IsWorking { get; set; }

        public bool LockOn { get; set; }

        [ForeignKey("BikeStation")]
        public Guid IdStation { get; set; }
        public BikeStation Station { get; set; }

    }
}
