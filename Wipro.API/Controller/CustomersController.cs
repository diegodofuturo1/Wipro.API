using System;
using Wipro.Dtos;
using System.Web.Http;
using Wipro.API.Entity;
using Wipro.API.Services;

namespace Wipro.API.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly CustomersService Service = new CustomersService();

        public HttpResponseDto Get()
        {
            try
            {
                var data = Service.Select();
                
                return new HttpResponseDto(200)
                    .SetMessage("Clientes obtidos com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Get(string id)
        {
            try
            {
                var data = Service.Select(id);

                return new HttpResponseDto(200)
                    .SetMessage("Cliente obtido com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Post([FromBody] Customer customer)
        {
            try
            {
                var data = Service.Insert(customer);

                return new HttpResponseDto(201)
                    .SetMessage("Cliente criado com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Put([FromBody] Customer customer)
        {

            try
            {
                var data = Service.Update(customer);
                
                return new HttpResponseDto(200)
                    .SetMessage("Cliente atualizado com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Delete(string id)
        {
            try
            {
                var data = Service.Delete(id);

                return new HttpResponseDto(200)
                    .SetMessage("Cliente deletado com sucesso.");
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }
    }
}
