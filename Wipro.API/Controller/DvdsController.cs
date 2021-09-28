using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Wipro.API.Entity;


namespace Wipro.API.Controllers
{
    public class DvdsController : ApiController
    {
        // GET api/dvd
        public IEnumerable<Dvd> Get()
        {
            return Repository.Select<Dvd>();
        }

        // GET api/dvd/5
        public Dvd Get(string id)
        {
            return Repository.Select<Dvd>(id);
        }

        // POST api/dvd
        public void Post([FromBody] Dvd dvd)
        {
            Repository.Insert(dvd);
        }

        // PUT api/dvd/5
        public void Put(string id, [FromBody] Dvd dvd)
        {
            Repository.Update(dvd);
        }

        // DELETE api/dvd/5
        public void Delete(string id)
        {
            Repository.Delete<Dvd>(id);
        }
    }
}
