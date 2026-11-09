using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAdminAPI.DTOs;
using System.Collections;

namespace MoviesAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //Constructor
        public MoviesController()
        {
            //Initialize any dependencies or services here
        }

        // GET /api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            // Create a couple sample movies to return

            var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Movie 1" },
                new Movie { Id = 2, Title = "Movie 2"}
            };
            return Ok(movies);
        }
    }
}
