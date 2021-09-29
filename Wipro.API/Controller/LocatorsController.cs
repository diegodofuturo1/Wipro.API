using System.Web.Http;
using Wipro.API.Entity;
using System.Web.Http.Cors;
using System.Collections.Generic;

namespace Wipro.API.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class LocatorsController : ApiController
    {
        // GET api/locator
        public IEnumerable<Locator> Get()
        {
            return Repository.Select<Locator>();
        }

        // GET api/locator/5
        public Locator Get(string id)
        {
            return Repository.Select<Locator>(id);
        }

        // POST api/locator
        public void Post([FromBody] Locator locator)
        {
            Repository.Insert(locator);
        }

        // PUT api/locator/5
        public void Put(string id, [FromBody] Locator locator)
        {
            Repository.Update(locator);
        }

        // DELETE api/locator/5
        public void Delete(string id)
        {
            Repository.Delete<Locator>(id);
        }
    }
}
