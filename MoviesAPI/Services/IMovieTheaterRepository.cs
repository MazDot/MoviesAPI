using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;

namespace MoviesAPI.Services
{
    public interface IMovieTheaterRepository
    {
        Task<int> Add(MovieTheaterDto dto);
        Task Delete(int id);
        Task Edit(int id, MovieTheaterDto dto);
        Task<List<MovieTheater>> GetAllMovieTheaters();
        Task<MovieTheater> GetById(int id);
    }
}
