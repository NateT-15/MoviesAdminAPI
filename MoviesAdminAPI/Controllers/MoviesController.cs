using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAdminAPI.DTOs;
using System.Collections;
using System.Data;

namespace MoviesAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IDbConnection _db;

        //Constructor
        public MoviesController(IDbConnection db)
        {
            _db = db;
        }

        // GET /api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            var sql = @"SELECT m.*, g.*, ar.*
                FROM Movie m
                INNER JOIN Genre g ON m.GenreId = g.Id
                INNER JOIN AudienceRating ar ON m.AudienceRatingId = ar.Id";
                

            // Fetch all movies from database <Table 1, Table 2, Table 3>
            var movies = await _db.QueryAsync<Movie,Genre,AudienceRating,Movie>(
                sql,
                (movie, genre, audienceRating) =>
                {
                    movie.Genre = genre;
                    movie.AudienceRating = audienceRating;
                    return movie;
                });

            return Ok(movies);
        }
    }
}
