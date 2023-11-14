using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository repository;

        public MoviesController(IMovieRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(MovieDto dto)
        {
             return await repository.AddMovie(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieOutputDto>>> Get()
        {
            return await repository.GetAllMovies();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieOutputDto>> GetById(int id)
        {
            return await repository.GetById(id);
        }

        /*[HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id)
        {

        }*/

    }
}
