using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wipro.API.Entity
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public string Status{ get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            Status = "activated";
        }

        public BaseEntity(string id)
        {
            Id = id;
        }
    }
}