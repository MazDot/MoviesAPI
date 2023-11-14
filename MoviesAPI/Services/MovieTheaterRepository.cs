using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Database;
using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;

namespace MoviesAPI.Services
{
    public class MovieTheaterRepository : IMovieTheaterRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MovieTheaterRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<MovieTheaterOutputDto>> GetAllMovieTheaters()
        {
            var result = await context.MovieTheaters.ToListAsync();
            return mapper.Map<List<MovieTheaterOutputDto>>(result);
        }

        public async Task<MovieTheaterOutputDto> GetById(int id)
        {
            var theater = await context.MovieTheaters.SingleOrDefaultAsync(x => x.Id == id);
            return mapper.Map<MovieTheaterOutputDto>(theater);
        }

        public async Task<int> Add(MovieTheaterDto dto)
        {
            var result = context.MovieTheaters.Add(mapper.Map<MovieTheater>(dto));
            await context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Edit(int id, MovieTheaterDto dto)
        {
            var theater = await context.MovieTheaters.FirstOrDefaultAsync(x => x.Id == id);
            if(theater == null)
            {
                throw new Exception();
            }
            theater.Name = dto.Name;
            theater.Location.Y = dto.Latitude;
            theater.Location.X = dto.Longitude;
            context.Update(theater);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            context.MovieTheaters.Remove(new MovieTheater { Id = id });
            await context.SaveChangesAsync();
        }

    }
}
