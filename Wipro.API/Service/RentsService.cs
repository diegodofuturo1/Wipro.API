using Wipro.API.Dtos;
using Wipro.API.Entity;
using System.Collections.Generic;

namespace Wipro.API.Services
{
    public class RentsService: Repository<Rent>
    {
        public new List<RentDto> Select()
        {
            var dvdService = new DvdsService();
            var locatorService = new LocatorsService();
            var customerService = new CustomersService();

            var rents = base.Select();
            var list = new List<RentDto>();

            rents.ForEach(rent => {
                var dvd = dvdService.Select(rent.DvdId);
                var customer = customerService.Select(rent.CustomerId);
                var locator = locatorService.Select(rent.LocatorId);
                
                list.Add(new RentDto()
                {
                    Id = rent.Id,
                    Dvd = dvd,
                    Customer = customer,
                    Locator = locator,
                    RentDate = rent.RentDate,
                    ReturnDate = rent.ReturnDate,
                    Status = rent.Status
                });
            });

            return list;
        }
    }
}