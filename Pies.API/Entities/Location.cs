using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
