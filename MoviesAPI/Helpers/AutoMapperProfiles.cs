using AutoMapper;
using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;

namespace MoviesAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GenreDto, Genre>();//.reversemap for both way mapping
        }
    }
}
