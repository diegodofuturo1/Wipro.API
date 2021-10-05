using Wipro.API.Entity;

namespace Wipro.API.Dtos
{
    public class RentDto : BaseEntity
    {
        public DvdDto Dvd { get; set; }
        public Customer Customer { get; set; }
        public Locator Locator { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}