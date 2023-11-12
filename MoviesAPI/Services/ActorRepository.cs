using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Database;
using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;

namespace MoviesAPI.Services
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActorRepository(ApplicationDbContext _context, IMapper mapper)
        {
            context = _context;
            this.mapper = mapper;
        }

        public async Task<int> AddActor (ActorDto actor)
        {
            var actorToAdd = mapper.Map<Actor>(actor);
            actorToAdd.Picture = actor.Picture.FileName;
            var output = context.Actors.Add(actorToAdd);
            await context.SaveChangesAsync();
            return output.Entity.Id;

        }

        public async Task<int> GetActorCount ()
        {
            return await context.Actors.CountAsync();
        }

        public async Task<List<Actor>> GetActors (PaginationDto pagination)
        {
            return await context.Actors.Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize).ToListAsync();
        }

        public async Task<Actor> GetActorById (int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            actor.Picture = null;
            return actor;
        }

        public async Task EditActor (int id, ActorDto dto)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if(actor == null)
            {
                throw new Exception();
            }
            actor.DateOfBirth= dto.DateOfBirth;
            actor.Picture = dto.Picture.FileName;
            actor.Biography = dto.Biography;
            actor.Name = dto.Name;

            context.Actors.Update(actor);
            await context.SaveChangesAsync();
        }

        public async Task DeleteActor (int id)
        {
            context.Actors.Remove(new Actor { Id = id });
            await context.SaveChangesAsync();
        }

    }
}
