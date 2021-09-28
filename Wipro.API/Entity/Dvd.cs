using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wipro.API.Entity
{
    public class Dvd: BaseEntity
    {
        public string MovieId { get; set; }
        public string Price { get; set; }
    }
}