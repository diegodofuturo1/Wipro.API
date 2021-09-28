using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Wipro.API.Entity;


namespace Wipro.API.Controllers
{
    public class CustomersController : ApiController
    {
        // GET api/customer
        public IEnumerable<Customer> Get()
        {
            return Repository.Repository.Select<Customer>();
        }

        // GET api/customer/5
        public Customer Get(string id)
        {
            return Repository.Repository.Select<Customer>("1");
        }

        // POST api/customer
        public void Post([FromBody] Customer customer)
        {
            Repository.Repository.Insert(customer);
        }

        // PUT api/customer/5
        public void Put(string id, [FromBody] Customer customer)
        {
            Repository.Repository.Update(customer);
        }

        // DELETE api/customer/5
        public void Delete(string id)
        {
            Repository.Repository.Delete<Customer>(id);
        }
    }
}
