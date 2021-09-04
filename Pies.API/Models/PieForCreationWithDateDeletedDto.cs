using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Models
{
    public class PieForCreationWithDateDeletedDto : PieForCreationDto
    {
        public DateTimeOffset? DateDeleted { get; set; }
    }
}
