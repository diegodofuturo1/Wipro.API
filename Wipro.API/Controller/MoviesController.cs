using System;
using Wipro.Dtos;
using System.Web.Http;
using Wipro.API.Entity;
using Wipro.API.Services;

namespace Wipro.API.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly MoviesService Service = new MoviesService();

        public HttpResponseDto Get()
        {
            try
            {
                var data = Service.Select();

                return new HttpResponseDto(200)
                    .SetMessage("Filmes obtidos com sucesso.")
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
                    .SetMessage("Filme obtido com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Post([FromBody] Movie movie)
        {
            try
            {
                var data = Service.Insert(movie);

                return new HttpResponseDto(201)
                    .SetMessage("Filme criado com sucesso.")
                    .Send(data);
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }

        public HttpResponseDto Put([FromBody] Movie movie)
        {

            try
            {
                var data = Service.Update(movie);

                return new HttpResponseDto(200)
                    .SetMessage("Filme atualizado com sucesso.")
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
                    .SetMessage("Filme deletado com sucesso.");
            }
            catch (Exception exception)
            {
                return new HttpResponseDto(400)
                    .SetMessage(exception.Message);
            }
        }
    }
}
