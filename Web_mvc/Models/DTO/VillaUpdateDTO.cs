using System.ComponentModel.DataAnnotations;

namespace Web_mvc.Models.DTO
{
    public class VillaUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public String Name { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public int Sqft { get; set; }
        public String Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public String ImageUrl { get; set; }
        public String Amenity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
