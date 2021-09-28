using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wipro.API.Entity
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
    }
}