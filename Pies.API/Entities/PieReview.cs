using System;
using System.ComponentModel.DataAnnotations;

namespace Pies.API.Entities
{
    public class PieReview
    {
        public Guid Id { get; set; }
        public Guid PieId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
