using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;

namespace MoviesAPI.Services
{
    public interface IGenreRepository
    {
        Task<int> AddGenre(GenreDto gen);
        Task<int> EditGenre(int id, GenreDto gen);
        Task<List<Genre>> GetAllGenres();
        Task<Genre> GetById(int id);
    }
}
