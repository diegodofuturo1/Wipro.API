using System;
using Wipro.Dtos;
using System.Web.Http;
using Wipro.API.Entity;
using Wipro.API.Services;

namespace Wipro.API.Controllers
{
    public class RentsController : ApiController
    {
        private readonly RentsService Service = new RentsService();

        public HttpResponseDto Get()
        {
            try
            {
                var data = Service.Select();

                return new HttpResponseDto(200)
                    .SetMessage("Aluguéis obtidos com sucesso.")
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
                    .SetMessage("Aluguel obtido com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Post([FromBody] Rent rent)
        {
            try
            {
                var data = Service.Insert(rent);

                return new HttpResponseDto(201)
                    .SetMessage("Aluguel criado com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Put([FromBody] Rent rent)
        {

            try
            {
                var data = Service.Update(rent);

                return new HttpResponseDto(200)
                    .SetMessage("Aluguel atualizado com sucesso.")
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
                    .SetMessage("Aluguel deletado com sucesso.");
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }
    }
}
