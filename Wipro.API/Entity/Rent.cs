using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wipro.API.Entity
{
    public class Rent: BaseEntity
    {
        public string DvdId { get; set; }
        public string CustomerId { get; set; }
        public string LocatorId { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}