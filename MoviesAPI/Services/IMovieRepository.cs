using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;

namespace MoviesAPI.Services
{
    public interface IMovieRepository
    {
        Task<int> AddMovie(MovieDto dto);
        Task<List<MovieOutputDto>> GetAllMovies();
        Task<MovieOutputDto> GetById(int id);
    }
}
