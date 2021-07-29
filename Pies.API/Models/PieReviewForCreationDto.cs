using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Models
{
    public class PieReviewForCreationDto
    {
        public DateTimeOffset DateCreated { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
