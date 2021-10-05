using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wipro.API.Entity
{
    public class Movie: BaseEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ReleaseDate { get; set; }
        public string Duration { get; set; }
        public string Image { get; set; }
    }
}