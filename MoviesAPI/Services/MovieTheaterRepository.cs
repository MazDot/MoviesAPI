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

        public async Task<List<MovieTheater>> GetAllMovieTheaters()
        {
            return await context.MovieTheaters.ToListAsync();
        }

        public async Task<MovieTheater> GetById(int id)
        {
            return await context.MovieTheaters.SingleOrDefaultAsync(x => x.Id == id);
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
