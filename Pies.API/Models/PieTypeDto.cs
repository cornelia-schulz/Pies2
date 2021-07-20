using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Models
{
    public class PieTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int FlavourTypeId { get; set; }
    }
}
