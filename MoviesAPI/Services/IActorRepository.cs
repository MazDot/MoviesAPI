using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;

namespace MoviesAPI.Services
{
    public interface IActorRepository
    {
        Task<int> AddActor(ActorDto actor);
        Task DeleteActor(int id);
        Task EditActor(int id, ActorDto dto);
        Task<Actor> GetActorById(int id);
        Task<int> GetActorCount();
        Task<List<Actor>> GetActors(PaginationDto pagination);
    }
}
