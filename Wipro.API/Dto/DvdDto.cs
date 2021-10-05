using Wipro.API.Entity;

namespace Wipro.API.Dtos
{
    public class DvdDto : BaseEntity
    {
        public Movie Movie { get; set; }
        public string Price { get; set; }
        public string IsRented { get; set; }
    }
}