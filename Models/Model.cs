using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Model
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; } = "";
    }
}
