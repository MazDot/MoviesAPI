using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Database;
using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;

namespace MoviesAPI.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public MovieRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MovieOutputDto> GetById(int id)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return new MovieOutputDto
            {
                Id = movie.Id,
                MovieTheaters = mapper.Map<List<MovieTheaterOutputDto>>(movie.MovieTheaters),
                Actors = movie.Actors,
                Genres = movie.Genres,
                InTheaters = movie.InTheaters,
                Poster = movie.Poster,
                ReleaseDate = movie.ReleaseDate,
                Summary = movie.Summary,
                Title = movie.Title,
                Trailer = movie.Trailer,
            };
        }

        public async Task<List<MovieOutputDto>> GetAllMovies()
        {
            var moviesList = await context.Movies
                .Include(x => x.Genres)
                .Include(x => x.Actors)
                .Include(x => x.MovieTheaters)
                .ToListAsync();

            var output = new List<MovieOutputDto>();

            foreach (var x in moviesList)
            {
                output.Add(new MovieOutputDto
                {
                    Id = x.Id,
                    MovieTheaters = mapper.Map<List<MovieTheaterOutputDto>>(x.MovieTheaters),
                    Actors = x.Actors,
                    Genres = x.Genres,
                    InTheaters = x.InTheaters,
                    Poster = x.Poster,
                    ReleaseDate = x.ReleaseDate,
                    Summary = x.Summary,
                    Title = x.Title,
                    Trailer = x.Trailer,
                });
            }

            return output;
        }

        public async Task<int> AddMovie (MovieDto dto)
        {
            var movie = mapper.Map<Movie>(dto);
            if(dto.Poster != null)
            {
                movie.Poster = dto.Poster.FileName;
            }

            var result = context.Movies.Add(movie);
            await context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task EditMovie(int id, MovieDto dto)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if(dto.Poster != null)
            {
                movie.Poster = dto.Poster.FileName;
            }            

        }

    }
}
