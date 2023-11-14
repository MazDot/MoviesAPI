using AutoMapper;
using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;
using NetTopologySuite.Geometries;

namespace MoviesAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<GenreDto, Genre>();//.reversemap for both way mapping

            CreateMap<ActorDto, Actor>()
                .ForMember(x => x.Picture, options => options.Ignore());

            CreateMap<MovieTheaterDto, MovieTheater>()
                .ForMember(x => x.Location, x => x.MapFrom(dto => 
                geometryFactory.CreatePoint(new Coordinate(dto.Longitude, dto.Latitude))));
            CreateMap<MovieTheater, MovieTheaterOutputDto>()
                .ForMember(x => x.Latitude, x => x.MapFrom(dto => dto.Location.Y))
                .ForMember(x => x.Longitude, x => x.MapFrom(dto => dto.Location.X));

            CreateMap<MovieDto, Movie>()
                .ForMember(x => x.Poster, options => options.Ignore());

        }
    }
}
