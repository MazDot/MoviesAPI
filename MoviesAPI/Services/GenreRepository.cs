using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Database;
using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;

namespace MoviesAPI.Services
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenreRepository(ApplicationDbContext context, IMapper _mapper)
        {
            this.context = context;
            mapper = _mapper;
        }
        public async Task<List<Genre>> GetAllGenres ()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            return await context.Genres.FirstOrDefaultAsync(gen => gen.Id == id);
        }

        public async Task<int> AddGenre (GenreDto gen)
        {
            var g = context.Genres.Add(mapper.Map<Genre>(gen));
            await context.SaveChangesAsync();
            return g.Entity.Id;
        }
        public async Task<int> EditGenre (int id, GenreDto gen)
        {
            var g = await context.Genres.FirstOrDefaultAsync(gen => gen.Id == id);
            if (g != null)
            {
                g.Name = gen.Name;
                context.Genres.Update(g);
                await context.SaveChangesAsync();
                return g.Id;
            }
            return 0;
        }

        public async Task DeleteGenre (int id)
        {
            var g = await context.Genres.FirstOrDefaultAsync(gen => gen.Id == id);
            if(g == null)
            {
                throw new Exception();
            }
            context.Genres.Remove(g);
            await context.SaveChangesAsync();
        }
    }
}
