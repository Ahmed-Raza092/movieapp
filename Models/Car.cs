using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace MvcMovie.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Car Name")]
        public string? Name { get; set; }       
        public int Cost { get; set; }


        //Relationships
        public int? MakeId { get; set; }
        [ForeignKey("MakeId")]
        public Make? Make { get; set; }

        public int? ModelId { get; set; }
        [ForeignKey("ModelId")]
        public Model? Model { get; set; }

        public int? CarTypeId { get; set; }
        [ForeignKey("CarTypeId")]
        public CarType? CarType { get; set; }


        //NotMapped
        [NotMapped]
        public List<Make>? Makes { get; set; }
        [NotMapped]
        public List<CarType>? CarTypes { get; set; }
        [NotMapped]
        public List<Model>? Models { get; set; }
    }
}
