using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Wipro.API.Entity;


namespace Wipro.API.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class CustomersController : ApiController
    {
        // GET api/customer
        public IEnumerable<Customer> Get()
        {
            return Repository.Select<Customer>();
        }

        // GET api/customer/5
        public Customer Get(string id)
        {
            return Repository.Select<Customer>(id);
        }

        // POST api/customer
        public void Post([FromBody] Customer customer)
        {
            Repository.Insert(customer);
        }

        // PUT api/customer/5
        public void Put(string id, [FromBody] Customer customer)
        {
            Repository.Update(customer);
        }

        // DELETE api/customer/5
        public void Delete(string id)
        {
            Repository.Delete<Customer>(id);
        }
    }
}
