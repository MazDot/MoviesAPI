using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository repository;

        public ActorController(IActorRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Actor>>> GetAllActors([FromQuery] PaginationDto paginationDto)
        {
            return await repository.GetActors(paginationDto);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetActorCounts()
        {
            return await repository.GetActorCount();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> GetActorById(int id)
        {
            return await repository.GetActorById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddActor([FromForm] ActorDto dto)
        {
            return await repository.AddActor(dto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> EditActor(int id, [FromBody] ActorDto dto)
        {
            try
            {
                await repository.AddActor(dto);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActor (int id)
        {
            try
            {
                await repository.DeleteActor(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
