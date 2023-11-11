﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;
using MoviesAPI.Entities.DTO;
using MoviesAPI.Filters;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _repository;
        private readonly ILogger<GenresController> _logger;

        public GenresController(IGenreRepository repository, ILogger<GenresController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Genre>>> GetAllGenres()
        {
            return await _repository.GetAllGenres();
        }

        [HttpGet("/{id}")]
        //[ResponseCache(Duration = 60)]
        public async Task<ActionResult<Genre>> GetById(int id)
        {
            var gen = await _repository.GetById(id);
            if (gen == null)
            {
                _logger.LogWarning($"Genre with id: {id} was not found");
                return NotFound();
            }
            return gen;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] GenreDto genre)
        {
            
            return await _repository.AddGenre(genre);
        }

        [HttpPut]
        public ActionResult Put([FromBody] GenreDto genre)
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }

    }
}