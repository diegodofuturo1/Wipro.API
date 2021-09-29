using System.Web.Http;
using Wipro.API.Entity;
using System.Collections.Generic;

namespace Wipro.API.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class RentsController : ApiController
    {
        // GET api/rent
        public IEnumerable<Rent> Get()
        {
            return Repository.Select<Rent>();
        }

        // GET api/rent/5
        public Rent Get(string id)
        {
            return Repository.Select<Rent>(id);
        }

        // POST api/rent
        public void Post([FromBody] Rent rent)
        {
            Repository.Insert(rent);
        }

        // PUT api/rent/5
        public void Put(string id, [FromBody] Rent rent)
        {
            Repository.Update(rent);
        }

        // DELETE api/rent/5
        public void Delete(string id)
        {
            Repository.Delete<Rent>(id);
        }
    }
}
