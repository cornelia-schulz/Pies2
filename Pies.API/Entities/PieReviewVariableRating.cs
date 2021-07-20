using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Entities
{
    public class PieReviewVariableRating
    {
        public Guid Id { get; set; }
        public Guid PieReviewVariableTypeId { get; set; }
        public int Rating { get; set; }
    }
}
