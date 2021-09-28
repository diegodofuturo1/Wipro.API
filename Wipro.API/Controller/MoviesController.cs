using System.Web.Http;
using Wipro.API.Entity;
using System.Collections.Generic;

namespace Wipro.API.Controllers
{
    public class MoviesController : ApiController
    {
        // GET api/movie
        public IEnumerable<Movie> Get()
        {
            return Repository.Select<Movie>();
        }

        // GET api/movie/5
        public Movie Get(string id)
        {
            return Repository.Select<Movie>(id);
        }

        // POST api/movie
        public void Post([FromBody] Movie movie)
        {
            Repository.Insert(movie);
        }

        // PUT api/movie/5
        public void Put(string id, [FromBody] Movie movie)
        {
            Repository.Update(movie);
        }

        // DELETE api/movie/5
        public void Delete(string id)
        {
            Repository.Delete<Movie>(id);
        }
    }
}
