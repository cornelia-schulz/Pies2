using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Models
{
    public class PieForCreationDto
    {
        public string Name { get; set; }

        public Guid PieTypeId { get; set; }

        public Guid UserId { get; set; }
        public int ShopId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
