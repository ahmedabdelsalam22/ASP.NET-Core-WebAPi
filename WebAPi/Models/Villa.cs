using System.ComponentModel.DataAnnotations;

namespace WebAPi.Models
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Details { get; set; }
        public int Occupancy { get; set; }
        public int Sqft { get; set; }
        public double Rate { get; set; }
        public String ImageUrl { get; set; }
        public String Amenity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
