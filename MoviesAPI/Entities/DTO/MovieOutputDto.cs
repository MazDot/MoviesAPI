﻿using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Entities.DTO
{
    public class MovieOutputDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Summary { get; set; }
        public string? Trailer { get; set; }
        public bool InTheaters { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Poster { get; set; }
        public List<Genre>? Genres { get; set; }
        public List<Actor>? Actors { get; set; }
        public List<MovieTheaterOutputDto>? MovieTheaters { get; set; }
    }
}
