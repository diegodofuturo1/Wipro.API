using System;
using Wipro.Dtos;
using System.Web.Http;
using Wipro.API.Entity;
using Wipro.API.Services;

namespace Wipro.API.Controllers
{
    public class LocatorsController : ApiController
    {
        private readonly LocatorsService Service = new LocatorsService();

        public HttpResponseDto Get()
        {
            try
            {
                var data = Service.Select();

                return new HttpResponseDto(200)
                    .SetMessage("Locadores obtidos com sucesso.")
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
                    .SetMessage("Locador obtido com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Post([FromBody] Locator locator)
        {
            try
            {
                var data = Service.Insert(locator);

                return new HttpResponseDto(201)
                    .SetMessage("Locador criado com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Put([FromBody] Locator locator)
        {

            try
            {
                var data = Service.Update(locator);

                return new HttpResponseDto(200)
                    .SetMessage("Locador atualizado com sucesso.")
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
                    .SetMessage("Locador deletado com sucesso.");
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }
    }
}
