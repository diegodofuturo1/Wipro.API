using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wipro.API.Dtos;
using Wipro.API.Entity;

namespace Wipro.API.Services
{
    public class DvdsService: Repository<Dvd>
    {
        public new List<DvdDto> Select()
        {
            var movieService = new MoviesService();
            var rentService = new RentsService();

            var dvds = base.Select();
            var list = new List<DvdDto>();

            dvds.ForEach(dvd => {
                var movie = movieService.Select(dvd.MovieId);
                var rents = rentService.Select("dvdId", dvd.Id);

                list.Add(new DvdDto()
                {
                    Id = dvd.Id,
                    Movie = movie,
                    Price = dvd.Price,
                    Status = dvd.Status,
                    IsRented = rents.Count > 0 ? "alugado": "disponível"
                });
            });

            return list;
        }

        public new DvdDto Select(string id)
        {
            var movieService = new MoviesService();

            var dvd = base.Select(id);
            var movie = movieService.Select(dvd.MovieId);

            return new DvdDto()
            {
                Id = dvd.Id,
                Movie = movie,
                Price = dvd.Price,
                Status = dvd.Status
            };
        }
    }
}