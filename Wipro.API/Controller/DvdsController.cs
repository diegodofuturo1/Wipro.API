using System;
using Wipro.Dtos;
using System.Web.Http;
using Wipro.API.Entity;
using Wipro.API.Services;

namespace Wipro.API.Controllers
{
    public class DvdsController : ApiController
    {
        private readonly DvdsService Service = new DvdsService();

        public HttpResponseDto Get()
        {
            try
            {
                var data = Service.Select();

                return new HttpResponseDto(200)
                    .SetMessage("Dvds obtidos com sucesso.")
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
                    .SetMessage("Dvd obtido com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Post([FromBody] Dvd dvd)
        {
            try
            {
                var data = Service.Insert(dvd);

                return new HttpResponseDto(201)
                    .SetMessage("Dvd criado com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Put([FromBody] Dvd dvd)
        {

            try
            {
                var data = Service.Update(dvd);

                return new HttpResponseDto(200)
                    .SetMessage("Dvd atualizado com sucesso.")
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
                    .SetMessage("Dvd deletado com sucesso.");
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }
    }
}
