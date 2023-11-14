using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTheaterController : ControllerBase
    {
        private readonly IMovieTheaterRepository repository;
        public MovieTheaterController(IMovieTheaterRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieTheaterOutputDto>> GetById (int id)
        {
            return await repository.GetById(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieTheaterOutputDto>>> Get ()
        {
            return await repository.GetAllMovieTheaters();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] MovieTheaterDto dto)
        {
            return await repository.Add(dto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] MovieTheaterDto dto)
        {
            try
            {
                await repository.Edit(id, dto);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete (int id)
        {
            try
            {
                await repository.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
