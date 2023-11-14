using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Helpers;

namespace MoviesAPI.Entities.DTO
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string? Summary { get; set; }
        public string? Trailer { get; set; }
        public bool InTheaters { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public IFormFile? Poster { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int>? Genres { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int>? Actors { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int>? MovieTheaters { get; set; }
    }
}
