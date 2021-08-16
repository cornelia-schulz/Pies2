using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Models
{
    public class PieForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Guid PieTypeId { get; set; }
        public Guid UserId { get; set; }
        public int ShopId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public ICollection<PieReviewForCreationDto> PieReviews { get; set; }
            = new List<PieReviewForCreationDto>();
    }
}
