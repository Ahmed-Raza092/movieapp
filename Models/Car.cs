using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace MvcMovie.Models
{
    public class Car
    {
       
        public int Id { get; set; }

        [Display(Name = "Car Name")]
        public string Name { get; set; }
        public string Make { get; set; }
        
        public int Model { get; set; }
        public string Type { get; set; }

        public int Cost { get; set; }

    }
}
