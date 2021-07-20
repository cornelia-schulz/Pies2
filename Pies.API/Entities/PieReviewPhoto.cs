using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Entities
{
    public class PieReviewPhoto
    {
        public Guid Id { get; set; }
        public string PhotoData { get; set; }
        public int PhotoBlobID { get; set; }
        public Guid PieReviewId { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
