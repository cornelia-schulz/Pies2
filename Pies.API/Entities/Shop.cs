﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Entities
{
    public class Shop
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string Description { get; set; }
        public Guid ReviewStatusId { get; set; }
        public Location Location { get; set; }
    }
}
