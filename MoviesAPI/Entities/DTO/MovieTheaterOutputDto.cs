using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Entities.DTO
{
    public class MovieTheaterOutputDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Longitude{ get; set; }
        public double Latitude { get; set; }
    }
}
